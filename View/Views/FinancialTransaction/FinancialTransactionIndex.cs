using Controllers.Controllers;
using Controllers.ViewInterfaces;
using FinanceManager.Contract.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using View.Dialog;
using Controllers.ViewInterfaces.FinancialTransaction;
using View.ViewLauncher;
using View.ViewLauncher.FinancialAccountView;
using View.ViewLauncher.FinancialTransactionView;

namespace View.Views.FinancialTransaction
{
    public partial class FinancialTransactionIndex : Form, IFinancialTransactionIndex
    {
        private FinancialTransactionController _controller;
        private FinancialTransactionDto _selectedTransaction;
        private FinancialAccountDto _selectedAccount;
        private Guid _preSelectedTransactionId;
        private BindingSource _bs;
        private FinancialTransactionActionPane _actionPane;
        private IViewLauncher _eventRaiser;
        public IActionPane ActionPane { get { return _actionPane; } }

        public FinancialTransactionIndex(FinancialTransactionActionPane actionPane, IViewLauncher eventRaiser)
        {
            _eventRaiser = eventRaiser;
            _actionPane = actionPane;
            InitializeComponent();
            dgvTransactions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing; // required 1: or error thrown if mouse in wrong spot at wrong time http://stackoverflow.com/questions/14934003/system-invalidoperationexception-this-operation-cannot-be-performed-while-an-au
            InitializeControls();
            SubscribeToActionEvents();

        }

        public FinancialTransactionDto SelectedTransaction
        {
            get { return _selectedTransaction; }
            private set
            {
                _selectedTransaction = value;
                OnSelectedFinancialTransactionChanged();
            }
        }


        public void BindToFinancialAccount(FinancialAccountDto account, Guid preSelectedTransactionId) // should never be null
        {
            _preSelectedTransactionId = preSelectedTransactionId;
            _selectedAccount = account;
            _actionPane.AccountHolderName = string.Format("{0} {1}", account.FirstName, account.LastName);
            var transactions = _controller.GetTransactionsByAccount(account.Id);
            Initialize(transactions);


        }



        private void InitializeControls()
        {
            dgvTransactions.BorderStyle = BorderStyle.None;
            dgvTransactions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTransactions.MultiSelect = false;
            dgvTransactions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTransactions.ReadOnly = true;
        }




        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            dgvTransactions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize; // required 2: or error thrown if mouse in wrong spot at wrong time http://stackoverflow.com/questions/14934003/system-invalidoperationexception-this-operation-cannot-be-performed-while-an-au
        }

        private void DgvTransactions_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTransactions.SelectedRows.Count > 0)
            {
                var transaction = dgvTransactions.SelectedRows[0].DataBoundItem as FinancialTransactionDto;
                SelectedTransaction = transaction;
                //if(SelectedPatient != patient) { SelectedPatient = patient; }

            }
            else { SelectedTransaction = null; }


        }


        private void ActionPane_BackClicked(object sender, EventArgs e)
        {
            //_eventRaiser.Raise(new LaunchPatientIndexViewEvent(_selectedAccount.Id));
            _eventRaiser.Raise(new LaunchFinancialAccountDetailsViewEvent(_selectedAccount));

        }

        private void ActionPane_BtnAddFinancialTransaction_Click(object sender, EventArgs e)
        {
            _eventRaiser.Raise(new LaunchFinancialTransactionCreateViewEvent(_selectedAccount, _selectedTransaction));

        }



        private void ActionPane_BtnRemoveFinancialTransaction_Click(object sender, EventArgs e)
        {
            if (_selectedTransaction == null)
            {
                MessageBox.Show("Please select a transaction");
                return;
            }

            var result = _controller.RemoveFinancialTransaction(_selectedTransaction.Id,_selectedAccount.Id); // not async..see patient view (delete pt)

            if (result)
            {
                dgvTransactions.SelectionChanged -= DgvTransactions_SelectionChanged;
                UpdateFinancialTransactionsGrid(_controller.GetTransactionsByAccount(_selectedAccount.Id));
                dgvTransactions.SelectionChanged += DgvTransactions_SelectionChanged;
                dgvTransactions.ClearSelection();
                
            }
            this.Enabled = true;
        }

        private void ActionPane_BtnUpdateFinancialTransaction_Click(object sender, EventArgs e)
        {
            if (_selectedTransaction == null)
            {
                MessageBox.Show("Please select a medical history entry");
                return;
            }

            _eventRaiser.Raise(new LaunchFinancialTransactionEditViewEvent(_selectedAccount, _selectedTransaction));


            //using (var updatePatientDialog = new NewFinancialTransactionDialog()) // ensures dialog is disposed
            //{
            //    PopulateDialogWithFinancialTransactionInfo(updatePatientDialog, _selectedTransaction);
            //    updatePatientDialog.Save += UpdateFinancialTransactionDialog_Save;
            //    updatePatientDialog.ShowDialog();
            //}

        }



        private void Initialize(IEnumerable<FinancialTransactionDto> transaction)
        {
            UpdateFinancialTransactionsGrid(transaction);
            dgvTransactions.ClearSelection(); // clean slate
            SelectedTransaction = null;

        }

        public void UpdateFinancialTransactionsGrid(IEnumerable<FinancialTransactionDto> FinancialTransactions)
        {
            dgvTransactions.DataSource = null; // sometimes needed to refresh if changed
            _bs = new BindingSource();
            _bs.DataSource = FinancialTransactions;
            dgvTransactions.DataSource = _bs;

        }

        private void SubscribeToActionEvents()
        {
            //_actionPane.SearchDateChanged += SearchTextChanged;
            _actionPane.AddTransactionClicked += ActionPane_BtnAddFinancialTransaction_Click;
            _actionPane.RemoveTransactionClicked += ActionPane_BtnRemoveFinancialTransaction_Click;
            _actionPane.UpdateTransactionClicked += ActionPane_BtnUpdateFinancialTransaction_Click;
            _actionPane.BackClicked += ActionPane_BackClicked;

        }


        public void SetController(FinancialTransactionController controller)
        {
            _controller = controller;
        }

        //public event EventHandler SelectedPatientVisitChanged;

        protected virtual void OnSelectedFinancialTransactionChanged()
        {
            _actionPane.BindToFinancialTransaction(_selectedTransaction);
            //var handler = SelectedPatientVisitChanged;
            //if (handler != null) { handler.Invoke(this, EventArgs.Empty); }
        }


        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            dgvTransactions.ClearSelection();
            dgvTransactions.SelectionChanged += DgvTransactions_SelectionChanged;
            if (_preSelectedTransactionId != Guid.Empty)
            {
                var visits = (_bs.List as IEnumerable<FinancialTransactionDto>).ToList();
                var visit = visits.Where(v => v.Id == _preSelectedTransactionId).Single();
                var index = visits.IndexOf(visit);
                dgvTransactions.Rows[index].Selected = true;

            }

        }

    }
}
