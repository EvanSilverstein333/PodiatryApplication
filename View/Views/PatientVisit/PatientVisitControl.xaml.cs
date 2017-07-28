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

namespace View.Views.PatientVisit
{
    /// <summary>
    /// Interaction logic for PatientCreate.xaml
    /// </summary>
    public partial class PatientVisitControl : UserControl
    {
        public PatientVisitControl()
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
        public string Notes
        {
            get { return notes.Text; }
            set { notes.Text = value; }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Diagnosis
        {
            get { return diagnosis.Text; }
            set { diagnosis.Text = value; }
        }


        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime? Date
        {
            get { return date.SelectedDate; }
            set { date.SelectedDate = value; }
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
            Notes = null;
            Diagnosis = null;
            Date = null;
        }

    }
}
