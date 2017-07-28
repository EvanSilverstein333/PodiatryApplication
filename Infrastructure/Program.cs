using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using SimpleInjector;
using Controllers.Controllers;
using Infrastructure.ErrorHandlers;
using log4net;

namespace Infrastructure
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                AppDomain.CurrentDomain.UnhandledException += (sender, e) => FatalExceptionObject.Handle(e.ExceptionObject);
                Application.ThreadException += (sender, e) => FatalExceptionHandler.Handle(e.Exception);
                Application.SetCompatibleTextRenderingDefault(false);
                Application.ApplicationExit += Application_ApplicationExit;
                Application.EnableVisualStyles();
                Bootstrapper.SetConfigurations();
                var container = Bootstrapper.Container;
                var orchestratorController = container.GetInstance<OrchestratorController>();
                var homeController = container.GetInstance<HomeController>();
                orchestratorController.ComposeView(homeController.View);
                Application.Run((Form)orchestratorController.View);

            }
            catch (Exception e)
            {
                FatalExceptionHandler.Handle(e);
            }
           
        }



        private static void Application_ApplicationExit(object sender, EventArgs e)
        {
            if (Bootstrapper.Container != null)
            {
                var logger = Bootstrapper.Logger;
                logger.Info("Application session terminated");
                Bootstrapper.Container.Dispose();
            }
        }

    }
}
