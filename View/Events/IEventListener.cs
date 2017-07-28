using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.Events
{
    public interface IEventListener<TMessage>
    {
        event Action<TMessage> MessageReceived;
    }
}
