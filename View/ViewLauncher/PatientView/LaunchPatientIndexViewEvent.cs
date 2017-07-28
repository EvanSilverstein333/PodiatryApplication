using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controllers.Controllers;
using Controllers.ViewInterfaces;

namespace View.ViewLauncher.PatientView
{
    public class LaunchPatientIndexViewEvent : ILaunchableView
    {

        public LaunchPatientIndexViewEvent()
        {
        }
        public LaunchPatientIndexViewEvent(Guid preSelectedPatientId)
        {
            PreSelectedPatientId = preSelectedPatientId;
        }
        public Guid PreSelectedPatientId { get; }
    }
}
