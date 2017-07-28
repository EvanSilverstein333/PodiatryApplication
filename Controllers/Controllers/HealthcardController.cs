using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controllers.ViewInterfaces;
using Controllers.Code;
using PatientManager.Contract.Dto;
using PatientManager.Contract.Queries;
using PatientManager.Contract.Commands;
using Controllers.ViewInterfaces.Healthcard;

namespace Controllers.Controllers
{
    public class HealthcardController : IController
    {
        private Dictionary<Type, Action> _eventActions = new Dictionary<Type, Action>();
        private ICommandProcessor _commandDispatcher;
        private IQueryProcessor _queryDispatcher;
        private INotifyCommandCompletedCallback _callback;
        private HealthcardViewsPkg _viewsPkg;
        public IViewBase EditView { get { return _viewsPkg.EditView; } }
        public IViewBase DetailsView { get { return _viewsPkg.DetailsView; } }



        public HealthcardController(HealthcardViewsPkg viewsPkg, ICommandProcessor commandDispatcher, IQueryProcessor queryDispatcher, INotifyCommandCompletedCallback callback)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
            _callback = callback;
            _viewsPkg = viewsPkg;
            _viewsPkg.SetController(this);
        }

        public void LoadEditView(PatientDto patient)
        {
            _viewsPkg.EditView.BindToPatient(patient);
        }



        public HealthIdentificationDto GetPatientHealthIdentification(Guid patientId)
        {
            var query = new GetHealthIdByPatientQuery(patientId);
            var healthId = _queryDispatcher.Execute(query) as HealthIdentificationDto;
            return healthId;
        }

        public bool UpdateHealthcard(Guid patientId, HealthIdentificationDto healthId)
        {
            var success = false;
            var command = new UpdateHealthIdCommand(patientId, healthId);
            _callback.Completed += () => success = true;
            //command.NotifyOnCompletion += (cmd, args) => result.ActionSucceeded = args.Success;
            _commandDispatcher.Execute(command);
            return success;
        }


    }
}
