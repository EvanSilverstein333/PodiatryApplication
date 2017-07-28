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
    public partial class FinancialTransactionCreate : UserControl, IFinancialTransactionCreate
    {
        private FinancialTransactionController _controller;
        //private FinancialTransactionDto _selectedTransaction;
        private FinancialAccountDto _selectedAccount;
        private IViewLauncher _eventRaiser;
        
        public string Text { get; set; }
        public bool IsDisposed { get; private set; }


        public FinancialTransactionCreate(IViewLauncher eventRaiser)
        {
            _eventRaiser = eventRaiser;
            InitializeComponent();
        }


        public void BindToTransaction(FinancialTransactionDto transactionDefaultProperties, FinancialAccountDto account)
        {
            _selectedAccount = account;
            //_selectedTransaction = transactionDefaultProperties;
            var transaction = (transactionDefaultProperties != null) ? transactionDefaultProperties : new FinancialTransactionDto() { Money = new ValueObjects.Finance.Money() };
            SetInitialInputValues(transaction);
        }

        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            {

                var transaction = new FinancialTransactionDto(Guid.NewGuid(),_selectedAccount.Id);
                SetFinancialTransactionProperties(transaction);

                var result = await Task.Run(() => _controller.AddFinancialTransaction(transaction));

                if (result)
                {
                    _eventRaiser.Raise(new LaunchFinancialTransactionIndexViewEvent(_selectedAccount, transaction.Id));

                }




            }
        }




        private void SetInitialInputValues(FinancialTransactionDto transaction)
        {
            transactionControl.Date = transaction.Date;
            transactionControl.Money = transaction.Money;
            transactionControl.Notes = transaction.Notes;
            transactionControl.TransactionType = transaction.TransactionType;
        }

        private void SetFinancialTransactionProperties(FinancialTransactionDto transaction)
        {
            transaction.Date = transactionControl.Date;
            transaction.Money = transactionControl.Money;
            transaction.Notes = transactionControl.Notes;
            transaction.TransactionType = transactionControl.TransactionType;
        }


        public void SetController(FinancialTransactionController controller)
        {
            _controller = controller;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            //_eventRaiser.Raise(new LaunchFinancialTransactionIndexViewEvent(_selectedAccount));
            _eventRaiser.Raise(new LaunchFinancialAccountDetailsViewEvent(_selectedAccount));

        }


    }
}
