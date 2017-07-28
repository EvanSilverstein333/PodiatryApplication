using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controllers.Controllers;
using Controllers.ViewInterfaces;

namespace View.ViewLauncher.PatientView
{
    public class LaunchPatientViewEventHandler 
        : ILaunchableViewHandler<LaunchPatientIndexViewEvent>, ILaunchableViewHandler<LaunchPatientCreateViewEvent>, ILaunchableViewHandler<LaunchPatientEditViewEvent>
    {

        private PatientController _patientController;
        private HealthcardController _healthcardController;
        private ContactInformationController _contactInfoController;
        private OrchestratorController _hostController;

        public LaunchPatientViewEventHandler(OrchestratorController hostController, PatientController patientController, HealthcardController healthcardController, ContactInformationController contactInfoController)
        {
            _hostController = hostController;
            _patientController = patientController;
            _healthcardController = healthcardController;
            _contactInfoController = contactInfoController;
        }


        public void Handle(LaunchPatientIndexViewEvent controllerEvent)
        {
            var id = controllerEvent.PreSelectedPatientId;
            _patientController.LoadIndexView(id);
            _hostController.ComposeView(_patientController.IndexView, _patientController.ActionPane, _healthcardController.DetailsView, _contactInfoController.DetailsView);
        }

        public void Handle(LaunchPatientCreateViewEvent controllerEvent)
        {
            _patientController.LoadCreateView(controllerEvent.DefaultPatientProperties);
            _hostController.ComposeView(_patientController.CreateView);

        }

        public void Handle(LaunchPatientEditViewEvent controllerEvent)
        {
            _patientController.LoadEditView(controllerEvent.Patient);
            _hostController.ComposeView(_patientController.EditView);

        }
    }
}
