using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueObjects.Health;
using PatientManager.Contract.Dto;
using FluentValidation;
using FluentValidation.Results;

namespace Controllers.Validators.PatientContext
{
    public class PatientValidator : AbstractValidator<PatientDto>
    {
        public PatientValidator()
        {
            RuleFor(pt => pt.FirstName).NotEmpty().WithMessage("First name is required");
            RuleFor(pt => pt.LastName).NotEmpty().WithMessage("Last name is required");
            RuleFor(pt => pt.DateOfBirth).NotEmpty().WithMessage("Date of birth is required");
            RuleFor(pt => pt.Gender).NotEqual(GenderType.None).WithMessage("Gender is required");

        }

    }
}
