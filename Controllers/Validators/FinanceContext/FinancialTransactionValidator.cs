using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueObjects.Health;
using PatientManager.Contract.Dto;
using FluentValidation;
using FluentValidation.Results;
using FinanceManager.Contract.Dto;

namespace Controllers.Validators.FinanceContext
{
    public class FinancialTransactionValidator : AbstractValidator<FinancialTransactionDto>
    {
        public FinancialTransactionValidator()
        {
            RuleFor(transaction => transaction.Date).NotEmpty().WithMessage("Date is required");
            RuleFor(transaction => transaction.Money.Currency).NotEmpty().WithMessage("Currency is required");

        }

    }
}
