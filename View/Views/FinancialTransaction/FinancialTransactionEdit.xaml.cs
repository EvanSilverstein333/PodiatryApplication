using PatientManager.Contract.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Controllers.ViewInterfaces.Patient;
using Controllers.Controllers;
using Controllers.ViewInterfaces.FinancialTransaction;
using FinanceManager.Contract.Dto;
using View.ViewLauncher;
using View.ViewLauncher.FinancialTransactionView;
using View.ViewLauncher.FinancialAccountView;

namespace View.Views.FinancialTransaction
{
    /// <summary>
    /// Interaction logic for PatientCreate.xaml
    /// </summary>
    public partial class FinancialTransactionEdit : UserControl, IFinancialTransactionEdit
    {
        private FinancialTransactionController _controller;
        private FinancialTransactionDto _selectedTransaction;
        private FinancialAccountDto _selectedAccount;
        private IViewLauncher _eventRaiser;
        
        public string Text { get; set; }
        public bool IsDisposed { get; private set; }


        public FinancialTransactionEdit(IViewLauncher eventRaiser)
        {
            _eventRaiser = eventRaiser;
            InitializeComponent();
        }


        public void BindToTransaction(FinancialTransactionDto transaction, FinancialAccountDto account)
        {
            _selectedAccount = account;
            _selectedTransaction = transaction;
            SetInitialInputValues(transaction);
        }

        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            {

                var transaction = _selectedTransaction;
                SetFinancialTransactionProperties(transaction);

                var result = await Task.Run(() => _controller.UpdateFinancialTransaction(transaction));

                if (result)
                {
                    _eventRaiser.Raise(new LaunchFinancialTransactionIndexViewEvent(_selectedAccount, _selectedTransaction.Id));

                }




            }
        }




        private void SetInitialInputValues(FinancialTransactionDto transaction)
        {
            transactionControl.Date = transaction.Date;
            transactionControl.Money = transaction.Money;
            transactionControl.Notes = transaction.Notes;
        }

        private void SetFinancialTransactionProperties(FinancialTransactionDto transaction)
        {
            transaction.Date = transactionControl.Date;
            transaction.Money = transactionControl.Money;
            transaction.Notes = transactionControl.Notes;
        }


        public void SetController(FinancialTransactionController controller)
        {
            _controller = controller;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            _eventRaiser.Raise(new LaunchFinancialAccountDetailsViewEvent(_selectedAccount));
        }


    }
}
