using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientManager.Contract.Events;
using Controllers.Controllers;
using FinanceManager.Contract.Dto;

namespace Controllers.Code.ExternalEventHandlers
{
    public class UpdateFinancialAccountWhenPatientUpdatedEventHandler: IExternalEventHandler<PatientIdentityChangedEvent>
    {
        private FinancialAccountController _financialAccountcontroller;
        private PatientController _patientController;
        public UpdateFinancialAccountWhenPatientUpdatedEventHandler(FinancialAccountController financialAccountController, PatientController patientController)
        {
            _financialAccountcontroller = financialAccountController;
            _patientController = patientController;
        }
        public void Handle(object domainEvent)
        {
            var msg = (PatientIdentityChangedEvent) domainEvent;
            var patient = _patientController.GetPatient(msg.PatientId);
            var account = _financialAccountcontroller.GetFinancialAccount(msg.PatientId);
            account.FirstName = patient.FirstName;
            account.LastName = patient.LastName;

            _financialAccountcontroller.UpdateFinancialAccount(account);

        }
    }
}
