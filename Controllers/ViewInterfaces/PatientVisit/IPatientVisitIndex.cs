using Controllers.Controllers;
using PatientManager.Contract.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers.ViewInterfaces.PatientVisit
{
    public interface IPatientVisitIndex : IView<PatientVisitController>
    {
        IActionPane ActionPane { get; }
        void BindToPatient(PatientDto patient, Guid preSelectedVisitId);
    }
}
