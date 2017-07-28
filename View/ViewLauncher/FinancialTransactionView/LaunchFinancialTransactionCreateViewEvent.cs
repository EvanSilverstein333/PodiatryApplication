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
    public class LaunchFinancialTransactionCreateViewEvent : ILaunchableView
    {
        public LaunchFinancialTransactionCreateViewEvent(FinancialAccountDto selectedAccount, FinancialTransactionDto transactionDefaultProperties): this(selectedAccount)
        {
            TransactionDefaultProperteis = transactionDefaultProperties;
        }

        public LaunchFinancialTransactionCreateViewEvent(FinancialAccountDto selectedAccount)
        {
            Account = selectedAccount;
        }


        public FinancialAccountDto Account { get;}
        public FinancialTransactionDto TransactionDefaultProperteis { get; }
    }
}
