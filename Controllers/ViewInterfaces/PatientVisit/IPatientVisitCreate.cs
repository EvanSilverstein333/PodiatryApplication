using Controllers.Controllers;
using PatientManager.Contract.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers.ViewInterfaces.PatientVisit
{
    public interface IPatientVisitCreate : IView<PatientVisitController>
    {
        void BindToPatientVisit(PatientVisitDto defaultVisitProperties, PatientDto selectedPatient);
    }
}
