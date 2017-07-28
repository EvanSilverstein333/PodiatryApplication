using Controllers.Controllers;
using Controllers.ViewInterfaces.PatientVisit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controllers.ViewInterfaces.PatientVisit
{
    public class PatientVisitViewsPkg : IViewsPackage<PatientVisitController>
    {
        private PatientVisitController _controller;
        private IPatientVisitIndex _indexView;
        private IPatientVisitEdit _editView;
        private IPatientVisitCreate _createView;
        private IViewFactory _viewFactory;


        public IPatientVisitIndex IndexView
        {
            get
            {
                _indexView = ManageViewInstance(_indexView);
                return _indexView;
            }
        }

        public IPatientVisitEdit EditView
        {
            get
            {
                _editView = ManageViewInstance(_editView);
                return _editView;
            }

        }

        public IPatientVisitCreate CreateView
        {
            get
            {
                _createView = ManageViewInstance(_createView);
                return _createView;
            }
        }

        public IActionPane ActionPane { get { return IndexView.ActionPane; } }

        //public PatientViewsPkg(IPatientActionPane actionPane, IPatientCreate createView, IPatientIndex indexView, IPatientEdit editView)

        public PatientVisitViewsPkg(IViewFactory viewFactory)
        {
            _viewFactory = viewFactory;
            //IndexView = indexView;
            ////EditView = editView;
            //CreateView = createView;
            //ActionPane = actionPane;
            //SetDefaultText();
        }


        public TView ManageViewInstance<TView>(TView currentViewInstance) where TView : class, IView<PatientVisitController>
        {
            var view = currentViewInstance;
            if (currentViewInstance == null || currentViewInstance.IsDisposed)
            {
                view = _viewFactory.GetView<TView>();
                view.SetController(_controller);
            }
            return view;
        }

        public void SetController(PatientVisitController controller)
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
