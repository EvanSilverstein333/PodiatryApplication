using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.Events
{
    public class EventOrchestrator<TMessage>
    {
        public void Publish(TMessage message) => this.MessageReceived(message);
        public event Action<TMessage> MessageReceived = (e) => { };
        public void Reset() { MessageReceived = (e) => { }; }
    }
}
