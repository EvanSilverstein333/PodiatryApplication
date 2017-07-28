using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controllers.Controllers;
using Controllers.ViewInterfaces;

namespace View.ViewLauncher.ContactInformation
{
    public class LaunchContactInformationViewEventHandler : ILaunchableViewHandler<LaunchContactInformationViewEditEvent>
    {

        private ContactInformationController _contactInfoController;
        private OrchestratorController _hostController;

        public LaunchContactInformationViewEventHandler(OrchestratorController hostController, ContactInformationController contactInfoController)
        {
            _hostController = hostController;
            _contactInfoController = contactInfoController;
        }


        public void Handle(LaunchContactInformationViewEditEvent controllerEvent)
        {
            _contactInfoController.LoadEditView(controllerEvent.Patient);
            _hostController.ComposeView(_contactInfoController.EditView);
        }
    }
}
