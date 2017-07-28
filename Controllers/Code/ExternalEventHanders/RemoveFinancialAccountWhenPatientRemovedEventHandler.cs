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
    public class RemoveFinancialAccountWhenPatientRemovedEventHandler: IExternalEventHandler<PatientRemovedEvent>
    {
        private FinancialAccountController _financialAccountcontroller;
        private PatientController _patientController;
        public RemoveFinancialAccountWhenPatientRemovedEventHandler(FinancialAccountController financialAccountController, PatientController patientController)
        {
            _financialAccountcontroller = financialAccountController;
            _patientController = patientController;
        }
        public void Handle(object domainEvent)
        {
            var msg = (PatientRemovedEvent) domainEvent;
            _financialAccountcontroller.RemoveFinancialAccount(msg.PatientId);
        }
    }
}
