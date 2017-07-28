using Controllers.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers.ViewInterfaces.ContactInformation
{
    public class ContactInfoViewsPkg:IViewsPackage<ContactInformationController>
    {
        private ContactInformationController _controller;
        private IContactInformationDetails _detailsView;
        private IContactInformationEdit _editView;
        private IViewFactory _viewFactory;

        public ContactInfoViewsPkg(IViewFactory viewFactory)
        {
            _viewFactory = viewFactory;

        }

        public IContactInformationDetails DetailsView
        {
            get
            {
                _detailsView = ManageViewInstance(_detailsView);
                return _detailsView;
            }
        }

        public IContactInformationEdit EditView
        {
            get
            {
                _editView = ManageViewInstance(_editView);
                return _editView;
            }

        }


        public TView ManageViewInstance<TView>(TView currentViewInstance) where TView : class, IView<ContactInformationController>
        {
            TView view = currentViewInstance;
            if (currentViewInstance == null || currentViewInstance.IsDisposed)
            {
                view = _viewFactory.GetView<TView>();
                view.SetController(_controller);
            }
            return view;
        }


        public void SetController(ContactInformationController controller)
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
