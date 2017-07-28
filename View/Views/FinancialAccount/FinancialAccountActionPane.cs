using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinanceManager.Contract.Dto;
using Controllers.ViewInterfaces;
using Controllers.ViewInterfaces.FinancialAccount;

namespace View.Views.FinancialAccount
{
    public partial class FinancialAccountActionPane : Form, IFinancialAccountActionPane
    {

        public FinancialAccountActionPane()
        {
            InitializeComponent();
            btnViewFinancialTransactions.Click += BtnViewFinancialAccount_Click;
            btnMakePayment.Click += BtnMakePayment_Click;
            btnChargeAccount.Click += BtnChargeAccount_Click;
            btnBack.Click += BtnBack_Click;

        }



        private void BtnMakePayment_Click(object sender, EventArgs e)
        {
            var handler = MakePaymentClicked;
            if (handler != null) { handler.Invoke(this, EventArgs.Empty); }

        }

        private void BtnChargeAccount_Click(object sender, EventArgs e)
        {
            var handler = ChargeAccountClicked;
            if (handler != null) { handler.Invoke(this, EventArgs.Empty); }

        }


        private void BtnViewFinancialAccount_Click(object sender, EventArgs e)
        {
            var handler = ViewFinancialTransactionsClicked;
            if (handler != null) { handler.Invoke(this, EventArgs.Empty); }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            var handler = BackClicked;
            if (handler != null) { handler.Invoke(this, EventArgs.Empty); }
        }



        public event EventHandler ViewFinancialTransactionsClicked;
        public event EventHandler MakePaymentClicked;
        public event EventHandler ChargeAccountClicked;
        public event EventHandler BackClicked;
    }
}
