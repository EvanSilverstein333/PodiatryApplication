using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PatientMngr = PatientManager.Contract.Queries;
using FinanceMngr = FinanceManager.Contract.Queries;

namespace ApplicationServices.QueryHandlers
{
    public interface IQueryHandler<TQuery,TResult> //where TQuery : PatientMngr.IQuery<TResult>, FinanceMngr.IQuery<TResult>
        //where TQuery : PatientMngr.IQuery<TResult>, FinanceMngr.IQuery<TResult>
    {
        TResult Handle(TQuery query);
    }
}
