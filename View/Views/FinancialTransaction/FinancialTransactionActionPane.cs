using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PatientManager.Contract.Dto;
using Controllers.ViewInterfaces;
using FinanceManager.Contract.Dto;
using Controllers.ViewInterfaces.FinancialTransaction;

namespace View.Views.FinancialTransaction
{
    public partial class FinancialTransactionActionPane : Form, IFinancialTransactionActionPane
    {

        public FinancialTransactionActionPane()
        {
            InitializeComponent();
            btnAddTransaction.Click += BtnAddTransaction_Click;
            btnRemoveTransaction.Click += BtnRemoveTransaction_Click;
            btnUpdateTransaction.Click += BtnUpdateTransaction_Click;
            searchDate.ValueChanged += SearchDate_ValueChanged;
            btnBack.Click += BtnBack_Click;

        }



        public string AccountHolderName
        {
            get { return lblAccountHolderName.Text; }
            set { lblAccountHolderName.Text = value; }
        }
       
        public DateTime? SearchDate
        {
            get { return searchDate.Value; }
            set { searchDate.Value = value; }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            var handler = BackClicked;
            if (handler != null) { handler.Invoke(this, EventArgs.Empty); }

        }
        private void SearchDate_ValueChanged(object sender, EventArgs e)
        {
            var handler = SearchDateChanged;
            if (handler != null) { handler.Invoke(this, EventArgs.Empty); }

        }


        private void BtnUpdateTransaction_Click(object sender, EventArgs e)
        {
            var handler = UpdateTransactionClicked;
            if (handler != null) { handler.Invoke(this, EventArgs.Empty); }

        }

        private void BtnRemoveTransaction_Click(object sender, EventArgs e)
        {
            var handler = RemoveTransactionClicked;
            if (handler != null) { handler.Invoke(this, EventArgs.Empty); }

        }

        private void BtnAddTransaction_Click(object sender, EventArgs e)
        {
            var handler = AddTransactionClicked;
            if (handler != null) { handler.Invoke(this, EventArgs.Empty); }
        }

        public void BindToFinancialTransaction(FinancialTransactionDto transaction)
        {
            panelTransactionDetails.Visible = (transaction != null);
            lblDateOfVisit.Text = (transaction == null) ? null : string.Format("{0}", transaction.Date);
        }



        public event EventHandler AddTransactionClicked;
        public event EventHandler RemoveTransactionClicked;
        public event EventHandler UpdateTransactionClicked;
        public event EventHandler SearchDateChanged;
        public event EventHandler BackClicked;

    }
}
