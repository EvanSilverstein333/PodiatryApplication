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
using View.Dialog;
using View.Views;
using PatientManager.Contract.Dto;
using Controllers.ViewInterfaces.Patient;
using FinanceManager.Contract.Dto;


namespace View.Views.Patient
{
    public partial class PatientActionPane2 : Form//, IPatientActionPane
    {
        //private IControllerEventProcessor _eventRaiser;
        //private PatientDto _selectedPatient;


        public PatientActionPane2()
        {
            //_eventRaiser = eventRaiser;
            InitializeComponent();
            btnAddPatient.Click += BtnAddPatient_Click;
            btnRemovePatient.Click += BtnRemovePatient_Click;
            btnUpdateIdentity.Click += BtnUpdateIdentity_Click;
            btnUpdateContactInfo.Click += BtnUpdateContactInfo_Click;
            btnUpdateHealthcard.Click += BtnUpdateHealthcard_Click;
            searchBox.TextChanged += SearchBox_TextChanged;
            btnSeePatientVisits.Click += BtnSeePatientVisits_Click;
            btnSeeFinances.Click += BtnSeeFinances_Click;
            
        }

        public string SearchText
        {
            get { return searchBox.Text; }
            set { searchBox.Text = value; }
        }

        private void BtnSeeFinances_Click(object sender, EventArgs e)
        {
            //var account = new FinancialAccountDto()
            //{
            //    Id = _selectedPatient.Id,
            //    FirstName = _selectedPatient.FirstName,
            //    LastName = _selectedPatient.LastName,
            //};
            //_eventRaiser.Raise(new LaunchFinancialTransactionIndexViewEvent(account));

            var handler = SeeFinancesClicked;
            if (handler != null) { handler.Invoke(this, EventArgs.Empty); }

        }

        private void BtnSeePatientVisits_Click(object sender, EventArgs e)
        {
            //_eventRaiser.Raise(new LaunchPatientVisitIndexViewEvent(_selectedPatient));
            var handler = SeePatientVisitsClicked;
            if (handler != null) { handler.Invoke(this, EventArgs.Empty); }

        }

        private void SearchBox_TextChanged(object sender, EventArgs e)
        {

            var handler = SearchTextChanged;
            if (handler != null) { handler.Invoke(this, EventArgs.Empty); }

        }

        private void BtnUpdateHealthcard_Click(object sender, EventArgs e)
        {
            var handler = UpdateHealthcardClicked;
            if (handler != null) { handler.Invoke(this, EventArgs.Empty); }
        }

        private void BtnUpdateContactInfo_Click(object sender, EventArgs e)
        {
            var handler = UpdateContactInformationClicked;
            if (handler != null) { handler.Invoke(this, EventArgs.Empty); }

        }

        private void BtnUpdateIdentity_Click(object sender, EventArgs e)
        {
            var handler = UpdateIdentityClicked;
            if (handler != null) { handler.Invoke(this, EventArgs.Empty); }

        }

        private void BtnRemovePatient_Click(object sender, EventArgs e)
        {
            var handler = RemovePatientClicked;
            if (handler != null) { handler.Invoke(this, EventArgs.Empty); }

        }

        private void BtnAddPatient_Click(object sender, EventArgs e)
        {
            var handler = AddPatientClicked;
            if (handler != null) { handler.Invoke(this, EventArgs.Empty); }
        }

        public void BindToPatient(PatientDto patient)
        {
            //_selectedPatient = patient;
            panelPatientDetails.Visible = (patient != null);
            lblPatientName.Text = (patient == null)? null: string.Format("{0} {1}",patient.FirstName, patient.LastName);
        }

        //public void SetPatientLabel(string firstName, string lastName)
        //{
        //    lblPatientName.Text = name;
        //}

        public event EventHandler AddPatientClicked;
        public event EventHandler RemovePatientClicked;
        public event EventHandler UpdateIdentityClicked;
        public event EventHandler UpdateContactInformationClicked;
        public event EventHandler UpdateHealthcardClicked;
        public event EventHandler SearchTextChanged;
        public event EventHandler SeePatientVisitsClicked;
        public event EventHandler SeeFinancesClicked;


    }
}
