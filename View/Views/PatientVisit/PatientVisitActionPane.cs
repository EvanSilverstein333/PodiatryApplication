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
using Controllers.ViewInterfaces.PatientVisit;

namespace View.Views.PatientVisit
{
    public partial class PatientVisitActionPane : Form, IPatientVisitActionPane
    {

        public PatientVisitActionPane()
        {
            InitializeComponent();
            btnAddPatientVisit.Click += BtnAddPatientVisit_Click;
            btnRemovePatientVisit.Click += BtnRemovePatientVisit_Click;
            btnUpdatePatientVisit.Click += BtnUpdatePatientVisit_Click;
            searchDate.ValueChanged += SearchDate_ValueChanged;
            btnBackToPatients.Click += BtnBackToPatients_Click;

        }



        public string PatientName
        {
            get { return lblPatientName.Text; }
            set { lblPatientName.Text = value; }
        }
       
        public DateTime? SearchText
        {
            get { return searchDate.Value; }
            set { searchDate.Value = value; }
        }

        private void BtnBackToPatients_Click(object sender, EventArgs e)
        {
            var handler = BackClicked;
            if (handler != null) { handler.Invoke(this, EventArgs.Empty); }

        }
        private void SearchDate_ValueChanged(object sender, EventArgs e)
        {
            var handler = SearchDateChanged;
            if (handler != null) { handler.Invoke(this, EventArgs.Empty); }

        }


        private void BtnUpdatePatientVisit_Click(object sender, EventArgs e)
        {
            var handler = UpdatePatientVisitClicked;
            if (handler != null) { handler.Invoke(this, EventArgs.Empty); }

        }

        private void BtnRemovePatientVisit_Click(object sender, EventArgs e)
        {
            var handler = RemovePatientVisitClicked;
            if (handler != null) { handler.Invoke(this, EventArgs.Empty); }

        }

        private void BtnAddPatientVisit_Click(object sender, EventArgs e)
        {
            var handler = AddPatientVisitClicked;
            if (handler != null) { handler.Invoke(this, EventArgs.Empty); }
        }

        public void BindToPatientVisit(PatientVisitDto patientVisit)
        {
            panelPatientVisitDetails.Visible = (patientVisit != null);
            lblDateOfVisit.Text = (patientVisit == null) ? null : string.Format("{0}", patientVisit.Date);
        }

        //public void SetPatientLabel(string firstName, string lastName)
        //{
        //    lblPatientName.Text = name;
        //}

        public event EventHandler AddPatientVisitClicked;
        public event EventHandler RemovePatientVisitClicked;
        public event EventHandler UpdatePatientVisitClicked;
        public event EventHandler SearchDateChanged;
        public event EventHandler BackClicked;

    }
}
