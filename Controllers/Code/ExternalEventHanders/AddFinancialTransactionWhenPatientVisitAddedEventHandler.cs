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
    public class AddFinancialTransactionWhenPatientVisitAddedEventHandler: IExternalEventHandler<PatientVisitedEvent>
    {
        private FinancialTransactionController _financialTransactioncontroller;
        private PatientVisitController _patientVisitController;
        public AddFinancialTransactionWhenPatientVisitAddedEventHandler(FinancialTransactionController financialTransactioncontroller, PatientVisitController patientVisitController)
        {
            _financialTransactioncontroller = financialTransactioncontroller;
            _patientVisitController = patientVisitController;
        }
        public void Handle(object domainEvent)
        {
            var msg = (PatientVisitedEvent) domainEvent;
            var patientVisit = _patientVisitController.GetPatientVisit(msg.VisitId);
            var transaction = new FinancialTransactionDto()
            {
                Id = msg.VisitId,
                AccountId = msg.PatientId,
                Date = patientVisit.Date,
                Notes = patientVisit.Notes,
                Money = new ValueObjects.Finance.Money(36, "CAN")
            };

            _financialTransactioncontroller.AddFinancialTransaction(transaction);
        }
    }
}
