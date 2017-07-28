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
using Controllers.ViewInterfaces.ContactInformation;

namespace Controllers.Controllers
{
    public class ContactInformationController : IController
    {
        private ICommandProcessor _commandDispatcher;
        private IQueryProcessor _queryDispatcher;
        private ContactInfoViewsPkg _viewsPkg;
        private INotifyCommandCompletedCallback _callback;
        public IViewBase EditView { get { return _viewsPkg.EditView; } }
        public IViewBase DetailsView { get { return _viewsPkg.DetailsView; } }

        //public IViewBase View { get { return _contactInfoView; } }

        public ContactInformationController(ContactInfoViewsPkg viewsPkg, ICommandProcessor commandDispatcher, IQueryProcessor queryDispatcher, INotifyCommandCompletedCallback callback)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
            _viewsPkg = viewsPkg;
            _callback = callback;
            viewsPkg.SetController(this);
            //_contactInfoView.SetController(this);
            //_contactInfoView.Text = "Contact Info";

        }

        public void LoadEditView(PatientDto patient)
        {
            _viewsPkg.EditView.BindToPatient(patient);
        }

        public ContactInfoDto GetPatientContactInfo(Guid patientId)
        {
            var query = new GetContactInfoByPatientQuery(patientId);
            var contactInfo = _queryDispatcher.Execute(query) as ContactInfoDto;
            return contactInfo;
        }

        //public HealthIdentificationDto GetPatientHealthIdentification(int patientId)
        //{
        //    var query = new GetHealthIdByPatientQuery(patientId);
        //    var healthId = _queryDispatcher.Execute(query) as HealthIdentificationDto;
        //    return healthId;
        //}

        public bool UpdatePatientContactInfo(Guid patientId, ContactInfoDto contactInfo)
        {
            var success = false;
            var command = new UpdateContactInformationCommand(patientId, contactInfo);
            _callback.Completed += () => success = true;
            //command.NotifyOnCompletion += (cmd, args) => result.ActionSucceeded = args.Success;
            _commandDispatcher.Execute(command);
            return success;
        }

        //internal void SetActionPane(IActionPane actionPane)
        //{
        //    _contactInfoView
        //}

    }
}
