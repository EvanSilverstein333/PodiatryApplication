using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controllers.Controllers;
using Controllers.ViewInterfaces;

namespace View.ViewLauncher.FinancialTransactionView
{
    public class LaunchFinancialTransactionViewEventHandler 
        : ILaunchableViewHandler<LaunchFinancialTransactionIndexViewEvent>, ILaunchableViewHandler<LaunchFinancialTransactionEditViewEvent>, ILaunchableViewHandler<LaunchFinancialTransactionCreateViewEvent>
    {

        private FinancialTransactionController _financialTransactionController;
        private OrchestratorController _hostController;

        public LaunchFinancialTransactionViewEventHandler(OrchestratorController hostController, FinancialTransactionController financialTransactionController)
        {
            _hostController = hostController;
            _financialTransactionController = financialTransactionController;
        }



        public void Handle(LaunchFinancialTransactionIndexViewEvent controllerEvent)
        {
            _financialTransactionController.LoadIndexView(controllerEvent.Account, controllerEvent.TransactionId);
            _hostController.ComposeView(_financialTransactionController.IndexView, _financialTransactionController.ActionPane);
        }

        public void Handle(LaunchFinancialTransactionEditViewEvent controllerEvent)
        {

            _financialTransactionController.LoadEditView(controllerEvent.Transaction, controllerEvent.Account);
            _hostController.ComposeView(_financialTransactionController.EditView);
        }

        public void Handle(LaunchFinancialTransactionCreateViewEvent controllerEvent)
        {
            _financialTransactionController.LoadCreateView(controllerEvent.TransactionDefaultProperteis, controllerEvent.Account);
            _hostController.ComposeView(_financialTransactionController.CreateView);

        }

    }
}
