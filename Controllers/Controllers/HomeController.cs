using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controllers.ViewInterfaces;

using Controllers.ViewInterfaces.Home;

namespace Controllers.Controllers
{
    public class HomeController : IController
    {
        private HomeViewsPkg _viewsPkg;
        public IViewBase View { get { return _viewsPkg.DetailsView; } }

        public HomeController(HomeViewsPkg viewsPkg)
        {
            _viewsPkg = viewsPkg;
            _viewsPkg.SetController(this);
        }


    }
}
