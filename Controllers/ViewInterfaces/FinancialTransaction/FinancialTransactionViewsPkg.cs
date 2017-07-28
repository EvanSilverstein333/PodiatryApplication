using Controllers.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers.ViewInterfaces.FinancialTransaction
{
    public class FinancialTransactionViewsPkg : IViewsPackage<FinancialTransactionController>
    {
        private FinancialTransactionController _controller;
        private IFinancialTransactionIndex _indexView;
        private IFinancialTransactionEdit _editView;
        private IFinancialTransactionCreate _createView;
        private IViewFactory _viewFactory;


        public IFinancialTransactionIndex IndexView
        {
            get
            {
                _indexView = ManageViewInstance(_indexView);
                return _indexView;
            }
        }

        public IFinancialTransactionEdit EditView
        {
            get
            {
                _editView = ManageViewInstance(_editView);
                return _editView;
            }

        }

        public IFinancialTransactionCreate CreateView
        {
            get
            {
                _createView = ManageViewInstance(_createView);
                return _createView;
            }
        }

        public IActionPane ActionPane { get { return IndexView.ActionPane; } }

        //public PatientViewsPkg(IPatientActionPane actionPane, IPatientCreate createView, IPatientIndex indexView, IPatientEdit editView)

        public FinancialTransactionViewsPkg(IViewFactory viewFactory)
        {
            _viewFactory = viewFactory;
            //IndexView = indexView;
            ////EditView = editView;
            //CreateView = createView;
            //ActionPane = actionPane;
            //SetDefaultText();
        }


        public TView ManageViewInstance<TView>(TView currentViewInstance) where TView : class, IView<FinancialTransactionController>
        {
            var view = currentViewInstance;
            if (currentViewInstance == null || currentViewInstance.IsDisposed)
            {
                view = _viewFactory.GetView<TView>();
                view.SetController(_controller);
            }
            return view;
        }

        public void SetController(FinancialTransactionController controller)
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
