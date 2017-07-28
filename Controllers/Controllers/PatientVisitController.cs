using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientManager.Contract.Dto;
using PatientManager.Contract.Commands;
using PatientManager.Contract.Queries;
using Controllers.Code;
using Controllers.ViewInterfaces;

using Controllers.ViewInterfaces.PatientVisit;

namespace Controllers.Controllers
{
    public class PatientVisitController : IController
    {
        private ICommandProcessor _commandDispatcher;
        private IQueryProcessor _queryDispatcher;
        private INotifyCommandCompletedCallback _callback;
        private PatientVisitViewsPkg _viewsPkg;
        //private IPatientVisitView _patientVisitView;
        public IViewBase IndexView { get { return _viewsPkg.IndexView; } }
        public IViewBase CreateView { get { return _viewsPkg.CreateView; } }
        public IViewBase EditView { get { return _viewsPkg.EditView; } }
        public IActionPane ActionPane { get { return _viewsPkg.ActionPane; } }

        public PatientVisitController(PatientVisitViewsPkg viewsPkg, ICommandProcessor commandDispatcher, IQueryProcessor queryDispatcher, INotifyCommandCompletedCallback callback)
        {
            _viewsPkg = viewsPkg;
            _callback = callback;
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
            _viewsPkg.SetController(this);
            //_patientVisitView.Text = "Medical History";
        }

        public void LoadIndexView(PatientDto selectedPatient)
        {
            LoadIndexView(selectedPatient, Guid.Empty);

        }

        public void LoadIndexView(PatientDto selectedPatient, Guid preSelectedVisitId)
        {
            _viewsPkg.IndexView.BindToPatient(selectedPatient, preSelectedVisitId);
        }

        public void LoadCreateView(PatientVisitDto visitDefaultProperties, PatientDto selectedPatient)
        {
            _viewsPkg.CreateView.BindToPatientVisit(visitDefaultProperties,selectedPatient);
        }

        public void LoadEditView(PatientVisitDto visit, PatientDto selectedPatient)
        {
            _viewsPkg.EditView.BindToPatientVisit(visit, selectedPatient);
        }



        public PatientVisitDto GetPatientVisit(Guid id)
        {
            var query = new GetPatientVisitByIdQuery(id);
            var patientVisit = _queryDispatcher.Execute(query);
            return patientVisit;
        }

        public IEnumerable<PatientVisitDto> GetAllPatientVisits()
        {
            var query = new GetAllPatientVisitsQuery();
            var patientVisits = _queryDispatcher.Execute(query) as IEnumerable<PatientVisitDto>;
            return patientVisits;
        }

        public IEnumerable<PatientVisitDto> GetVisitsByPatient(Guid patientId)
        {
            var query = new GetPatientVisitsByPatientQuery(patientId);
            var visits = _queryDispatcher.Execute(query) as IEnumerable<PatientVisitDto>;
            return visits;
        }

        public bool AddPatientVisit(PatientVisitDto visit, Guid patientId)
        {
            bool success = false;
            var command = new AddPatientVisitCommand(visit, patientId);
            _callback.Completed += () => success = true;
            _commandDispatcher.Execute(command);
            return success;
        }

        public bool RemovePatientVisit(Guid visitId)
        {
            bool success = false;
            var command = new DeletePatientVisitCommand(visitId);
            _callback.Completed += () => success = true;
            _commandDispatcher.Execute(command);
            return success;
        }

        public bool UpdatePatientVisit(PatientVisitDto visit)
        {
            bool success = false;
            var command = new UpdatePatientVisitCommand(visit);
            _callback.Completed += () => success = true;
            _commandDispatcher.Execute(command);
            return success;
        }




    }


}
