using Controllers.Controllers;
using PatientManager.Contract.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers.ViewInterfaces.PatientVisit
{
    public interface IPatientVisitEdit : IView<PatientVisitController>
    {
        void BindToPatientVisit(PatientVisitDto visit, PatientDto selectedPatient);

    }
}
