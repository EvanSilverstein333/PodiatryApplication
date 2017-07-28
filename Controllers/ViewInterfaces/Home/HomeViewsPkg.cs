using Controllers.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers.ViewInterfaces.Home
{
    public class HomeViewsPkg:IViewsPackage<HomeController>
    {
        private HomeController _controller;
        private IMainView _detailsView;
        private IViewFactory _viewFactory;

        public HomeViewsPkg(IViewFactory viewFactory)
        {
            _viewFactory = viewFactory;

        }

        public IMainView DetailsView
        {
            get
            {
                _detailsView = ManageViewInstance(_detailsView);
                return _detailsView;
            }
        }



        public TView ManageViewInstance<TView>(TView currentViewInstance) where TView : class, IView<HomeController>
        {
            TView view = currentViewInstance;
            if (currentViewInstance == null || currentViewInstance.IsDisposed)
            {
                view = _viewFactory.GetView<TView>();
                view.SetController(_controller);
            }
            return view;
        }


        public void SetController(HomeController controller)
        {
            _controller = controller;
        }


    }
}
