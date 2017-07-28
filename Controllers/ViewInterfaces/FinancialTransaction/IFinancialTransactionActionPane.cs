using FinanceManager.Contract.Dto;
using PatientManager.Contract.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers.ViewInterfaces.FinancialTransaction
{
    public interface IFinancialTransactionActionPane : IActionPane
    {
        //event EventHandler SearchTextChanged;
        //event EventHandler AddPatientClicked;
        //event EventHandler RemovePatientClicked;
        //event EventHandler UpdateIdentityClicked;
        //event EventHandler UpdateContactInformationClicked;
        //event EventHandler UpdateHealthcardClicked;
        void BindToFinancialTransaction(FinancialTransactionDto transaction);
        

    }
}
