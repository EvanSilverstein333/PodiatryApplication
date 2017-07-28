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
using Controllers.ViewInterfaces;
using Controllers.Controllers;
using PatientManager.Contract.Dto;
using View.Events.Patient;
using View.Events;
using View.Views.Patient;
using Controllers.ViewInterfaces.ContactInformation;

namespace View.Views.ContactInformation
{
    /// <summary>
    /// Interaction logic for ContactInformationDetails.xaml
    /// </summary>
    public partial class ContactInformationDetails : UserControl, IContactInformationDetails
    {


         
        private ContactInformationController _controller;
        private PatientDto _patient;
        private ContactInfoDto _contactInfo;
        //private PatientActionPane _actionPane;

        public bool IsDisposed { get; private set; }


        //public ContactInformationDetails() { }
        public ContactInformationDetails(IEventListener<PatientSelectionChanged> eventListener)
        {
            eventListener.MessageReceived += PatientSelectionChanged;
            InitializeComponent();
            Text = "Contact Info";

        }

        private void PatientSelectionChanged(PatientSelectionChanged e)
        {
            _patient = e.Patient;
            var address = new Address();
            if (_patient != null)
            {
                _contactInfo = _controller.GetPatientContactInfo(_patient.Id);
                address = _contactInfo.Address;
                //contactInfoDetailsControl.Address = new Address();
            }
            SetAddressProperties(address);

        }




        public string Text { get; set; }


        public void SetController(ContactInformationController controller)
        {
            _controller = controller;
        }


        public Address Address
        {
            get {return GetAddressProperties(); }
            set { SetAddressProperties(value); }
        }

        public PhoneNumber PhoneNumber
        {
            get { return new PhoneNumber(phoneNumber.Content.ToString()); }
            set { phoneNumber.Content = value.Number; }
        }

        public string Email
        {
            get { return email.Content.ToString(); }
            set { email.Content = value; }
        }



        private void SetAddressProperties(Address address)
        {
            country.Content = address.Country;
            province.Content = address.Province;
            city.Content = address.City;
            streetAddress.Content = address.StreetAddress;
            appartment.Content = address.AppartmentUnit;
            postalCode.Content = address.PostalCode;
        }

        private Address GetAddressProperties()
        {
            var address = new Address(country.Content.ToString(), province.Content.ToString(), city.Content.ToString(), streetAddress.Content.ToString(), appartment.Content.ToString(), postalCode.Content.ToString());
            return address;
        }
    


    }
}
