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
using Controllers.ViewInterfaces.FinancialAccount;
using ValueObjects.Finance;

namespace Controllers.Controllers
{
    public class FinancialAccountController : IController
    {
        private ICommandProcessor _commandDispatcher;
        private IQueryProcessor _queryDispatcher;
        private INotifyCommandCompletedCallback _callback;
        private FinancialAccountViewsPkg _viewsPkg;

        public IViewBase DetailsView { get { return _viewsPkg.DetailsView; } }
        public IActionPane ActionPane { get { return _viewsPkg.ActionPane; } }


        public FinancialAccountController(FinancialAccountViewsPkg viewsPkg, ICommandProcessor commandDispatcher, IQueryProcessor queryDispatcher, INotifyCommandCompletedCallback callback)
        {
           
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
            _callback = callback;
            _viewsPkg = viewsPkg;
            _viewsPkg.SetController(this);

        }

        public void LoadDetailsView(FinancialAccountDto selectedAccount)
        {
            var account = GetFinancialAccount(selectedAccount.Id); // The account may not exist
            if(account == null) { AddFinancialAccount(selectedAccount); }            
            _viewsPkg.DetailsView.BindToAccount(selectedAccount);
            
 
        }




        


        public bool AddFinancialAccount(FinancialAccountDto account)
        {
            bool success = false;
            var command = new AddFinancialAccountCommand(account);
            _callback.Completed += () => success = true;
            _commandDispatcher.Execute(command);
            return success;
            //return result;

        }



        public bool RemoveFinancialAccount (Guid accountId)
        {
            bool success = false;
            var command = new RemoveFinancialAccountCommand(accountId);
            _callback.Completed += () => success = true;

            _commandDispatcher.Execute(command);
            return success;
        }


        public bool UpdateFinancialAccount(FinancialAccountDto account)
        {

            bool success = false;
            
            var command = new UpdateFinancialAccountCommand(account);
            _callback.Completed += () => success = true;
            //command.NotifyOnCompletion += (cmd, args) => result.ActionSucceeded = args.Success;
            _commandDispatcher.Execute(command);
            return success;
        }

        public FinancialAccountDto GetFinancialAccount(Guid id)
        {

            var query = new GetFinancialAccountByIdQuery(id);
            var account = _queryDispatcher.Execute(query);
            return account;
        }

        public Money GetAccountBalance(Guid accountId)
        {
            var query = new GetFinancialAccountBalanceQuery(accountId);
            var balance = _queryDispatcher.Execute(query);
            return balance;
        }

        public IEnumerable<FinancialAccountDto> FindFinancialAccountsByName(string text)
        {
            //bool success = false;

            var query = new FindFinancialAccountsBySearchTextQuery(text);
            //_callback.Completed += () => success = true;
            //command.NotifyOnCompletion += (cmd, args) => result.ActionSucceeded = args.Success;
            var FinancialAccounts = _queryDispatcher.Execute(query);
            return FinancialAccounts;
        }

        public IEnumerable<FinancialAccountDto> GetAllFinancialAccounts()
        {
            var query = new GetAllFinancialAccountsQuery();
            var FinancialAccounts = _queryDispatcher.Execute(query) as IEnumerable<FinancialAccountDto>;
            return FinancialAccounts;
        }

        //public void UpdateHostViewRequest(FinancialAccountDto account)
        //{
        //    var caption = (account == null)? "" : string.Format("{0} {1}", account.FirstName, account.LastName);
        //    var showDetails = account != null;
        //    _eventRaiser.Raise(new UpdateHostViewRequestedEvent(caption, showDetails));
        //}

    }
}
