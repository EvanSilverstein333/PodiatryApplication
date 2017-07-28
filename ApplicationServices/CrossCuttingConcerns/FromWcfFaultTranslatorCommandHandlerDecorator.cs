using System.ServiceModel;
using System.Collections.Generic;
using ApplicationServices.CommandHandlers;
using FluentValidation;
using FluentValidation.Results;
using ValueObjects.Validation;
namespace ApplicationServices.CrossCuttingConcerns
{


    public class FromWcfFaultTranslatorCommandHandlerDecorator<TCommand> : ICommandHandler<TCommand>
    {
        private readonly ICommandHandler<TCommand> decoratee;

        public FromWcfFaultTranslatorCommandHandlerDecorator(ICommandHandler<TCommand> decoratee)
        {
            this.decoratee = decoratee;
        }

        public void Handle(TCommand command)
        {
            try
            {
                this.decoratee.Handle(command);
            }
            catch (FaultException<MyValidator> ex)// when (ex.Code?.Name == "WcfValidator")
            {
                // The WCF service communicates this specific error back to us in case of a validation
                // error. We translate it back to an exception that the client can handle..
                var errors = new List<ValidationFailure>();
                foreach(var error in ex.Detail.Errors) { errors.Add(new ValidationFailure(error.PropertyName, error.ErrorMessage)); }
                var validationEx = new ValidationException(ex.Message, errors);
                throw new ValidationException(ex.Message);
            }
        }
    }
}