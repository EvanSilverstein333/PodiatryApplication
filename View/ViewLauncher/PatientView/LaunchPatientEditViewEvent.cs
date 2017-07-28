using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controllers.Controllers;
using Controllers.ViewInterfaces;
using PatientManager.Contract.Dto;

namespace View.ViewLauncher.PatientView
{
    public class LaunchPatientEditViewEvent : ILaunchableView
    {

        public LaunchPatientEditViewEvent(PatientDto patient)
        {
            Patient = patient;
        }
        public PatientDto Patient { get; }
    }
}
