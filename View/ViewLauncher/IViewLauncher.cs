using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.ViewLauncher
{
    public interface IViewLauncher
    {
        void Raise<TEvent>(TEvent ControllerEvent) where TEvent : class, ILaunchableView;
    }
}
