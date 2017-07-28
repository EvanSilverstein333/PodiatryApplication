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
using Controllers.ViewInterfaces.Patient;
using Controllers.Controllers;
using View.ViewLauncher;
using View.ViewLauncher.PatientView;

namespace View.Views.Patient
{
    /// <summary>
    /// Interaction logic for PatientCreate.xaml
    /// </summary>
    public partial class PatientCreate : UserControl, IPatientCreate
    {
        private PatientController _controller;
        //private PatientDto _patient;
        private IViewLauncher _eventRaiser;
        
        public string Text { get; set; }
        public bool IsDisposed { get; private set; }


        public PatientCreate(IViewLauncher eventRaiser)
        {
            _eventRaiser = eventRaiser;
            InitializeComponent();
        }

        public void BindToPatient(PatientDto defaultPatientProperties)
        {
            var patient = (defaultPatientProperties != null) ? defaultPatientProperties : new PatientDto();
            SetInitialInputValues(patient);
        }

        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            {

                var patient = new PatientDto(Guid.NewGuid());
                var contactInfo = new ContactInfoDto();
                var healthId = new HealthIdentificationDto();

                SetPatientProperties(patient);
                //PopulatePatientDtoFromDialog(dialog, patient);
                //PopulateContactInfoDtoFromDialog(dialog, contactInfo);
                //PopulateHealthIdDtoFromDialog(dialog, healthId);

                var actionSuceeded = await Task.Run(() => _controller.AddPatient(patient, contactInfo, healthId));

                if (actionSuceeded)
                {
                    //IsDisposed = true; // new view next time
                    _eventRaiser.Raise(new LaunchPatientIndexViewEvent());

                }

            }
        }

        private void SetInitialInputValues(PatientDto patient)
        {
            identity.FirstName = patient.FirstName;
            identity.LastName = patient.LastName;
            identity.DateOfBirth = patient.DateOfBirth;
            identity.Gender = patient.Gender;
        }

        private void SetPatientProperties(PatientDto patient)
        {
            patient.FirstName = identity.FirstName;
            patient.LastName = identity.LastName;
            patient.DateOfBirth = identity.DateOfBirth;
            patient.Gender = identity.Gender;
        }

        //private void PopulateContactInfoDtoFromDialog(NewPatientDialog dialog, ContactInfoDto contactInfo)
        //{

        //    contactInfo.Address = dialog.Address;
        //    contactInfo.PrimaryPhoneNumber = dialog.PrimaryPhoneNumber;
        //    contactInfo.SecondaryPhoneNumber = dialog.SecondaryPhoneNumber;
        //    contactInfo.Email = dialog.Email;

        //}

        //private void PopulateHealthIdDtoFromDialog(NewPatientDialog dialog, HealthIdentificationDto healthId)
        //{
        //    healthId.Healthcard = dialog.Healthcard;
        //}


        public void SetController(PatientController controller)
        {
            _controller = controller;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            _eventRaiser.Raise(new LaunchPatientIndexViewEvent());
        }
    }
}
