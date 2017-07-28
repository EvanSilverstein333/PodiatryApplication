using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controllers.Code;
using Controllers.ViewInterfaces;

using FinanceManager.Contract.Commands;
using FinanceManager.Contract.Events;
using FinanceManager.Contract.Dto;
using FinanceManager.Contract.Queries;
using Controllers.ViewInterfaces.FinancialTransaction;



namespace Controllers.Controllers
{
    public class FinancialTransactionController : IController
    {

        private ICommandProcessor _commandDispatcher;
        private IQueryProcessor _queryDispatcher;
        private INotifyCommandCompletedCallback _callback;

        private FinancialTransactionViewsPkg _viewsPkg;

        public IViewBase IndexView { get { return _viewsPkg.IndexView; } }
        public IViewBase CreateView { get { return _viewsPkg.CreateView; } }
        public IViewBase EditView { get { return _viewsPkg.EditView; } }
        public IActionPane ActionPane { get { return _viewsPkg.ActionPane; } }


        public FinancialTransactionController(FinancialTransactionViewsPkg viewsPkg, ICommandProcessor commandDispatcher, IQueryProcessor queryDispatcher, INotifyCommandCompletedCallback callback)
        {
            _viewsPkg = viewsPkg;
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
            _callback = callback;
            _viewsPkg.SetController(this);
            //_financialTransactionView.Text = "Patients";

        }



        public void LoadIndexView(FinancialAccountDto account, Guid preSelectedTransactionId)
        {
            _viewsPkg.IndexView.BindToFinancialAccount(account, preSelectedTransactionId);
        }

        public void LoadCreateView(FinancialTransactionDto transactionDefaultProperties, FinancialAccountDto account)
        {
            _viewsPkg.CreateView.BindToTransaction(transactionDefaultProperties, account);
        }

        public void LoadEditView(FinancialTransactionDto transaction, FinancialAccountDto account)
        {
            _viewsPkg.EditView.BindToTransaction(transaction, account);
        }






        public bool AddFinancialTransaction(FinancialTransactionDto Transaction)
        {
            bool success = false;
            var command = new AddFinancialTransactionCommand(Transaction);
            _callback.Completed += () => success = true;
            _commandDispatcher.Execute(command);
            return success;
            //return result;

        }



        public bool RemoveFinancialTransaction (Guid transactionId, Guid accountId)
        {
            bool success = false;
            var command = new RemoveFinancialTransactionCommand(transactionId, accountId);
            _callback.Completed += () => success = true;
            _commandDispatcher.Execute(command);
            return success;
        }


        public bool UpdateFinancialTransaction(FinancialTransactionDto Transaction)
        {

            bool success = false;
            
            var command = new UpdateFinancialTransactionCommand(Transaction);
            _callback.Completed += () => success = true;
            //command.NotifyOnCompletion += (cmd, args) => result.ActionSucceeded = args.Success;
            _commandDispatcher.Execute(command);
            return success;
        }

        public FinancialTransactionDto GetTransaction(Guid transactionId)
        {
            var query = new GetFinancialTransactionByIdQuery(transactionId);
            var transactions = _queryDispatcher.Execute(query);
            return transactions;
        }


        public IEnumerable<FinancialTransactionDto> GetTransactionsByAccount(Guid accountId)
        {
            var query = new GetFinancialTransactionsByAccountIdQuery(accountId);
            var transactions = _queryDispatcher.Execute(query);
            return transactions;
        }


    }
}
