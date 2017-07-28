using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controllers.Controllers;
using Controllers.ViewInterfaces;
using FinanceManager.Contract.Dto;
using View.Dialogs;
using Controllers.ViewInterfaces.FinancialAccount;
using View.ViewLauncher;
using View.ViewLauncher.PatientView;
using View.ViewLauncher.FinancialTransactionView;

namespace View.Views.FinancialAccount
{
    public partial class FinanacialAccountDetails : Form, IFinancialAccountDetails
    {
        private FinancialAccountController _controller;
        private FinancialAccountDto _selectedFinancialAccount;
        private FinancialAccountActionPane _actionPane;
        private IViewLauncher _eventRaiser;

        public IActionPane ActionPane { get { return _actionPane; } }

        public FinanacialAccountDetails(FinancialAccountActionPane actionPane, IViewLauncher eventRaiser)
        {
            _eventRaiser = eventRaiser;
            _actionPane = actionPane;
            InitializeComponent();
            SubscribeToActionEvents();
        }


        public void BindToAccount(FinancialAccountDto account)
        {
            //var account = _controller.GetFinancialAccount(accountId);
            _selectedFinancialAccount = account;
            lblName.Text = account.FirstName + " " + account.LastName;
            lblBalance.Text = _controller.GetAccountBalance(account.Id).ToString();
        }


        private void SubscribeToActionEvents()
        {
            _actionPane.MakePaymentClicked += ActionPane_MakePaymentClicked;
            _actionPane.ChargeAccountClicked += ActionPane_ChargeAccountClicked;
            _actionPane.ViewFinancialTransactionsClicked += ActionPane_ViewFinancialTransactionsClicked;
            _actionPane.BackClicked += ActionPane_BackClicked;
            //_actionPane.ViewFinancialAccountClicked += BtnAddPatient;
        }



        private void ActionPane_BackClicked(object sender, EventArgs e)
        {
            _eventRaiser.Raise(new LaunchPatientIndexViewEvent(_selectedFinancialAccount.Id));
        }

        private void ActionPane_ViewFinancialTransactionsClicked(object sender, EventArgs e)
        {
            _eventRaiser.Raise(new LaunchFinancialTransactionIndexViewEvent(_selectedFinancialAccount));
        }

        private void ActionPane_ChargeAccountClicked(object sender, EventArgs e)
        {
            var defaultProperties = new FinancialTransactionDto()
            {
                Date = DateTime.Now,
                Money = new ValueObjects.Finance.Money(0, "CAN"),
                TransactionType = ValueObjects.Finance.TransactionType.Credit
            };
            _eventRaiser.Raise(new LaunchFinancialTransactionCreateViewEvent(_selectedFinancialAccount,defaultProperties));
        }

        private void ActionPane_MakePaymentClicked(object sender, EventArgs e)
        {
            var defaultProperties = new FinancialTransactionDto()
            {
                Date = DateTime.Now,
                Money = new ValueObjects.Finance.Money(0, "CAN"),
                TransactionType = ValueObjects.Finance.TransactionType.Debit
            };
            _eventRaiser.Raise(new LaunchFinancialTransactionCreateViewEvent(_selectedFinancialAccount, defaultProperties));
        }

        public void SetController(FinancialAccountController controller)
        {
            _controller = controller;
        }
    }
}
