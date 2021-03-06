﻿using Controllers.Controllers;
using PatientManager.Contract.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers.ViewInterfaces.Patient
{
    public interface IPatientEdit : IView<PatientController>
    {
        void BindToPatient(PatientDto patient);
    }
}
