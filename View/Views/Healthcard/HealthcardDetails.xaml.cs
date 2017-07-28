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
using ValueObjects.Health;
using Controllers.ViewInterfaces;
using Controllers.Controllers;
using PatientManager.Contract.Dto;
using View.Events.Patient;
using View.Events;
using View.Views.Patient;
using Controllers.ViewInterfaces.Healthcard;
using View.ViewLauncher;

namespace View.Views.Healthcard
{
    /// <summary>
    /// Interaction logic for HealthcardDetails.xaml
    /// </summary>
    public partial class HealthcardDetails : UserControl, IHealthcardDetails
    {


         
        private HealthcardController _controller;
        private PatientDto _patient;
        //private ValueObjects.Health.Healthcard _healthcard;
        //private PatientActionPane _actionPane;
        private IViewLauncher _eventRaiser;

        public bool IsDisposed { get; private set; }


        //public HealthcardDetails() { }
        public HealthcardDetails(IEventListener<PatientSelectionChanged> eventListener, IViewLauncher eventRaiser)
        {
            _eventRaiser = eventRaiser;
            eventListener.MessageReceived += PatientSelectionChanged;
            InitializeComponent();
            Text = "Healthcard";

        }

        private void PatientSelectionChanged(PatientSelectionChanged e)
        {
            _patient = e.Patient;
            var healthcard = new ValueObjects.Health.Healthcard();
            if (_patient != null)
            {
                healthcard = _controller.GetPatientHealthIdentification(_patient.Id).Healthcard;
            }
            SetHealthcardProperties(healthcard);

        }




        public string Text { get; set; }


        public void SetController(HealthcardController controller)
        {
            _controller = controller;
        }


        public ValueObjects.Health.Healthcard Healthcard
        {
            //get { return GetHealthcardProperties(); }
            set { SetHealthcardProperties(value); }
        }
        



        private void SetHealthcardProperties(ValueObjects.Health.Healthcard healthcard)
        {
            healthNumber.Content = healthcard.Number;
            versionCode.Content = healthcard.VersionCode;
            expiryDate.Content = healthcard.ExpiryDate;

        }

        //private ValueObjects.Health.Healthcard GetHealthcardProperties()
        //{
        //    var healthcard = new ValueObjects.Health.Healthcard()
        //    {
        //        Number = healthNumber.Content.ToString(),
        //        VersionCode = versionCode.Content.ToString(),
        //        ExpiryDate = expiryDate.
        //    };
        //    return healthcard;
        //}
    


    }
}
