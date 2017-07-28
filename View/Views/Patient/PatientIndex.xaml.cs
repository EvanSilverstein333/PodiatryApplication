using Controllers.Controllers;
using Controllers.ViewInterfaces;
using Controllers.ViewInterfaces.Patient;
using FinanceManager.Contract.Dto;
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
using View.Events;
using View.Events.Orchestrator.UpdateHostViewRequested;
using View.Events.Patient;
using View.ViewLauncher;
using View.ViewLauncher.ContactInformation;
using View.ViewLauncher.FinancialAccountView;
using View.ViewLauncher.HealthcardView;
using View.ViewLauncher.PatientView;
using View.ViewLauncher.PatientVisitView;

namespace View.Views.Patient
{
    /// <summary>
    /// Interaction logic for PatientIndex.xaml
    /// </summary>
    public partial class PatientIndex : UserControl, IPatientIndex
    {
        private PatientController _controller;
        //private BindingSource _bs;
        private Guid _preSelectedPatientId;
        private PatientDto _selectedPatient;
        private PatientActionPane _actionPane;
        private IViewLauncher _eventRaiser;
        private IEventPublisher<PatientSelectionChanged> _patientChangedEventPublisher;
        private IEventPublisher<UpdateOrchestratorViewRequested> _updateOrchestratorViewEventPublisher;

        public IActionPane ActionPane { get { return _actionPane; } }
        public bool IsDisposed { get; private set; }

        public PatientIndex(PatientActionPane actionPane, IViewLauncher eventRaiser, IEventPublisher<PatientSelectionChanged> patientChangedEvnetPublisher, IEventPublisher<UpdateOrchestratorViewRequested> updateOrchestratorViewEventPublisher)
        {
            _patientChangedEventPublisher = patientChangedEvnetPublisher;
            _updateOrchestratorViewEventPublisher = updateOrchestratorViewEventPublisher;
            _eventRaiser = eventRaiser;
            _actionPane = actionPane;
            InitializeComponent();
            //dgvPatients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing; // required 1: or error thrown if mouse in wrong spot at wrong time http://stackoverflow.com/questions/14934003/system-invalidoperationexception-this-operation-cannot-be-performed-while-an-au
            InitializeControls();
            SubscribeToActionEvents();
            Text = "Patients";
        }

        public string Text { get; set; }
        public PatientDto[] Patients { get; private set; }

        public PatientDto SelectedPatient
        {
            get { return _selectedPatient; }
            private set
            {
                _selectedPatient = value;
                OnSelectedPatientChanged();
            }
        }

        private void SelectPatient(Guid id)
        {
            var patients = dgvPatients.ItemsSource as IEnumerable<PatientDto>;
            var patient = patients.Where(pt => pt.Id == id).Single();
            dgvPatients.SelectedItem = patient;
        }

        private void InitializeControls()
        {
            colFirstName.Binding = new Binding(nameof(_selectedPatient.FirstName));
            colLastName.Binding = new Binding(nameof(_selectedPatient.LastName));
            colDateOfBirth.Binding = new Binding(nameof(_selectedPatient.DateOfBirth))
            {
                StringFormat = @"dd / MM / yyyy"
            };

            colGender.Binding = new Binding(nameof(_selectedPatient.Gender));
        }

        public void Initialize(Guid patientId)
        {
            dgvPatients.SelectionChanged -= DgvPatients_SelectionChanged;
            _preSelectedPatientId = patientId;
            var patients = _controller.GetAllPatients();
            BindToPatientGrid(patients);
            dgvPatients.SelectionChanged += DgvPatients_SelectionChanged;
            if(patientId != Guid.Empty)
            {
                SelectPatient(patientId);
            }
            else { SelectedPatient = null; }
            //dgvPatients.ClearSelection(); // clean slate
            //var defaultSelection = if(_preSelectedPatientId != Guid.Empty)? SelectPatient()
            //SelectedPatient = null;

        }


        //protected override void OnLoad(EventArgs e)
        //{
        //    base.OnLoad(e);
        //    dgvPatients.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize; // required 2: or error thrown if mouse in wrong spot at wrong time http://stackoverflow.com/questions/14934003/system-invalidoperationexception-this-operation-cannot-be-performed-while-an-au
        //}


        private void DgvPatients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgvPatients.SelectedItems.Count > 0)
            {
                var patient = dgvPatients.SelectedItem as PatientDto;
                SelectedPatient = patient;

            }
            else { SelectedPatient = null; }
        }

        //private void DgvPatients_SelectionChanged(object sender, EventArgs e)
        //{
        //    if (dgvPatients.SelectedItems.Count > 0)
        //    {
        //        var patient = dgvPatients.SelectedItem as PatientDto;
        //        SelectedPatient = patient;

        //    }
        //    else { SelectedPatient = null; }


        //}




        public void BindToPatientGrid(IEnumerable<PatientDto> patients)
        {
            //Patients = patients.ToArray();
            dgvPatients.ItemsSource = null; // sometimes needed to refresh if changed
            dgvPatients.ItemsSource = patients;


            //_bs = new BindingSource();
            //_bs.DataSource = patients;
            //dgvPatients.ItemsSource = patients;


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
                dgvPatients.SelectedItem = null;
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
            if (SelectedPatient == null) { MessageBox.Show("please select a patient"); }
            else
            {
                _eventRaiser.Raise(new LaunchPatientVisitIndexViewEvent(_selectedPatient));
                _updateOrchestratorViewEventPublisher.Publish(new UpdateOrchestratorViewRequested(null, _selectedPatient != null));

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
                //_updateOrchestratorViewEventPublisher.Publish(new UpdateOrchestratorViewRequested(null, _selectedPatient != null));


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





        protected virtual void OnSelectedPatientChanged()
        {
            _patientChangedEventPublisher.Publish(new PatientSelectionChanged(_selectedPatient));
            _updateOrchestratorViewEventPublisher.Publish(new UpdateOrchestratorViewRequested(null, _selectedPatient != null));
            _actionPane.BindToPatient(_selectedPatient);
        }


    }
}
