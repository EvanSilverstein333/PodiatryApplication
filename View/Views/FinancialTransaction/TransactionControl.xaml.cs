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
using ValueObjects.Finance;
using ValueObjects.Health;

namespace View.Views.FinancialTransaction
{
    /// <summary>
    /// Interaction logic for PatientCreate.xaml
    /// </summary>
    public partial class TransactionControl : UserControl
    {
        public TransactionControl()
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
        public Money Money
        {
            get
            { return new Money(Convert.ToDecimal(amount.Text), currency.Text); }
            set
            {
                amount.Text = value.Amount.ToString();
                currency.Text = value.Currency;
            }
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TransactionType TransactionType { get; set; }


        //[Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public decimal Amount
        //{
        //    get { return Convert.ToDecimal(amount.Text); }
        //    set { amount.Text =  value.ToString(); }
        //}

        //[Browsable(false)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public string Currency
        //{
        //    get { return currency.Text; }
        //    set { currency.Text = value; }
        //}


        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime? Date
        {
            get { return date.SelectedDate; }
            set { date.SelectedDate = value; }
        }


    }
}
