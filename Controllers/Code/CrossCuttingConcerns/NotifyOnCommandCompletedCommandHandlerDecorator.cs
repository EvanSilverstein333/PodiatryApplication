using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientManager.Contract.Commands;
using PatientManager.Contract.Events;
using Controllers.Code;

namespace Controllers.Code.CrossCuttingConcerns
{
    public class NotifyOnRequestCompletedCommandHandlerDecorator<T> : ICommandHandler<T> //where T : ICommand
    {
        private ICommandHandler<T> _decorated;
        private readonly NotifyCommandCompletedCallback _registrator;

        public NotifyOnRequestCompletedCommandHandlerDecorator(ICommandHandler<T> cmdHandler, NotifyCommandCompletedCallback registrator)
        {
            _decorated = cmdHandler;
            _registrator = registrator;

        }

        public void Handle(T command)
        {
            
            try
            {
                _decorated.Handle(command);
                _registrator.ExecuteActions(); // callback to controller
            }
            catch // just to see error
            {

                throw;
            }
            finally
            {
               
                _registrator.Reset();
                
            }

        }



    }
}
