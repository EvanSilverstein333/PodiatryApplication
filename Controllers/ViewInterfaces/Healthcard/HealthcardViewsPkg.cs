using Controllers.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers.ViewInterfaces.Healthcard
{
    public class HealthcardViewsPkg:IViewsPackage<HealthcardController>
    {
        private HealthcardController _controller;
        private IHealthcardDetails _detailsView;
        private IHealthcardEdit _editView;
        private IViewFactory _viewFactory;

        public HealthcardViewsPkg(IViewFactory viewFactory)
        {
            _viewFactory = viewFactory;

        }

        public IHealthcardDetails DetailsView
        {
            get
            {
                _detailsView = ManageViewInstance(_detailsView);
                return _detailsView;
            }
        }

        public IHealthcardEdit EditView
        {
            get
            {
                _editView = ManageViewInstance(_editView);
                return _editView;
            }

        }


        public TView ManageViewInstance<TView>(TView currentViewInstance) where TView : class, IView<HealthcardController>
        {
            TView view = currentViewInstance;
            if (currentViewInstance == null || currentViewInstance.IsDisposed)
            {
                view = _viewFactory.GetView<TView>();
                view.SetController(_controller);
            }
            return view;
        }


        public void SetController(HealthcardController controller)
        {
            _controller = controller;
        }

        //private void SetDefaultText()
        //{
        //    //EditView.Text = "Edit";
        //    DetailsView.Text = "Contact Info";
        //}
    }
}
