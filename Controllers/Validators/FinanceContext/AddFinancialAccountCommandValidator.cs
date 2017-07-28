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
    public class AddFinancialAccountCommandValidator : AbstractValidator<AddFinancialAccountCommand>
    {
        public AddFinancialAccountCommandValidator()
        {
            RuleFor(cmd => cmd.Account).SetValidator(new FinancialAccountValidator());
            //AddRule(new CompositeValidatorRule(new AddPatientCommandValidator()));
        }

    }
}
