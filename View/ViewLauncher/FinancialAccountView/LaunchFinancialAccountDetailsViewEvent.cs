using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controllers.Controllers;
using Controllers.ViewInterfaces;
using FinanceManager.Contract.Dto;

namespace View.ViewLauncher.FinancialAccountView
{
    public class LaunchFinancialAccountDetailsViewEvent : ILaunchableView
    {
        public LaunchFinancialAccountDetailsViewEvent(FinancialAccountDto account) // account may not exist so need to pass info for creating
        {
            Account = account;
        }

        public FinancialAccountDto Account { get;}
    }
}
