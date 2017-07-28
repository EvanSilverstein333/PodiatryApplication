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
    public class UpdateFinancialTransactionWhenPatientVisitUpdatedEventHandler: IExternalEventHandler<PatientVisitChangedEvent>
    {
        private FinancialTransactionController _financialTransactioncontroller;
        private PatientVisitController _patientVisitController;
        public UpdateFinancialTransactionWhenPatientVisitUpdatedEventHandler(FinancialTransactionController financialTransactioncontroller, PatientVisitController patientVisitController)
        {
            _financialTransactioncontroller = financialTransactioncontroller;
            _patientVisitController = patientVisitController;
        }
        public void Handle(object domainEvent)
        {
            var msg = (PatientVisitChangedEvent) domainEvent;
            var patientVisit = _patientVisitController.GetPatientVisit(msg.VisitId);
            var transaction = _financialTransactioncontroller.GetTransaction(msg.VisitId);
            transaction.Date = patientVisit.Date;
            transaction.Notes = patientVisit.Notes;

            _financialTransactioncontroller.UpdateFinancialTransaction(transaction);
        }
    }
}
