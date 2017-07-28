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
    public class RemoveFinancialTransactionWhenPatientVisitAddedEventHandler : IExternalEventHandler<PatientVisitRemovedEvent>
    {
        private FinancialTransactionController _financialTransactioncontroller;
        private PatientVisitController _patientVisitController;
        public RemoveFinancialTransactionWhenPatientVisitAddedEventHandler(FinancialTransactionController financialTransactioncontroller, PatientVisitController patientVisitController)
        {
            _financialTransactioncontroller = financialTransactioncontroller;
            _patientVisitController = patientVisitController;
        }
        public void Handle(object domainEvent)
        {
            var msg = (PatientVisitRemovedEvent)domainEvent;
            _financialTransactioncontroller.RemoveFinancialTransaction(msg.VisitId,msg.PatientId);
        }
    }
}
