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
using ValueObjects.Health;
using View.Dialog;
using View.Events;
using View.Events.Patient;
using View.Views.Patient;

namespace View.Views.Healthcard
{
    public partial class HealthcardView : Form //, IHealthcardView
    {
        private HealthcardController _controller;
        private PatientDto _patient;
        private HealthIdentificationDto _healthId;
        private PatientActionPane2 _actionPane;

        public HealthcardView(PatientActionPane2 actionPane, IEventListener<PatientSelectionChanged> eventListener)
        {
            eventListener.MessageReceived += PatientSelectionChanged;
            _actionPane = actionPane;
            InitializeComponent();
            SubscribeToActionEvents();
        }

        private void PatientSelectionChanged(PatientSelectionChanged e)
        {
            _patient = e.Patient;
            if (_patient == null)
            {
                healthcardControl1.Healthcard = new ValueObjects.Health.Healthcard();
            }
            else
            {
                _healthId = _controller.GetPatientHealthIdentification(_patient.Id);
                healthcardControl1.Healthcard = _healthId.Healthcard;

            }

        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            using (var updateHealthcardDialog = new NewPatientDialog()) // ensures dialog is disposed
            {
                updateHealthcardDialog.Text = "Update Healthcard Dialog";
                updateHealthcardDialog.Save += UpdateContactInfoDialog_Save;
                updateHealthcardDialog.ShowHealthcardTab = true;
                PopulateDialogWithHealthcard(updateHealthcardDialog, _healthId);
                updateHealthcardDialog.ShowDialog();
            }

        }

        private async void UpdateContactInfoDialog_Save(object sender, CancelEventArgs e)
        {
            var dialog = sender as NewPatientDialog;
            dialog.Enabled = false;
            e.Cancel = true; // let cmd result determine if dialog should close

            PopulateHealthIdDtoFromDialog(dialog, _healthId);

            var actionSucceeded = await Task.Run(() => _controller.UpdateHealthcard(_patient.Id, _healthId));
            if (actionSucceeded)
            {
                dialog.Close();
                healthcardControl1.Healthcard = _healthId.Healthcard;
            }
            else { dialog.Enabled = true; }

        }

        private void UpdatePersonalInfo(NewPatientDialog dialog)
        {
            PopulateHealthIdDtoFromDialog(dialog, _healthId);
            _controller.UpdateHealthcard(_patient.Id, _healthId);
            healthcardControl1.Healthcard = _healthId.Healthcard;
        }




        private void PopulateDialogWithHealthcard(NewPatientDialog dialog, HealthIdentificationDto healthId)
        {

            dialog.Healthcard = healthId.Healthcard;
        }



        private void PopulateHealthIdDtoFromDialog(NewPatientDialog dialog, HealthIdentificationDto healthId)
        {
            healthId.Healthcard = dialog.Healthcard;
        }




        public void BindToPatient(PatientDto patient)
        {
            _patient = patient;
            if (patient == null)
            {
                healthcardControl1.Healthcard = new ValueObjects.Health.Healthcard();
            }
            else
            {
                _healthId = _controller.GetPatientHealthIdentification(patient.Id);
                healthcardControl1.Healthcard = _healthId.Healthcard;

            }
        }


        private void SubscribeToActionEvents()
        {
            _actionPane.UpdateHealthcardClicked += BtnEdit_Click;

        }

        public void SetController(HealthcardController controller)
        {
            _controller = controller;
        }
    }
}
