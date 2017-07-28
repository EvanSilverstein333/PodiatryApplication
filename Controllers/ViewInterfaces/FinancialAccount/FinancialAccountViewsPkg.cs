using Controllers.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers.ViewInterfaces.FinancialAccount
{
    public class FinancialAccountViewsPkg : IViewsPackage<FinancialAccountController>
    {
        private FinancialAccountController _controller;
        //private IFinancialAccountIndex _indexView;
        //private IFinancialAccountEdit _editView;
        //private IFinancialAccountCreate _createView;
        private IFinancialAccountDetails _detailsView;
        private IViewFactory _viewFactory;


        public IFinancialAccountDetails DetailsView
        {
            get
            {
                _detailsView = ManageViewInstance(_detailsView);
                return _detailsView;
            }
        }


        //public IFinancialAccountIndex IndexView
        //{
        //    get
        //    {
        //        _indexView = ManageViewInstance(_indexView);
        //        return _indexView;
        //    }
        //}

        //public IFinancialAccountEdit EditView
        //{
        //    get
        //    {
        //        _editView = ManageViewInstance(_editView);
        //        return _editView;
        //    }

        //}

        //public IFinancialAccountCreate CreateView
        //{
        //    get
        //    {
        //        _createView = ManageViewInstance(_createView);
        //        return _createView;
        //    }
        //}

        public IActionPane ActionPane { get { return _detailsView.ActionPane; } }

        //public PatientViewsPkg(IPatientActionPane actionPane, IPatientCreate createView, IPatientIndex indexView, IPatientEdit editView)

        public FinancialAccountViewsPkg(IViewFactory viewFactory)
        {
            _viewFactory = viewFactory;
            //IndexView = indexView;
            ////EditView = editView;
            //CreateView = createView;
            //ActionPane = actionPane;
            //SetDefaultText();
        }


        public TView ManageViewInstance<TView>(TView currentViewInstance) where TView : class, IView<FinancialAccountController>
        {
            var view = currentViewInstance;
            if (currentViewInstance == null || currentViewInstance.IsDisposed)
            {
                view = _viewFactory.GetView<TView>();
                view.SetController(_controller);
            }
            return view;
        }

        public void SetController(FinancialAccountController controller)
        {
            _controller = controller;
            //EditView.SetController(controller);
            //IndexView.SetController(controller);
            //CreateView.SetController(controller);

        }

        //private void SetDefaultText()
        //{
        //    IndexView.Text = "Patients";
        //}
    }
}
