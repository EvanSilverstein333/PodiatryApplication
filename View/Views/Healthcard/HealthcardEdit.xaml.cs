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
using ValueObjects.ContactInformation;
using PatientManager.Contract.Dto;
using Controllers.ViewInterfaces;
using Controllers.Controllers;
using Controllers.ViewInterfaces.Healthcard;
using View.ViewLauncher;
using View.ViewLauncher.PatientView;

namespace View.Views.Healthcard
{
    /// <summary>
    /// Interaction logic for HealthcardDetails.xaml
    /// </summary>
    public partial class HealthcardEdit : UserControl, IHealthcardEdit
    {
        //ContactInfoDto _contactInfo;
        PatientDto _selectedPatient;
        private IViewLauncher _eventRaiser;
        private HealthcardController _controller;
        public bool IsDisposed { get; private set; }

        public HealthcardEdit(IViewLauncher eventRaiser)
        {
            _eventRaiser = eventRaiser;
            InitializeComponent();
            Text = "Contact Info";
        }


        public string Text { get; set; }

        public ValueObjects.Health.Healthcard Healthcard
        {
            get { return GetHealthcardProperties(); }
            set { SetHealthcardProperties(value); }
        }


        private void SetHealthcardProperties(ValueObjects.Health.Healthcard healthcard)
        {
            healthNumber.Text = healthcard.Number;
            versionCode.Text = healthcard.VersionCode;
            expiryDate.SelectedDate = healthcard.ExpiryDate;

        }

        private ValueObjects.Health.Healthcard GetHealthcardProperties()
        {
            var healthcard = new ValueObjects.Health.Healthcard()
            {
                Number = healthNumber.Text,
                VersionCode = versionCode.Text,
                ExpiryDate = expiryDate.SelectedDate
            };
            return healthcard;
        }

        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            var healthcardDto = new HealthIdentificationDto()
            {
                Healthcard = this.Healthcard
            };


            var actionSucceeded = await Task.Run(() => _controller.UpdateHealthcard(_selectedPatient.Id, healthcardDto));
            if (actionSucceeded)
            {
                _eventRaiser.Raise(new LaunchPatientIndexViewEvent(_selectedPatient.Id));
            }


        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            //IsDisposed = true; // temp whie actionpane is still winfrom (disposable)
            _eventRaiser.Raise(new LaunchPatientIndexViewEvent(_selectedPatient.Id));
        }

        public void SetController(HealthcardController controller)
        {
            _controller = controller;
        }

        public void BindToPatient(PatientDto patient)
        {
            _selectedPatient = patient;
            var healthId = _controller.GetPatientHealthIdentification(_selectedPatient.Id);
            Healthcard = healthId.Healthcard;
            Text = _selectedPatient.FirstName + " " + _selectedPatient.LastName;
        }


    }
}
