using Controllers.ViewInterfaces.Patient;
using PatientManager.Contract.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
//using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace View.Views.Patient
{
    /// <summary>
    /// Interaction logic for PatientActionPane.xaml
    /// </summary>
    public partial class PatientActionPane : UserControl, IPatientActionPane
    {
        public PatientActionPane()
        {
            InitializeComponent();
            //btnSeeFinances.Click += BtnSeeFinances_Click;
            //btnSeeMedicalHistory.Click += BtnSeeMedicalHistory_Click;

        }

        public string Text { get; set; }
        public bool IsDisposed { get; private set; }

        private void BtnSeeMedicalHistory_Click(object sender, RoutedEventArgs e)
        {
            var handler = SeeMedicalHistoryClicked;
            if (handler != null) { handler.Invoke(this, e); }

        }

        public string SearchText
        {
            get { return searchBox.Text; }
            set { searchBox.Text = value; }
        }

        private void BtnSeeFinances_Click(object sender, RoutedEventArgs e)
        {

            var handler = SeeFinancesClicked;
            if (handler != null) { handler.Invoke(this, e); }

        }

        private void BtnSeePatientVisits_Click(object sender, RoutedEventArgs e)
        {
            //_eventRaiser.Raise(new LaunchPatientVisitIndexViewEvent(_selectedPatient));
            var handler = SeeMedicalHistoryClicked;
            if (handler != null) { handler.Invoke(this, e); }

        }

        private void SearchBox_TextChanged(object sender, RoutedEventArgs e)
        {

            var handler = SearchTextChanged;
            if (handler != null) { handler.Invoke(this, e); }

        }

        //private void BtnUpdateHealthcard_Click(object sender, RoutedEventArgs e)
        //{
        //    var handler = UpdateHealthcardClicked;
        //    if (handler != null) { handler.Invoke(this, e); }
        //}

        private void BtnUpdateContactInfo_Click(object sender, RoutedEventArgs e)
        {
            var handler = UpdateContactInformationClicked;
            if (handler != null) { handler.Invoke(this, e); }

        }

        private void btnUpdateIdentity_Click(object sender, RoutedEventArgs e)
        {
            var handler = UpdateIdentityClicked;
            if (handler != null) { handler.Invoke(this, e); }

        }

        private void btnUpdateHealthcard_Click(object sender, RoutedEventArgs e)
        {
            var handler = UpdateHealthcardClicked;
            if (handler != null) { handler.Invoke(this, e); }

        }

        //private void BtnUpdateIdentity_Click(object sender, RoutedEventArgs e)
        //{
        //    var handler = UpdateIdentityClicked;
        //    if (handler != null) { handler.Invoke(this, e); }

        //}

        private void BtnRemovePatient_Click(object sender, RoutedEventArgs e)
        {
            var handler = RemovePatientClicked;
            if (handler != null) { handler.Invoke(this, e); }

        }

        private void BtnAddPatient_Click(object sender, RoutedEventArgs e)
        {
            var handler = AddPatientClicked;
            if (handler != null) { handler.Invoke(this, e); }
        }

        public void BindToPatient(PatientDto patient)
        {
            //_selectedPatient = patient;

            patientDetailsPanel.Visibility = (patient != null) ? Visibility.Visible : Visibility.Hidden;
            lblPatientName.Content = (patient == null) ? null : string.Format("{0} {1}", patient.FirstName, patient.LastName);
        }

        //public void SetPatientLabel(string firstName, string lastName)
        //{
        //    lblPatientName.Text = name;
        //}

        public event EventHandler<RoutedEventArgs> AddPatientClicked;
        public event EventHandler<RoutedEventArgs> RemovePatientClicked;
        public event EventHandler<RoutedEventArgs> UpdateIdentityClicked;
        public event EventHandler<RoutedEventArgs> UpdateContactInformationClicked;
        public event EventHandler<RoutedEventArgs> UpdateHealthcardClicked;
        public event EventHandler<RoutedEventArgs> SearchTextChanged;
        public event EventHandler<RoutedEventArgs> SeeMedicalHistoryClicked;
        public event EventHandler<RoutedEventArgs> SeeFinancesClicked;

    }
}
