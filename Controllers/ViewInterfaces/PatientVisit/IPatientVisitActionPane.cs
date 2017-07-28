using FinanceManager.Contract.Dto;
using PatientManager.Contract.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers.ViewInterfaces.PatientVisit
{
    public interface IPatientVisitActionPane : IActionPane
    {

        void BindToPatientVisit(PatientVisitDto patientVisit);
        

    }
}
