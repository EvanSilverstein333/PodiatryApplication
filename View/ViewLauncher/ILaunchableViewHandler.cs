using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.ViewLauncher
{
    public interface ILaunchableViewHandler<TEvent> where TEvent : ILaunchableView
    {
        void Handle(TEvent controllerEvent);
    }
}
