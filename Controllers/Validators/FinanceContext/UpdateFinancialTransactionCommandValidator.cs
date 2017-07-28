using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using PatientManager.Contract.Commands;
using FinanceManager.Contract.Commands;

namespace Controllers.Validators.FinanceContext
{
    public class UpdateFinancialTransactionCommandValidator : AbstractValidator<UpdateFinancialTransactionCommand>
    {
        public UpdateFinancialTransactionCommandValidator()
        {
            RuleFor(cmd => cmd.Transaction).SetValidator(new FinancialTransactionValidator());
        }

    }
}