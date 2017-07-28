﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using PatientManager.Contract.Commands;

namespace Controllers.Validators.PatientContext
{
    public class UpdatePatientVisitCommandValidator : AbstractValidator<UpdatePatientVisitCommand>
    {
        public UpdatePatientVisitCommandValidator()
        {
            RuleFor(cmd => cmd.Visit).SetValidator(new PatientVisitValidator());
        }
    }
}
