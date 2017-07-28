using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers.Code.ExternalEventHandlers
{
    public interface IExternalEventHandler<TEvent>
    {
        void Handle(object domainEvent); // object becasue msg comes over the wire
    }
}
