using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientManager.Contract.Commands;
using System.ServiceModel;
using FluentValidation.Results;
using Controllers.Code;
using Infrastructure.Services.PatientManagerServices.CommandProcessorService;
using Infrastructure.Services.FinanceManagerServices.CommandProcessorService;

using System.Windows.Forms;

namespace Infrastructure.Abstractions
{
    public class WcfServiceCommandHandlerProxy<TCommand> : ICommandHandler<TCommand>
    {
        public void Handle(TCommand command)
        {
            dynamic service = null;
            if(command.GetType().Assembly == Bootstrapper.PatientContextAssembly)
            {
                service = new PatientManagerCommandProcessorClient();
            }
            else if(command.GetType().Assembly == Bootstrapper.FinanceContextAssembly)
            {
                service = new FinanceManagerCommandProcessorClient("NetTcpBinding_FinanceManagerCommandProcessor");
            }
            else { throw new Exception("Command belongs to a bounded context that is not registered with WcfServiceCommandHandlerProxy"); }


            var time = new TimeSpan(0, 3, 0);
            service.Endpoint.Binding.CloseTimeout = time;
            service.Endpoint.Binding.OpenTimeout = time;
            service.Endpoint.Binding.ReceiveTimeout = time;
            service.Endpoint.Binding.SendTimeout = time;

            try
            {
                service.Submit(command);
            }

            finally
            {
                try
                {
                    ((IDisposable)service).Dispose();
                }
                catch
                {
                    // Against good practice and the Framework Design Guidelines, WCF can throw an
                    // exception during a call to Dispose, which can result in loss of the original exception.
                    // See: https://marcgravell.blogspot.com/2008/11/dontdontuse-using.html
                    // See: https://msdn.microsoft.com/en-us/library/aa355056.aspx


                }
            }

        }

    }
}
