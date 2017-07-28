using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace View.Views.Patient
{
    /// <summary>
    /// Interaction logic for PatientCreate.xaml
    /// </summary>
    public partial class IdentityControl : UserControl
    {
        public IdentityControl()
        {
            InitializeComponent();
        }
        //[Category("Behavior")]
        //public bool ReadOnly
        //{
        //    get { return _readOnly; }
        //    set
        //    {
        //        _readOnly = value;
        //        OnReadOnlyChanged();

        //    }
        //}

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string FirstName
        {
            get { return firstName.Text; }
            set { firstName.Text = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string LastName
        {
            get { return lastName.Text; }
            set { lastName.Text = value; }
        }


        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime? DateOfBirth
        {
            get { return dateOfBirth.SelectedDate; }
            set { dateOfBirth.SelectedDate = value; }
        }


        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public GenderType Gender
        {
            get { return gender.Value; }
            set { gender.Value = value; }
        }

        [Category("Appearance")]
        public GenderOptions GenderOptions
        {
            get { return gender.GenderOptions; }
            set { gender.GenderOptions = value; }
        }


        //private void FormatReadOnly()
        //{
        //    foreach (var input in tableLayoutPanel1.Controls)
        //    {
        //        if (input is TextBox)
        //        {
        //            var tb = input as TextBox;
        //            tb.ReadOnly = _readOnly;
        //            tb.Margin = (_readOnly) ? new Padding(5) : new Padding(3);
        //            tb.BorderStyle = (_readOnly) ? BorderStyle.None : BorderStyle.FixedSingle;
        //            tb.Dock = DockStyle.None; //required to reset margins
        //            tb.Dock = DockStyle.Top;
        //        }
        //        else if (input is NullableDateTimePicker)
        //        {
        //            var dtp = input as NullableDateTimePicker;
        //            dtp.Enabled = !_readOnly;
        //        }
        //        else if (input is GenderControl)
        //        {
        //            var gender = input as GenderControl;
        //            gender.Enabled = !_readOnly;
        //            gender.Margin = (_readOnly) ? new Padding(5) : new Padding(3);
        //            gender.BorderStyle = (_readOnly) ? BorderStyle.None : BorderStyle.FixedSingle;
        //            gender.Dock = DockStyle.None; //required to reset margins
        //            gender.Dock = DockStyle.Top;



        //        }

        //    }
        //}


        //public event EventHandler ReadOnlyChanged;
        //protected virtual void OnReadOnlyChanged()
        //{
        //    FormatReadOnly();
        //    var handler = ReadOnlyChanged;
        //    if (handler != null) { handler.Invoke(this, EventArgs.Empty); }
        //}


        public void Clear()
        {
            FirstName = null;
            LastName = null;
            DateOfBirth = null;
            Gender = GenderType.None;
        }

    }
}
