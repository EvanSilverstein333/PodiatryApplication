using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleInjector;
using Controllers.Controllers;
using Controllers.Code.ExternalEventHandlers;
using Controllers.Code.CrossCuttingConcerns;
using View.ViewLauncher;

namespace Infrastructure.IocInstallers
{
    static class ControllersInstaller
    {

        public static void RegisterServices(Container _simpleContainer)
        {

            var controllerAssembly = typeof(IController).Assembly;
            var controllerRegistrations =
                from type in controllerAssembly.GetExportedTypes()
                where type.Namespace == typeof(IController).Namespace
                where type.GetInterfaces().Contains(typeof(IController)) && type.IsClass
                select new { Service = type.GetInterfaces().Single(), Implementation = type };

            foreach (var reg in controllerRegistrations)
            {
                //Lifestyle lifestyle = (
                //    reg.Implementation == typeof(OrchestratorController) 
                //    || reg.Implementation == typeof(PatientController)
                //    || reg.Implementation == typeof(PatientVisitController)
                //    || reg.Implementation == typeof(FinancialTransactionController))    
                //    ? Lifestyle.Singleton : Lifestyle.Singleton;
                _simpleContainer.Register(reg.Implementation, reg.Implementation, Lifestyle.Singleton);
            }

            _simpleContainer.RegisterCollection(typeof(ILaunchableViewHandler<>), AppDomain.CurrentDomain.GetAssemblies());
            _simpleContainer.RegisterCollection(typeof(IExternalEventHandler<>), AppDomain.CurrentDomain.GetAssemblies());
            _simpleContainer.RegisterSingleton<NotifyCommandCompletedCallback>();
            _simpleContainer.RegisterSingleton<INotifyCommandCompletedCallback>(() => _simpleContainer.GetInstance<NotifyCommandCompletedCallback>());

        }


    }
}
