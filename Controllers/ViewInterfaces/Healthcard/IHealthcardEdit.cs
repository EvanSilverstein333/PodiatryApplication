﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controllers.Controllers;
using PatientManager.Contract.Dto;

namespace Controllers.ViewInterfaces.Healthcard
{
    public interface IHealthcardEdit : IView<HealthcardController>
    {
        void BindToPatient(PatientDto patient);
        //void SetActionPane(IActionPane actionPane);
    }
}
