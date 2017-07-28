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
    public partial class PatientEdit : UserControl, IPatientEdit
    {
        private PatientController _controller;
        private PatientDto _selectedPatient;
        private IViewLauncher _eventRaiser;
        
        public string Text { get; set; }
        public bool IsDisposed { get; private set; }


        public PatientEdit(IViewLauncher eventRaiser)
        {
            _eventRaiser = eventRaiser;
            InitializeComponent();
        }

        public void BindToPatient(PatientDto patient)
        {
            _selectedPatient = patient;
            SetInitialInputValues(patient);
            Text = _selectedPatient.FirstName + " " + _selectedPatient.LastName;

        }

        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            {

                var patient = _selectedPatient;

                SetPatientProperties(patient);

                var actionSuceeded = await Task.Run(() => _controller.UpdatePatient(patient));

                if (actionSuceeded)
                {
                    //IsDisposed = true; // new view next time
                    _eventRaiser.Raise(new LaunchPatientIndexViewEvent(patient.Id));

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




        public void SetController(PatientController controller)
        {
            _controller = controller;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            _eventRaiser.Raise(new LaunchPatientIndexViewEvent(_selectedPatient.Id));
        }
    }
}
