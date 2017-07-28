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
using Controllers.ViewInterfaces.PatientVisit;
using View.ViewLauncher;
using View.ViewLauncher.PatientVisitView;

namespace View.Views.PatientVisit
{
    /// <summary>
    /// Interaction logic for PatientCreate.xaml
    /// </summary>
    public partial class PatientVisitEdit : UserControl, IPatientVisitEdit
    {
        private PatientVisitController _controller;
        private PatientDto _selectedPatient;
        private PatientVisitDto _selectedVisit;
        private IViewLauncher _eventRaiser;
        
        public string Text { get; set; }
        public bool IsDisposed { get; private set; }


        public PatientVisitEdit(IViewLauncher eventRaiser)
        {
            _eventRaiser = eventRaiser;
            InitializeComponent();
        }


        public void BindToPatientVisit(PatientVisitDto visit, PatientDto selectedPatient)
        {
            _selectedVisit = visit;
            _selectedPatient = selectedPatient;
            SetInitialInputValues(visit);
        }

        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            {

                var visit = _selectedVisit;
                SetPatientVisitProperties(visit);

                var result = await Task.Run(() => _controller.UpdatePatientVisit(visit));

                if (result)
                {
                    _eventRaiser.Raise(new LaunchPatientVisitIndexViewEvent(_selectedPatient));

                }




            }
        }




        private void SetInitialInputValues(PatientVisitDto visit)
        {
            patientVisitControl.Date = visit.Date;
            patientVisitControl.Diagnosis = visit.Diagnosis;
            patientVisitControl.Notes = visit.Notes;
        }

        private void SetPatientVisitProperties(PatientVisitDto visit)
        {
            visit.Date = patientVisitControl.Date;
            visit.Diagnosis = patientVisitControl.Diagnosis;
            visit.Notes = patientVisitControl.Notes;
        }


        public void SetController(PatientVisitController controller)
        {
            _controller = controller;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            _eventRaiser.Raise(new LaunchPatientVisitIndexViewEvent(_selectedPatient, _selectedVisit.Id));
        }


    }
}
