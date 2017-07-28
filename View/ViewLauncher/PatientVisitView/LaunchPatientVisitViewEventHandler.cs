using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controllers.Controllers;
using Controllers.ViewInterfaces;

namespace View.ViewLauncher.PatientVisitView
{
    public class LaunchPatientVisitViewEventHandler 
        : ILaunchableViewHandler<LaunchPatientVisitIndexViewEvent>, ILaunchableViewHandler<LaunchPatientVisitCreateViewEvent>, ILaunchableViewHandler<LaunchPatientVisitEditViewEvent>
    {

        private PatientVisitController _patientVisitController;
        private OrchestratorController _hostController;

        public LaunchPatientVisitViewEventHandler(OrchestratorController hostController, PatientVisitController patientVisitController)
        {
            _hostController = hostController;
            _patientVisitController = patientVisitController;
        }


        public void Handle(LaunchPatientVisitIndexViewEvent controllerEvent)
        {
            _patientVisitController.LoadIndexView(controllerEvent.Patient, controllerEvent.PreSelectedVisitId);
            _hostController.ComposeView(_patientVisitController.IndexView, _patientVisitController.ActionPane);
        }

        public void Handle(LaunchPatientVisitCreateViewEvent controllerEvent)
        {
            _patientVisitController.LoadCreateView(controllerEvent.VisitDefaultProperties, controllerEvent.SelectedPatient);
            _hostController.ComposeView(_patientVisitController.CreateView);

        }

        public void Handle(LaunchPatientVisitEditViewEvent controllerEvent)
        {
            _patientVisitController.LoadEditView(controllerEvent.Visit, controllerEvent.SelectedPatient);
            _hostController.ComposeView(_patientVisitController.EditView);

        }
    }
}
