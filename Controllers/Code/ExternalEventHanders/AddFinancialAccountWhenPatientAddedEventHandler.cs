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
    public class AddFinancialAccountWhenPatientAddedEventHandler: IExternalEventHandler<NewPatientRegisteredEvent>
    {
        private FinancialAccountController _financialAccountcontroller;
        private PatientController _patientController;
        public AddFinancialAccountWhenPatientAddedEventHandler(FinancialAccountController financialAccountController, PatientController patientController)
        {
            _financialAccountcontroller = financialAccountController;
            _patientController = patientController;
        }
        public void Handle(object domainEvent)
        {
            var msg = (NewPatientRegisteredEvent) domainEvent;
            var patient = _patientController.GetPatient(msg.PatientId);
            var account = new FinancialAccountDto()
            {
                Id = patient.Id,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
            };

            _financialAccountcontroller.AddFinancialAccount(account);
            //_controller.CallbackMessage<NewPatientRegisteredEvent>();
        }
    }
}
