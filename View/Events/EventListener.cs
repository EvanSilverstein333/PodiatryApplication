using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.Events
{
    public class EventListener<TMessage> : IEventListener<TMessage>
    {
        private readonly EventOrchestrator<TMessage> orchestrator;

        public EventListener(EventOrchestrator<TMessage> orchestrator)
        {
            this.orchestrator = orchestrator;
        }

        public event Action<TMessage> MessageReceived
        {
            add { orchestrator.MessageReceived += value; }
            remove { orchestrator.MessageReceived -= value; }
        }
    }
}
