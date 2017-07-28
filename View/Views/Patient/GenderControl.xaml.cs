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
    /// Interaction logic for GenderControl.xaml
    /// </summary>
    public partial class GenderControl : UserControl
    {
        private bool genderPropertyChangedDirectly = true;
        private GenderType _value;
        private GenderOptions _genderOptions;

        public GenderControl()
        {
            InitializeComponent();
        }
        [Category("Appearance")]
        public GenderOptions GenderOptions
        {
            get { return _genderOptions; }
            set
            {
                _genderOptions = value;
                OnGenderOptionsChanged();
            }
        }

        [Category("Behavior")]
        public GenderType Value
        {
            get { return _value; }
            set
            {
                _value = value;
                if (genderPropertyChangedDirectly) { FormatRadioButton(value); }
                OnGenderChanged();
            }
        }


        private void FormatRadioButton(GenderType gender)
        {

            btnMale.Checked -= Gender_Checked;
            btnFemale.Checked -= Gender_Checked;
            btnOther.Checked -= Gender_Checked;


            switch (gender)
            {
                case GenderType.Male:
                    btnMale.IsChecked = true;
                    break;
                case GenderType.Female:
                    btnFemale.IsChecked = true;
                    break;
                case GenderType.Other:
                    btnOther.IsChecked = true;
                    break;
                default:
                    btnFemale.IsChecked = btnMale.IsChecked = btnOther.IsChecked = false;
                    break;

            }

            btnMale.Checked += Gender_Checked;
            btnFemale.Checked += Gender_Checked;
            btnOther.Checked += Gender_Checked;

        }

        private void Gender_Checked(object sender, RoutedEventArgs e)
        {
            genderPropertyChangedDirectly = false;
            var btn = sender as RadioButton;
            if (btn.IsChecked == true) { GenderSelectionByRadioBtn(btn); } // ignore btn that was deselected
            genderPropertyChangedDirectly = true; // reset for nexttime
        }

        private void GenderSelectionByRadioBtn(RadioButton btn)
        {
            GenderType gender;
            if (btnMale.IsChecked == true) { gender = GenderType.Male; }
            else if (btnFemale.IsChecked == true) { gender = GenderType.Female; }
            else if (btnOther.IsChecked == true) { gender = GenderType.Other; }
            else { gender = GenderType.None; }

            if (Value != gender) { Value = gender; }
        }

        public event EventHandler GenderChanged;
        public event EventHandler GenderOptionsChanged;

        protected virtual void OnGenderOptionsChanged()
        {
            var OtherGenderOptionVisiblity = (GenderOptions == GenderOptions.MaleFemaleOther)? Visibility.Visible: Visibility.Hidden;
            btnOther.Visibility = OtherGenderOptionVisiblity;
            if (OtherGenderOptionVisiblity == Visibility.Hidden && Value == GenderType.Other) { Value = GenderType.None; }
            var handler = GenderOptionsChanged;
            if (handler != null) { handler.Invoke(this, EventArgs.Empty); }

        }

        protected virtual void OnGenderChanged()
        {
            if (GenderOptions != GenderOptions.MaleFemaleOther)
            {
                if (Value == GenderType.Other)
                {
                    Value = GenderType.None;
                    return;
                }
            }
            var handler = GenderChanged;
            if (handler != null) { handler.Invoke(this, EventArgs.Empty); }
        }



    }
}
