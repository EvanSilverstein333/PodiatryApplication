using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controllers.Controllers;
using Controllers.ViewInterfaces;
using FinanceManager.Contract.Dto;

namespace View.ViewLauncher.FinancialTransactionView
{
    public class LaunchFinancialTransactionEditViewEvent : ILaunchableView
    {
        public LaunchFinancialTransactionEditViewEvent(FinancialAccountDto selectedAccount, FinancialTransactionDto transaction)
        {
            Transaction = transaction;
            Account = selectedAccount;

        }

        public FinancialAccountDto Account { get;}
        public FinancialTransactionDto Transaction { get; }
    }
}
