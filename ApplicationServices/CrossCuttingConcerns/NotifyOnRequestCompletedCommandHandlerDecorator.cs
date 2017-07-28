using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientManager.Contract.Commands;
using PatientManager.Contract.Events;
using ApplicationServices.CommandHandlers;

namespace ApplicationServices.CrossCuttingConcerns
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
            
            bool success = false;
            try
            {
                _decorated.Handle(command);
                success = true;
                _registrator.ExecuteActions(); // callback to controller ** needs to be called first
                //foreach(var e in _eventStore.GetEventQueue()) { _eventProcessor.Process(e); }
            }
            catch // just to see error
            {
                success = false;
                throw;
            }
            finally
            {
               
                //_registrator.MessageCompleted(success);
                _registrator.Reset();
                
            }


        }


    }
}
