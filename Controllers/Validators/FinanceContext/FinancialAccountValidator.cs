using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueObjects.Health;
using FluentValidation;
using FluentValidation.Results;
using FinanceManager.Contract.Dto;

namespace Controllers.Validators.FinanceContext
{
    public class FinancialAccountValidator : AbstractValidator<FinancialAccountDto>
    {
        public FinancialAccountValidator()
        {
            RuleFor(account => account.FirstName).NotEmpty().WithMessage("First name is required");
            RuleFor(account => account.LastName).NotEmpty().WithMessage("Last name is required");
        }

    }
}
