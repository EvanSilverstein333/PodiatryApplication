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
    public class LaunchPatientCreateViewEvent : ILaunchableView
    {

        public LaunchPatientCreateViewEvent(PatientDto defaultPatientProperties)
        {
            DefaultPatientProperties = defaultPatientProperties;
        }
        public PatientDto DefaultPatientProperties { get; }
    }
}
