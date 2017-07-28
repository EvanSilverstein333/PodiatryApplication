using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controllers.Controllers;
using Controllers.ViewInterfaces;
using PatientManager.Contract.Dto;

namespace View.ViewLauncher.PatientVisitView
{
    public class LaunchPatientVisitEditViewEvent : ILaunchableView
    {
        
        public LaunchPatientVisitEditViewEvent(PatientVisitDto visit, PatientDto selectedPatient)
        {
            Visit = visit;
            SelectedPatient = selectedPatient;
        }
        public PatientDto SelectedPatient { get; }
        public PatientVisitDto Visit { get;}
    }
}
