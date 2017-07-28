using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View.Dialogs
{
    public partial class NewFinancialAccountDialog : Form
    {
        public NewFinancialAccountDialog()
        {
            InitializeComponent();
            InitializeControls();
        }

        public void InitializeControls()
        {

            btnSave.Click += BtnSave_Click; // for external validation
            btnCancel.Click += BtnCancel_Click;

        }



        private void BtnSave_Click(object sender, EventArgs e)
        {
            OnSave();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            OnCancel();
        }


        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string FirstName
        {
            get { return inputFirstName.Text; }
            set { inputFirstName.Text = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string LastName
        {
            get { return inputLastName.Text; }
            set { inputLastName.Text = value; }
        }


        public event CancelEventHandler Save;
        public event CancelEventHandler Cancel;

        protected void OnSave()
        {
            var e = new CancelEventArgs(false);
            var handler = Save;
            if (handler != null) { handler.Invoke(this, e); }

            this.DialogResult = (e.Cancel) ? DialogResult.None : DialogResult.OK;


        }

        protected void OnCancel()
        {
            var e = new CancelEventArgs(false);
            var handler = Cancel;
            if (handler != null) { handler.Invoke(this, e); }

            this.DialogResult = (e.Cancel) ? DialogResult.None : DialogResult.Cancel;

        }

    }
}
