using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controllers.Controllers;
using Controllers.ViewInterfaces;

namespace View.ViewLauncher.HomeView
{
    public class LaunchHomeViewEventHandler : ILaunchableViewHandler<LaunchHomeViewEvent>
    {

        private HomeController _homeController;
        private OrchestratorController _hostController;

        public LaunchHomeViewEventHandler(OrchestratorController hostController, HomeController homeController)
        {
            _hostController = hostController;
            _homeController = homeController;
        }


        public void Handle(LaunchHomeViewEvent controllerEvent)
        {
            _hostController.ComposeView(_homeController.View);
        }
    }
}
