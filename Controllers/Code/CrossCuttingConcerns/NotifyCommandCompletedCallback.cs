using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controllers.Controllers;

namespace Controllers.Code.CrossCuttingConcerns
{
    public sealed class NotifyCommandCompletedCallback : INotifyCommandCompletedCallback
    {
        public event Action Completed;

        public void ExecuteActions()
        {
            var handler = Completed;
            if(handler != null) { handler.Invoke(); }
        }

        public void Reset()
        {
            // Clears the list of actions.
            this.Completed = () => { };
        }
    }
}
