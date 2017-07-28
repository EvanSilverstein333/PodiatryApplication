using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controllers.Code;
using Controllers.ViewInterfaces;

using PatientManager.Contract.Commands;
using PatientManager.Contract.Events;
using PatientManager.Contract.Dto;
using PatientManager.Contract.Queries;
using Controllers.ViewInterfaces.Patient;

namespace Controllers.Controllers
{
    public class PatientController : IController
    {

        private ICommandProcessor _commandDispatcher;
        private IQueryProcessor _queryDispatcher;
        private INotifyCommandCompletedCallback _callback;

        private PatientViewsPkg _viewsPkg;

        public IViewBase IndexView { get { return _viewsPkg.IndexView; } }
        public IViewBase CreateView { get { return _viewsPkg.CreateView; } }
        public IViewBase EditView { get { return _viewsPkg.EditView; } }
        public IActionPane ActionPane { get { return _viewsPkg.ActionPane; } }

//        public PatientController(PatientViewsPkg viewsPkg, ICommandProcessor commandDispatcher, IQueryProcessor queryDispatcher, IControllerEventProcessor eventRaiser, INotifyCommandCompletedCallback callback)

        public PatientController(PatientViewsPkg viewsPkg, ICommandProcessor commandDispatcher, IQueryProcessor queryDispatcher, INotifyCommandCompletedCallback callback)
        {
            //_viewFactory = viewsPkg;
            _viewsPkg = viewsPkg;
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
            //_patientView = patientView;
            _callback = callback;
            _viewsPkg.SetController(this);
        }

        public void LoadIndexView(Guid patientId)
        {
            _viewsPkg.IndexView.Initialize(patientId);
        }

        public void LoadEditView(PatientDto patient)
        {
            _viewsPkg.EditView.BindToPatient(patient);
        }

        public void LoadCreateView(PatientDto defaultPatientProperties)
        {
            _viewsPkg.CreateView.BindToPatient(defaultPatientProperties);
        }




        


        public bool AddPatient(PatientDto patient, ContactInfoDto contactInfo, HealthIdentificationDto healthId)
        {
            contactInfo.Address = new ValueObjects.ContactInformation.Address();
            contactInfo.PrimaryPhoneNumber = new ValueObjects.ContactInformation.PhoneNumber();
            contactInfo.SecondaryPhoneNumber = new ValueObjects.ContactInformation.PhoneNumber();
            healthId.Healthcard = new ValueObjects.Health.Healthcard(); //temp

            bool success = false;
            var command = new AddPatientCommand(patient, contactInfo, healthId);
            _callback.Completed += () => success = true;
            _commandDispatcher.Execute(command);
            return success;
            //return result;

        }



        public bool RemovePatient (Guid patientId)
        {
            bool success = false;
            var command = new DeletePatientCommand(patientId);
            _callback.Completed += () => success = true;

            //command.NotifyOnCompletion += (cmd, args) => result.ActionSucceeded = args.Success;
            _commandDispatcher.Execute(command);
            return success;
            //return result;
        }


        public bool UpdatePatient(PatientDto patient)
        {

            bool success = false;
            
            var command = new UpdatePatientCommand(patient);
            _callback.Completed += () => success = true;
            //command.NotifyOnCompletion += (cmd, args) => result.ActionSucceeded = args.Success;
            _commandDispatcher.Execute(command);
            return success;
        }

        public PatientDto GetPatient(Guid patientId)
        {
            var query = new GetPatientByIdQuery(patientId);
            //_callback.Completed += () => success = true;
            //command.NotifyOnCompletion += (cmd, args) => result.ActionSucceeded = args.Success;
            var patient = _queryDispatcher.Execute(query);
            return patient;

        }

        public IEnumerable<PatientDto> FindPatientsByName(string text)
        {
            //bool success = false;

            var query = new FindPatientsBySearchTextQuery(text);
            //_callback.Completed += () => success = true;
            //command.NotifyOnCompletion += (cmd, args) => result.ActionSucceeded = args.Success;
            var patients = _queryDispatcher.Execute(query);
            return patients;
        }

        public IEnumerable<PatientDto> GetAllPatients()
        {
            var query = new GetAllPatientsQuery();
            var patients = _queryDispatcher.Execute(query) as IEnumerable<PatientDto>;
            return patients;
        }

    }
}
