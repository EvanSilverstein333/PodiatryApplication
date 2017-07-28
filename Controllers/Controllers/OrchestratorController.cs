using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controllers.ViewInterfaces;
using System.Windows.Forms;
using Controllers.ViewInterfaces.Orchestrator;

namespace Controllers.Controllers
{
    public class OrchestratorController : IController
    {
        private IOrchestratorView _view;
        public IViewBase View { get { return _view; } }

        public OrchestratorController(IOrchestratorView viewHost)
        {
            _view = viewHost;
        }

        //public void StartApplication(IViewBase defaultView)
        //{
        //    ComposeView(defaultView);
        //    //Application.SetCompatibleTextRenderingDefault(false);
        //    Application.Run((Form)_view);
        //}

        public void ComposeView(IViewBase masterView, IViewBase actionPane = null, params IViewBase[] detailViews)
        {
            //_masterView = masterView;
            //_detailViews = detailViews;
            _view.ComposeView(masterView, actionPane, detailViews);

        }

        public void SetCaption(string caption)
        {
            _view.Text = caption;
        }

        public void DetailTabCollectionVisible(bool visible)
        {
            _view.SetDetailTabCollectionVisible(visible);
        }

        //private void LaunchMainView()
        //{
        //    var mainController = _controllerFactory.Resolve<HomeController>();
        //    ComposeView(mainController.View);

        //    //ControllerEventsRaiser.Raise(new LaunchViewEvent(mainController.))
        //}

        //public void Load()
        //{
        //    _viewHost.ComposeView(_masterView, _detailViews);
        //}


    }
}
