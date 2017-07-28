using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientManager.Contract.Dto;

namespace View.Events.Patient
{
    public class PatientSelectionChanged
    {
        public PatientSelectionChanged(PatientDto patient)
        {
            Patient = patient;
        }
        public PatientDto Patient { get; }
    }
}
