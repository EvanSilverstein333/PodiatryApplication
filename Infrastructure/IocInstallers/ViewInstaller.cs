using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleInjector;
using View.Views;
using View.Views.Home;
using Controllers.ViewInterfaces;
using SimpleInjector.Diagnostics;
using View.Events;
using Controllers.ViewInterfaces.Patient;
using Controllers.ViewInterfaces.Orchestrator;

namespace Infrastructure.IocInstallers
{
    static class ViewInstaller
    {
        private static IEnumerable<Type> ViewServiceTypes; // used to suppress errors
        private static Lifestyle CacheActionPaneWhileNotDisposed;
        public static void RegisterServices(Container _simpleContainer)
        {

            SetCustomLifeStyle();
            RegisterViews(_simpleContainer);
            RegisterViewPackages(_simpleContainer);
            _simpleContainer.Register(typeof(IViewsPackage<>), AppDomain.CurrentDomain.GetAssemblies());
            _simpleContainer.RegisterSingleton(typeof(IEventListener<>), typeof(EventListener<>));
            _simpleContainer.RegisterSingleton(typeof(IEventPublisher<>), typeof(EventPublisher<>));
            _simpleContainer.RegisterSingleton(typeof(EventOrchestrator<>), typeof(EventOrchestrator<>));


        }

        private static void SetCustomLifeStyle()
        {
            CacheActionPaneWhileNotDisposed = Lifestyle.CreateCustom("Cache ActionPane While Not Disposed",
                instanceCreator =>
                {
                    var syncRoot = new object();
                    object instance = null;

                    return () =>
                    {
                        lock (syncRoot)
                        {
                            var actionPane = instance as IActionPane;
                            if (actionPane == null || actionPane.IsDisposed)
                            {
                                instance = null;
                                instance = instanceCreator.Invoke();
                            }
                            return instance;
                        }
                    };
                });

        }

        private static void RegisterViewPackages(Container _simpleContainer)
        {
            var viewPkgAssembly = typeof(IViewsPackage<>).Assembly;
            var pkgTypes =
                from type in viewPkgAssembly.GetExportedTypes()
                where type.GetInterfaces().Any(i=> i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IViewsPackage<>))
                select type;

            //var viewServiceTypes = new List<Type>(); // to suppress warnings after
            foreach (var type in pkgTypes)
            {
                //_simpleContainer.Register(type,type);
                var lifestyle = (type == typeof(PatientViewsPkg)) ? Lifestyle.Singleton : Lifestyle.Singleton;
                _simpleContainer.Register(type, type, lifestyle);

            }
        }

        private static void RegisterViews(Container _simpleContainer)
        {
            var viewAssembly = typeof(HomeView).Assembly;
            var viewTypes =
                from type in viewAssembly.GetExportedTypes()
                where type.GetInterfaces().Contains(typeof(IViewBase))
                select type;

            var viewServiceTypes = new List<Type>(); // to suppress warnings after
            foreach (var viewType in viewTypes)
            {
                Type service = null;
                if (viewType.GetInterfaces().Contains(typeof(IActionPane)))
                {
                    service = viewType;
                    _simpleContainer.Register(viewType, viewType, CacheActionPaneWhileNotDisposed); // implementation is directly injected in views
                    var interfaceService = GetActionPaneService(viewType);
                    _simpleContainer.Register(interfaceService,(() => _simpleContainer.GetInstance(viewType))); // interface is injected into viewsPkg

                }
                else
                {
                    Lifestyle lifestyle;
                    service = GetViewService(viewType);
                    lifestyle = (service == typeof(IOrchestratorView)) ? Lifestyle.Singleton : Lifestyle.Transient;
                    _simpleContainer.Register(service, viewType, lifestyle);
                }
                viewServiceTypes.Add(service);

            }
            ViewServiceTypes = viewServiceTypes;

        }

    

        private static Type GetViewService(Type viewType)
        {
            var service = viewType.GetInterfaces()
                .Where(i => i.GetInterfaces().Contains(typeof(IViewBase)) && i.IsGenericType == false).Single();

            return service;

        }

        private static Type GetActionPaneService(Type viewType)
        {
            var service = viewType.GetInterfaces()
                .Where(i => i.GetInterfaces().Contains(typeof(IActionPane))).Single();

            return service;

        }

        public static void SuppressIocWarnings(Container _simpleContainer)
        {
            Registration reg = null;

            foreach (var service in ViewServiceTypes)
            {
                reg = _simpleContainer.GetRegistration(service).Registration;
                reg.SuppressDiagnosticWarning(DiagnosticType.DisposableTransientComponent,
                    "The views are expected to dispose when form is closed");
                //reg.SuppressDiagnosticWarning(DiagnosticType.LifestyleMismatch,
                //    "A captive depedency is avoided becasue The controller lifestyle should dispose when its dependency (view) is disposed");
            }

        }
    }
}
