﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using PatientManager.Contract.Commands;

namespace Controllers.Validators.PatientContext
{
    public class AddPatientVisitCommandValidator : AbstractValidator<AddPatientVisitCommand>
    {
        public AddPatientVisitCommandValidator()
        {
            RuleFor(cmd => cmd.Visit).SetValidator(new PatientVisitValidator());
        }
    }
}
