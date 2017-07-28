using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleInjector;
using Infrastructure.Abstractions;
using log4net;
using Controllers.Code;
using Controllers.Code.CrossCuttingConcerns;
using Controllers.Controllers;
using Infrastructure.Configuration.Services;
using Infrastructure.Services.PatientManagerServices.CommandProcessorService;
using Controllers.ViewInterfaces;
using View.ViewLauncher;
using FluentValidation;
using Controllers.Validators;

namespace Infrastructure.IocInstallers
{
    static class InfrastructureInstaller
    {

        public static void RegisterServices(Container _simpleContainer)
        {
            _simpleContainer.RegisterSingleton(new PatientManagerMessageCallback());
            _simpleContainer.RegisterSingleton<ILog>(Bootstrapper.Logger);
            _simpleContainer.Register<ILogger, Logger>();

            _simpleContainer.RegisterSingleton<IViewLauncher>(new ViewLauncher());
            _simpleContainer.RegisterSingleton<ICommandProcessor>(new CommandProcessor());
            _simpleContainer.RegisterSingleton<IQueryProcessor>(new QueryProcessor());
            _simpleContainer.RegisterSingleton<IViewFactory>(new ViewFactory());

            _simpleContainer.Register(typeof(ICommandHandler<>), typeof(WcfServiceCommandHandlerProxy<>));
            _simpleContainer.Register(typeof(IQueryHandler<,>), typeof(WcfServiceQueryHandlerProxy<,>));

            //_simpleContainer.RegisterDecorator(typeof(ICommandHandler<>), typeof(ValidationCommandHandlerDecorator<>));
            _simpleContainer.RegisterDecorator(typeof(ICommandHandler<>), typeof(NotifyOnRequestCompletedCommandHandlerDecorator<>));
            _simpleContainer.RegisterDecorator(typeof(ICommandHandler<>), typeof(FromWcfFaultTranslatorCommandHandlerDecorator<>));
            _simpleContainer.RegisterDecorator(typeof(ICommandHandler<>), typeof(ErrorHandlingCommandHandlerDecorator<>));

            //Validators
            _simpleContainer.Register(typeof(IValidator<>), AppDomain.CurrentDomain.GetAssemblies(), Lifestyle.Singleton);
            _simpleContainer.RegisterConditional(typeof(IValidator<>), typeof(EmptyValidator<>), Lifestyle.Singleton,
            c => !c.Handled);

        }
    }
}
