using Controllers.Controllers;
using PatientManager.Contract.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinanceManager.Contract.Dto;

namespace Controllers.ViewInterfaces.FinancialTransaction
{
    public interface IFinancialTransactionEdit : IView<FinancialTransactionController>
    {
        void BindToTransaction(FinancialTransactionDto transaction, FinancialAccountDto account);

    }
}
