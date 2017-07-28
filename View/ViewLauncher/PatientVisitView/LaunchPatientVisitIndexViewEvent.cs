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
    public class LaunchPatientVisitIndexViewEvent : ILaunchableView
    {

        public LaunchPatientVisitIndexViewEvent(PatientDto selectedPatient, Guid preSelectedVisitId) : this(selectedPatient)
        {
            PreSelectedVisitId = preSelectedVisitId;
        }


        public LaunchPatientVisitIndexViewEvent(PatientDto patient)
        {
            Patient = patient;
        }

        public PatientDto Patient { get;}
        public Guid PreSelectedVisitId { get; }
    }
}
