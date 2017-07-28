using Controllers.Controllers;
using FinanceManager.Contract.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers.ViewInterfaces.FinancialAccount
{
    public interface IFinancialAccountDetails : IView<FinancialAccountController>
    {
        IActionPane ActionPane { get; }
        void BindToAccount(FinancialAccountDto account);

    }
}
