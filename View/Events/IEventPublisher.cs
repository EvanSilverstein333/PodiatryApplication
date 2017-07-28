using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.Events
{
    public interface IEventPublisher<TMessage>
    {
        void Publish(TMessage message);
        void Reset();
    }
}
