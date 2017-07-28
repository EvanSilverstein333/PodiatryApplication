using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controllers.Code;

namespace Infrastructure.Abstractions
{
    class CommandProcessor : ICommandProcessor
    {
        public void Execute<TCommand>(TCommand command)
        {
        
            var handler = Bootstrapper.Container.GetInstance<ICommandHandler<TCommand>>();
            handler.Handle(command);
            
           
        }
    }
}
