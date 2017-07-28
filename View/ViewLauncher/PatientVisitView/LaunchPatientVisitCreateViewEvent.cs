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
    public class LaunchPatientVisitCreateViewEvent : ILaunchableView
    {
        
        public LaunchPatientVisitCreateViewEvent(PatientVisitDto visitDefaultProperties, PatientDto selectedPatient)
        {
            VisitDefaultProperties = visitDefaultProperties;
            SelectedPatient = selectedPatient;
        }
        public PatientDto SelectedPatient { get; }
        public PatientVisitDto VisitDefaultProperties { get;}
    }
}
