using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers.Code
{
    public interface ICommandProcessor
    {
        void Execute<TCommand>(TCommand command);
    }
}
