using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controllers.Code;
using Infrastructure.Services.PatientManagerServices.QueryProcessorService;
using PatientMngr = PatientManager.Contract.Queries;
using FinanceMngr = FinanceManager.Contract.Queries;
using Infrastructure.Services.FinanceManagerServices.QueryProcessorService;

namespace Infrastructure.Abstractions
{
    public class WcfServiceQueryHandlerProxy<TQuery, TResult> : IQueryHandler<TQuery,TResult>
    {
        public TResult Handle(TQuery query)
        {
            dynamic service = null;
            if (query.GetType().Assembly == Bootstrapper.PatientContextAssembly)
            {
                service = new PatientManagerQueryProcessorClient();
            }
            else if (query.GetType().Assembly == Bootstrapper.FinanceContextAssembly)
            {
                service = new FinanceManagerQueryProcessorClient("NetTcpBinding_FinanceManagerQueryProcessor");
            }
            else { throw new Exception("Query belongs to a bounded context that is not registered with WcfServiceQueryHandlerProxy"); }

            var time = new TimeSpan(0, 3, 0);
            service.Endpoint.Binding.CloseTimeout = time;
            service.Endpoint.Binding.OpenTimeout = time;
            service.Endpoint.Binding.ReceiveTimeout = time;
            service.Endpoint.Binding.SendTimeout = time;
            try
            {
                return (TResult)service.Submit(query);
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
