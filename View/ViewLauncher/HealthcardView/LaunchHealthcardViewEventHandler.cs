using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controllers.Controllers;
using Controllers.ViewInterfaces;

namespace View.ViewLauncher.HealthcardView
{
    public class LaunchHealthcardViewEventHandler : ILaunchableViewHandler<LaunchHealthcardViewEditEvent>
    {

        private HealthcardController _healthcardController;
        private OrchestratorController _hostController;

        public LaunchHealthcardViewEventHandler(OrchestratorController hostController, HealthcardController healthcardController)
        {
            _hostController = hostController;
            _healthcardController = healthcardController;
        }


        public void Handle(LaunchHealthcardViewEditEvent controllerEvent)
        {
            _healthcardController.LoadEditView(controllerEvent.Patient);
            _hostController.ComposeView(_healthcardController.EditView);
        }
    }
}
