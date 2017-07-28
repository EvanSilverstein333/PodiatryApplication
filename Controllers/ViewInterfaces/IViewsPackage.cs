using Controllers.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers.ViewInterfaces
{
    public interface IViewsPackage<TController> where TController : IController
    {
        void SetController(TController controller);
        TView ManageViewInstance<TView>(TView currentViewInstance) where TView : class, IView<TController>;
    }
}
