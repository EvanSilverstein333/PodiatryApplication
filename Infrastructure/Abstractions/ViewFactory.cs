using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controllers.Controllers;
using Controllers.ViewInterfaces;

namespace Infrastructure.Abstractions
{
    public class ViewFactory : IViewFactory
    {
        public TView GetView<TView>() where TView : class, IViewBase
        {
            var view = Bootstrapper.Container.GetInstance<TView>();
            return view;
        }

    }

}
