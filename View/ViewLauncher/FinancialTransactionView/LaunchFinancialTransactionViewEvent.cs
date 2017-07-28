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
    public class LaunchFinancialTransactionIndexViewEvent : ILaunchableView
    {
        public LaunchFinancialTransactionIndexViewEvent(FinancialAccountDto selectedAccount, Guid preSelectedTransactionId): this(selectedAccount)
        {
            TransactionId = preSelectedTransactionId;
        }

        public LaunchFinancialTransactionIndexViewEvent(FinancialAccountDto selectedAccount)
        {
            Account = selectedAccount;
        }


        public FinancialAccountDto Account { get;}
        public Guid TransactionId { get; }
    }
}
