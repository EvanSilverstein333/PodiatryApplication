using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Controllers.Controllers;

namespace Controllers.ViewInterfaces.Orchestrator
{
    public interface IOrchestratorView : IView<OrchestratorController>
    {
        void ComposeView(IViewBase masterView, IViewBase actionPane = null, params IViewBase[] detailViews);
        void SetDetailTabCollectionVisible(bool visible);

    }
}
