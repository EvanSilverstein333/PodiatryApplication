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
using Controllers.ViewInterfaces.PatientVisit;
using View.ViewLauncher;
using View.ViewLauncher.PatientVisitView;
using View.ViewLauncher.PatientView;

namespace View.Views.PatientVisit
{
    public partial class PatientVisitIndex : Form, IPatientVisitIndex
    {
        private PatientVisitController _controller;
        private PatientVisitDto _selectedVisit;
        private PatientDto _selectedPatient;
        private PatientVisitActionPane _actionPane;
        private IViewLauncher _eventRaiser;
        private BindingSource _bs;
        private Guid _preSelectedVisitId;
        

        public IActionPane ActionPane { get { return _actionPane; } }


        public PatientVisitIndex(PatientVisitActionPane actionPane, IViewLauncher eventRaiser)
        {
            _eventRaiser = eventRaiser;
            _actionPane = actionPane;
            InitializeComponent();
            dgvPatientVisits.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing; // required 1: or error thrown if mouse in wrong spot at wrong time http://stackoverflow.com/questions/14934003/system-invalidoperationexception-this-operation-cannot-be-performed-while-an-au
            InitializeControls();
            SubscribeToActionEvents();
            Text = "Medical History";
        }


        public PatientVisitDto SelectedVisit
        {
            get { return _selectedVisit; }
            private set
            {
                _selectedVisit = value;
                OnSelectedPatientVisitChanged();
            }
        }


        public void BindToPatient(PatientDto patient, Guid preSelectedVisitId)
        {
            _preSelectedVisitId = preSelectedVisitId;
            _selectedPatient = patient;
            _actionPane.PatientName = string.Format("{0} {1}", patient.FirstName, patient.LastName);
            var visits = _controller.GetVisitsByPatient(patient.Id);
            Initialize(visits);


        }



        private void InitializeControls()
        {
            dgvPatientVisits.BorderStyle = BorderStyle.None;
            dgvPatientVisits.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPatientVisits.MultiSelect = false;
            dgvPatientVisits.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPatientVisits.ReadOnly = true;
        }


       

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            dgvPatientVisits.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize; // required 2: or error thrown if mouse in wrong spot at wrong time http://stackoverflow.com/questions/14934003/system-invalidoperationexception-this-operation-cannot-be-performed-while-an-au
        }

        private void DgvPatientVisits_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPatientVisits.SelectedRows.Count > 0)
            {
                var visit = dgvPatientVisits.SelectedRows[0].DataBoundItem as PatientVisitDto;
                SelectedVisit = visit;
                //if(SelectedPatient != patient) { SelectedPatient = patient; }

            }
            else { SelectedVisit = null; }


        }


        private void BtnAddPatientVisit_Click(object sender, EventArgs e)
        {
            var defaultProperties = new PatientVisitDto()
            {
                Date = DateTime.Now
            };
            _eventRaiser.Raise(new LaunchPatientVisitCreateViewEvent(defaultProperties, _selectedPatient));

        }



        private void BtnRemovePatientVisit_Click(object sender, EventArgs e)
        {
            if(_selectedVisit == null)
            {
                MessageBox.Show("Please select a medical history entry");
                return;
            }

            var result = _controller.RemovePatientVisit(_selectedVisit.Id); // not async..see patient view (delete pt)

            if (result)
            {
                dgvPatientVisits.SelectionChanged -= DgvPatientVisits_SelectionChanged;
                UpdatePatientVisitsGrid(_controller.GetVisitsByPatient(_selectedPatient.Id));
                dgvPatientVisits.SelectionChanged += DgvPatientVisits_SelectionChanged;
                dgvPatientVisits.ClearSelection();
            }
            this.Enabled = true;
        }

        private void BtnUpdatePatientVisit_Click(object sender, EventArgs e)
        {
            if (_selectedVisit == null)
            {
                MessageBox.Show("Please select a medical history entry");
                return;
            }
            _eventRaiser.Raise(new LaunchPatientVisitEditViewEvent(_selectedVisit, _selectedPatient));


        }




        private void PopulateDialogWithPatientVisitInfo(NewPatientVisitDialog dialog, PatientVisitDto visit)
        {
            dialog.PatientName = string.Format("{0} {1}", _selectedPatient.FirstName, _selectedPatient.LastName);
            dialog.Date = (visit.Date == null)? DateTime.Now : visit.Date.Value; 
            dialog.Diagnosis = visit.Diagnosis;
            dialog.Notes = visit.Notes;
        }

        private void PopulatePatientVisitDtoFromDialog(NewPatientVisitDialog dialog, PatientVisitDto visit)
        {
            //visit.PatientFullName = dialog.PatientName;
            visit.Date = dialog.Date;
            visit.Diagnosis = dialog.Diagnosis;
            visit.Notes = dialog.Notes;
            
        }


        private void Initialize(IEnumerable<PatientVisitDto> visits)
        {
            UpdatePatientVisitsGrid(visits);
            dgvPatientVisits.ClearSelection(); // clean slate
            SelectedVisit = null;

        }

        public void UpdatePatientVisitsGrid(IEnumerable<PatientVisitDto> patientVisits)
        {
            dgvPatientVisits.DataSource = null; // sometimes needed to refresh if changed
            _bs = new BindingSource();
            _bs.DataSource = patientVisits;
            dgvPatientVisits.DataSource = _bs;
        }

        private void SubscribeToActionEvents()
        {
            //_actionPane.SearchDateChanged += SearchTextChanged;
            _actionPane.AddPatientVisitClicked += BtnAddPatientVisit_Click;
            _actionPane.RemovePatientVisitClicked += BtnRemovePatientVisit_Click;
            _actionPane.UpdatePatientVisitClicked += BtnUpdatePatientVisit_Click;
            _actionPane.BackClicked += BackClicked;

        }

        private void BackClicked(object sender, EventArgs e)
        {
            _eventRaiser.Raise(new LaunchPatientIndexViewEvent(_selectedPatient.Id));

        }

        public void SetController(PatientVisitController controller)
        {
            _controller = controller;
        }

        //public event EventHandler SelectedPatientVisitChanged;

        protected virtual void OnSelectedPatientVisitChanged()
        {
            _actionPane.BindToPatientVisit(_selectedVisit);
            //var handler = SelectedPatientVisitChanged;
            //if (handler != null) { handler.Invoke(this, EventArgs.Empty); }
        }


        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            dgvPatientVisits.ClearSelection();
            dgvPatientVisits.SelectionChanged += DgvPatientVisits_SelectionChanged;
            if (_preSelectedVisitId != Guid.Empty)
            {
                var visits = (_bs.List as IEnumerable<PatientVisitDto>).ToList();
                var visit = visits.Where(v => v.Id == _preSelectedVisitId).Single();
                var index = visits.IndexOf(visit);
                dgvPatientVisits.Rows[index].Selected = true;

            }


        }


    }
}
