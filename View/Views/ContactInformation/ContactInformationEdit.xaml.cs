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
using Controllers.ViewInterfaces.ContactInformation;
using View.ViewLauncher;
using View.ViewLauncher.PatientView;

namespace View.Views.ContactInformation
{
    /// <summary>
    /// Interaction logic for ContactInformationDetails.xaml
    /// </summary>
    public partial class ContactInformationEdit : UserControl, IContactInformationEdit
    {
        //ContactInfoDto _contactInfo;
        PatientDto _selectedPatient;
        private IViewLauncher _eventRaiser;
        private ContactInformationController _controller;
        public bool IsDisposed { get; private set; }

        public ContactInformationEdit(IViewLauncher eventRaiser)
        {
            _eventRaiser = eventRaiser;
            InitializeComponent();
            Text = "Contact Info";
        }

        public Address Address
        {
            get {return GetAddressProperties(); }
            set { SetAddressProperties(value); }
        }

        public PhoneNumber PhoneNumber
        {
            get { return new PhoneNumber(phoneNumber.Text); }
            set { phoneNumber.Text = value.Number; }
        }

        public string Email
        {
            get { return email.Text; }
            set { email.Text = value; }
        }

        public string Text { get; set; }

        private void SetAddressProperties(Address address)
        {
            country.Text = address.Country;
            province.Text = address.Province;
            city.Text = address.City;
            streetAddress.Text = address.StreetAddress;
            appartment.Text = address.AppartmentUnit;
            postalCode.Text = address.PostalCode;
        }

        private Address GetAddressProperties()
        {
            var address = new Address(country.Text, province.Text, city.Text, streetAddress.Text, appartment.Text, postalCode.Text);
            return address;
        }

        private async void Save_Click(object sender, RoutedEventArgs e)
        {
            var contactInfo = new ContactInfoDto()
            {
                Address = this.Address,
                PrimaryPhoneNumber = this.PhoneNumber,
                SecondaryPhoneNumber = this.PhoneNumber,
                Email = this.Email,

            };
            var actionSucceeded = await Task.Run(() => _controller.UpdatePatientContactInfo(_selectedPatient.Id, contactInfo));
            if (actionSucceeded)
            {

                //IsDisposed = true; // temp whie actionpane is still winfrom (disposable)
                _eventRaiser.Raise(new LaunchPatientIndexViewEvent(_selectedPatient.Id));

            }


        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            //IsDisposed = true; // temp whie actionpane is still winfrom (disposable)
            _eventRaiser.Raise(new LaunchPatientIndexViewEvent(_selectedPatient.Id));
        }

        public void SetController(ContactInformationController controller)
        {
            _controller = controller;
        }

        public void BindToPatient(PatientDto patient)
        {
            _selectedPatient = patient;
            var contactInfo = _controller.GetPatientContactInfo(_selectedPatient.Id);
            Address = contactInfo.Address;
            PhoneNumber = contactInfo.PrimaryPhoneNumber;
            Email = contactInfo.Email;
            Text = _selectedPatient.FirstName + " " + _selectedPatient.LastName;
        }


    }
}
