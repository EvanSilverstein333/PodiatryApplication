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
using ValueObjects.ContactInformation;
using View.Dialog;
using View.Events.Patient;
using View.Events;
using View.Views.Patient;

namespace View.Views.ContactInformation
{
    public partial class ContactInformationView : Form//, IContactInformationView
    {
        private ContactInformationController _controller;
        private PatientDto _patient;
        private ContactInfoDto _contactInfo;
        private PatientActionPane2 _actionPane;
        //private IEventListener<PatientSelectionChanged> _eventListener;

        public ContactInformationView(PatientActionPane2 actionPane, IEventListener<PatientSelectionChanged> eventListener)
        {
            //_eventListener = eventListener;
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
                contactInfoControl1.Address = new Address();
            }
            else
            {
                _contactInfo = _controller.GetPatientContactInfo(_patient.Id);
                contactInfoControl1.Address = _contactInfo.Address;

            }

        }


        private void SubscribeToActionEvents()
        {
            _actionPane.UpdateContactInformationClicked += BtnEdit_Click;

        }


        private void BtnEdit_Click(object sender, EventArgs e)
        {
            using (var updateContactInfoDialog = new NewPatientDialog()) // ensures dialog is disposed
            {
                updateContactInfoDialog.Text = "Update ContactInfo Dialog";
                updateContactInfoDialog.Save += UpdateContactInfoDialog_Save;
                updateContactInfoDialog.ShowContactInfoTab = true;
                PopulateDialogWithContactInfo(updateContactInfoDialog, _contactInfo);
                updateContactInfoDialog.ShowDialog();
            }

        }

        private async void UpdateContactInfoDialog_Save(object sender, CancelEventArgs e)
        {
            var dialog = sender as NewPatientDialog;
            dialog.Enabled = false;
            e.Cancel = true; // let cmd result determine if dialog should close

            PopulateContactInfoDtoFromDialog(dialog, _contactInfo);

            var actionSucceeded = await Task.Run(() => _controller.UpdatePatientContactInfo(_patient.Id, _contactInfo));
            if (actionSucceeded)
            {
                dialog.Close();
                contactInfoControl1.Address = _contactInfo.Address;
                contactInfoControl1.PrimaryPhoneNumber = _contactInfo.PrimaryPhoneNumber;
                contactInfoControl1.SecondaryPhoneNumber = _contactInfo.SecondaryPhoneNumber;
                contactInfoControl1.Email = _contactInfo.Email;
            }
            else { dialog.Enabled = true; }

        }

        private void PopulateDialogWithContactInfo(NewPatientDialog dialog, ContactInfoDto contactInfo)
        {

            dialog.Address = contactInfo.Address;
            dialog.PrimaryPhoneNumber = contactInfo.PrimaryPhoneNumber;
            dialog.SecondaryPhoneNumber = contactInfo.SecondaryPhoneNumber;
            dialog.Email = contactInfo.Email;

        }


        private void PopulateContactInfoDtoFromDialog(NewPatientDialog dialog, ContactInfoDto contactInfo)
        {

            contactInfo.Address = dialog.Address;
            contactInfo.PrimaryPhoneNumber = dialog.PrimaryPhoneNumber;
            contactInfo.SecondaryPhoneNumber = dialog.SecondaryPhoneNumber;
            contactInfo.Email = dialog.Email;

        }


        public void SetController(ContactInformationController controller)
        {
            _controller = controller;
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing && (components != null))
        //    {
        //        components.Dispose();
        //        _eventPublisher.Reset();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
