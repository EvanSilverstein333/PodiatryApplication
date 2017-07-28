using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.Events
{
    public class EventPublisher<TMessage> : IEventPublisher<TMessage>
    {
        private readonly EventOrchestrator<TMessage> orchestrator;

        public EventPublisher(EventOrchestrator<TMessage> orchestrator)
        {
            this.orchestrator = orchestrator;
        }

        public void Publish(TMessage message) => this.orchestrator.Publish(message);
        public void Reset() { orchestrator.Reset(); }

    }
}
