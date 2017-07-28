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
using PatientManager.Contract.Dto;
using View.Dialog;
using FinanceManager.Contract.Dto;
using View.Events.Patient;
using View.Events;
using Controllers.ViewInterfaces.Patient;
using View.ViewLauncher;
using View.ViewLauncher.PatientView;
using View.ViewLauncher.ContactInformation;
using View.ViewLauncher.HealthcardView;
using View.ViewLauncher.PatientVisitView;
using View.ViewLauncher.FinancialAccountView;

namespace View.Views.Patient
{
    public partial class PatientIndex2 : Form//, IPatientIndex
    {
        private PatientController _controller;
        private BindingSource _bs;
        private Guid _preSelectedPatientId;
        private PatientDto _selectedPatient;
        private PatientActionPane _actionPane;
        private IViewLauncher _eventRaiser;
        private IEventPublisher<PatientSelectionChanged> _eventPublisher;


        public IActionPane ActionPane { get { return _actionPane; } }


        public PatientIndex2(PatientActionPane actionPane, IViewLauncher eventRaiser, IEventPublisher<PatientSelectionChanged> eventPublisher)
        {
            _eventPublisher = eventPublisher;
            _eventRaiser = eventRaiser;
            _actionPane = actionPane;
            InitializeComponent();
            dgvPatients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing; // required 1: or error thrown if mouse in wrong spot at wrong time http://stackoverflow.com/questions/14934003/system-invalidoperationexception-this-operation-cannot-be-performed-while-an-au
            InitializeControls();
            SubscribeToActionEvents();
            Text = "Patients";
        }


        public PatientDto SelectedPatient
        {
            get { return _selectedPatient; }
            private set
            {
                _selectedPatient = value;
                OnSelectedPatientChanged();
            }
        }


        private void InitializeControls()
        {
            dgvPatients.BorderStyle = BorderStyle.None;
            dgvPatients.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPatients.MultiSelect = false;
            dgvPatients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPatients.ReadOnly = true;
            dgvPatients.RowHeadersVisible = false;

        }


        public void Initialize(Guid patientId)
        {
            _preSelectedPatientId = patientId;
            var patients = _controller.GetAllPatients();
            BindToPatientGrid(patients);
            //dgvPatients.ClearSelection(); // clean slate
            SelectedPatient = null;

        }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            dgvPatients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize; // required 2: or error thrown if mouse in wrong spot at wrong time http://stackoverflow.com/questions/14934003/system-invalidoperationexception-this-operation-cannot-be-performed-while-an-au
        }


        
        private void DgvPatients_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvPatients.SelectedRows.Count>0)
            {
                var patient = dgvPatients.SelectedRows[0].DataBoundItem as PatientDto;
                SelectedPatient = patient;
                
            }
            else { SelectedPatient = null; }


        }


 

        public void BindToPatientGrid(IEnumerable<PatientDto> patients)
        {
            dgvPatients.DataSource = null; // sometimes needed to refresh if changed
            _bs = new BindingSource();
            _bs.DataSource = patients;
            dgvPatients.DataSource = _bs;


        }


        private void ActionPane_SearchTextChanged(object sender, EventArgs e)
        {
            var patients = _controller.FindPatientsByName(_actionPane.SearchText);
            BindToPatientGrid(patients);
        }



        private void ActionPane_BtnAddPatient(object sender, EventArgs e)
        {
            _eventRaiser.Raise(new LaunchPatientCreateViewEvent(null));

        }

        private void ActionPane_BtnUpdatePatient(object sender, EventArgs e)
        {
            if (_selectedPatient == null)
            {
                MessageBox.Show("Please select a patient");
                return;
            }

            _eventRaiser.Raise(new LaunchPatientEditViewEvent(_selectedPatient));

        }


        private void ActionPane_BtnRemovePatient(object sender, EventArgs e)
        {
            if (_selectedPatient == null)
            {
                MessageBox.Show("Please select a patient");
                return;
            }
            var actionSucceeded = _controller.RemovePatient(_selectedPatient.Id); // not async: otherewise errors might arise if update props of a pt in the process of being removed
            if (actionSucceeded)
            {
                dgvPatients.SelectionChanged -= DgvPatients_SelectionChanged;
                BindToPatientGrid(_controller.GetAllPatients());
                dgvPatients.SelectionChanged += DgvPatients_SelectionChanged;
                dgvPatients.ClearSelection();
                SelectedPatient = null;
            }
        }

        private void ActionPane_UpdateContactInformationClicked(object sender, EventArgs e)
        {
            var launchContactInfoEditView = new LaunchContactInformationViewEditEvent(_selectedPatient);
            _eventRaiser.Raise(launchContactInfoEditView);

        }

        private void ActionPane_UpdateHealthcardClicked(object sender, EventArgs e)
        {
            var launchHealthcardEditView = new LaunchHealthcardViewEditEvent(_selectedPatient);
            _eventRaiser.Raise(launchHealthcardEditView);

        }


        private void ActionPane_SeePatientVisitsClicked(object sender, EventArgs e)
        {
            if(SelectedPatient == null) { MessageBox.Show("please select a patient"); }
            else
            {
                _eventRaiser.Raise(new LaunchPatientVisitIndexViewEvent(_selectedPatient));
            }
        }

        private void ActionPane_SeeFinancesClicked(object sender, EventArgs e)
        {
            if (SelectedPatient == null) { MessageBox.Show("please select a patient"); }
            else
            {
                var account = new FinancialAccountDto() // account may not exist so need to pass info
                {
                    Id = _selectedPatient.Id,
                    FirstName = _selectedPatient.FirstName,
                    LastName = _selectedPatient.LastName,
                };
                _eventRaiser.Raise(new LaunchFinancialAccountDetailsViewEvent(account)); 

            }


        }



        public void SetController(PatientController controller)
        {
            _controller = controller;
        }

        private void SubscribeToActionEvents()
        {
            _actionPane.SearchTextChanged += ActionPane_SearchTextChanged;
            _actionPane.AddPatientClicked += ActionPane_BtnAddPatient;
            _actionPane.RemovePatientClicked += ActionPane_BtnRemovePatient;
            _actionPane.UpdateIdentityClicked += ActionPane_BtnUpdatePatient;
            _actionPane.UpdateContactInformationClicked += ActionPane_UpdateContactInformationClicked;
            _actionPane.UpdateHealthcardClicked += ActionPane_UpdateHealthcardClicked;
            _actionPane.SeeMedicalHistoryClicked += ActionPane_SeePatientVisitsClicked;
            _actionPane.SeeFinancesClicked += ActionPane_SeeFinancesClicked;
         
            
        }



        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            dgvPatients.ClearSelection();
            dgvPatients.SelectionChanged += DgvPatients_SelectionChanged;
            if(_preSelectedPatientId != Guid.Empty)
            {
                var patients = (_bs.List as IEnumerable<PatientDto>).ToList();
                var patient = patients.Where(pt => pt.Id == _preSelectedPatientId).Single();
                var index = patients.IndexOf(patient);
                dgvPatients.Rows[index].Selected = true;

            }
        }


        protected virtual void OnSelectedPatientChanged()
        {
            _eventPublisher.Publish(new PatientSelectionChanged(_selectedPatient));
            //UpdateHostViewRequest(_selectedPatient);
            _actionPane.BindToPatient(_selectedPatient);
        }


        //public void UpdateHostViewRequest(PatientDto patient)
        //{
        //    var caption = (patient == null) ? "" : string.Format("{0} {1}", patient.FirstName, patient.LastName);
        //    var showDetails = patient != null;
        //    _eventRaiser.Raise(new UpdateHostViewRequestedEvent(caption, showDetails));
        //}

        protected override void Dispose(bool disposing)
        {
            _eventPublisher.Reset();
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }



    }
}
