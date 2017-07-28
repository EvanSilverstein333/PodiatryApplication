using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controllers.Controllers;
using Controllers.ViewInterfaces;
using PatientManager.Contract.Dto;

namespace View.ViewLauncher.ContactInformation
{
    public class LaunchContactInformationViewEditEvent : ILaunchableView
    {


        public LaunchContactInformationViewEditEvent(PatientDto patient)
        {
            Patient = patient;
        }
        public PatientDto Patient { get;}
    }
}
