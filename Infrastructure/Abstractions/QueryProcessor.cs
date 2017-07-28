using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controllers.Code;
using PatientMngr = PatientManager.Contract.Queries;
using FinanceMngr = FinanceManager.Contract.Queries;

namespace Infrastructure.Abstractions
{
    class QueryProcessor : IQueryProcessor
    {
        public TResult Execute<TResult>(FinanceMngr.IQuery<TResult> query)
        {
            var handlerType =
            typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));

            dynamic handler = Bootstrapper.Container.GetInstance(handlerType);

            return handler.Handle((dynamic)query);

        }

        public TResult Execute<TResult>(PatientMngr.IQuery<TResult> query)
        {
            var handlerType =
            typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));

            dynamic handler = Bootstrapper.Container.GetInstance(handlerType);

            return handler.Handle((dynamic)query);
        }

        //private object ExecuteLogic<TResult>(dynamic query)
        //{
        //    var handlerType =
        //    typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));

        //    dynamic handler = Bootstrapper.GetInstance(handlerType);

        //    return handler.Handle((dynamic)query);
        //}

    }
}
