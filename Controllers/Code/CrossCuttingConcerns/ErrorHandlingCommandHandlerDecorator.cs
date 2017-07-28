using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using PatientManager.Contract.Commands;
using System.Data;

namespace Controllers.Code.CrossCuttingConcerns
{
    public class ErrorHandlingCommandHandlerDecorator<TCommand> : ICommandHandler<TCommand>
    {
        private ICommandHandler<TCommand> _decorated;
        private ILogger _logger;
        public ErrorHandlingCommandHandlerDecorator(ICommandHandler<TCommand> cmdHandler, ILogger logger)
        {
            _decorated = cmdHandler;
            _logger = logger;
        }
        
        public void Handle(TCommand command)
        {
            try
            {
                _logger.Info(string.Format("{0} executed", command.GetType().Name));
                _decorated.Handle(command);
            }
            catch(ValidationException e)
            { 
                _logger.Error("Command failed due to validation errors", e);
                ShowErrorMessage("Validation Error", e.Message);
            }
            catch(TimeoutException e)
            {
                _logger.Error("Command failed due to a timeout error", e);
                ShowErrorMessage("Timeout Error", "The action failed due to a timeout error. Please try again.");
            }

            catch (OptimisticConcurrencyException e)
            {
                _logger.Error("Command failed due to a concurrency error", e);
                ShowErrorMessage("Concurrency Error", "The action failed because the entry was recently updated by another user.");

            }


        }

        private void ShowErrorMessage(string caption, string message)
        {
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ShowCustomMessage(string caption, string message, MessageBoxButtons btns, MessageBoxIcon icon)
        {
            MessageBox.Show(message, caption, btns, icon);

        }
    }
}
