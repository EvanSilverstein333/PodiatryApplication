using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleInjector;
using Infrastructure.IocInstallers;
using log4net;
using SimpleInjector.Diagnostics;
using Infrastructure.Configuration.Services;
using System.Reflection;
using FinanceManager.Contract.Dto;
using PatientManager.Contract.Dto;

namespace Infrastructure
{
    public static class Bootstrapper
    {
        public static readonly Container Container;
        public static readonly ILog Logger;
        public static readonly Assembly FinanceContextAssembly;
        public static readonly Assembly PatientContextAssembly;        

        static Bootstrapper()
        {
            FinanceContextAssembly = typeof(FinancialAccountDto).Assembly;
            PatientContextAssembly = typeof(PatientDto).Assembly;
            Logger = log4net.LogManager.GetLogger("RollingFileLogger");
            var container = new Container();
            InfrastructureInstaller.RegisterServices(container);
            ControllersInstaller.RegisterServices(container);
            ViewInstaller.RegisterServices(container);

            ViewInstaller.SuppressIocWarnings(container); //suppressions must happen after registrations
            //container.Verify();
            Container = container;
            //SetConfigurations(); // must happen after container is wired
        }


        public static void SetConfigurations()
        {
            PatientManagerMessageCallback.SubscribeToMessages();
        }


    }
}
