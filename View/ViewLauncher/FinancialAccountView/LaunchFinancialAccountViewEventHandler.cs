using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controllers.Controllers;
using Controllers.ViewInterfaces;

namespace View.ViewLauncher.FinancialAccountView
{
    public class LaunchFinancialAccountViewEventHandler : ILaunchableViewHandler<LaunchFinancialAccountDetailsViewEvent>
    {

        private FinancialAccountController _financialAccountController;
        private OrchestratorController _hostController;

        public LaunchFinancialAccountViewEventHandler(OrchestratorController hostController, FinancialAccountController financialAccountController)
        {
            _hostController = hostController;
            _financialAccountController = financialAccountController;
        }



        public void Handle(LaunchFinancialAccountDetailsViewEvent controllerEvent)
        {
            _financialAccountController.LoadDetailsView(controllerEvent.Account);
            _hostController.ComposeView(_financialAccountController.DetailsView, _financialAccountController.ActionPane);
        }

    }
}
