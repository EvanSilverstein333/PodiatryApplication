using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controllers.ViewInterfaces;

namespace Controllers.ViewInterfaces
{
    public interface IViewFactory
    {
        TView GetView<TView>() where TView : class, IViewBase;

    }
}
