using Controllers.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers.ViewInterfaces.Patient
{
    public interface IPatientIndex : IView<PatientController>
    {
        IActionPane ActionPane { get; }
        void Initialize(Guid patientId);

    }
}
