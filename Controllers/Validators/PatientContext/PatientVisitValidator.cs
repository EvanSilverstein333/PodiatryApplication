using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using PatientManager.Contract.Dto;

namespace Controllers.Validators.PatientContext
{
    public class PatientVisitValidator : AbstractValidator<PatientVisitDto>
    {
        public PatientVisitValidator()
        {
            RuleFor(visit => visit.Date).NotEmpty().WithMessage("Date is required");
            RuleFor(visit => visit.Diagnosis).NotEmpty().WithMessage("Diagnosis is required");
        }
    }
}
