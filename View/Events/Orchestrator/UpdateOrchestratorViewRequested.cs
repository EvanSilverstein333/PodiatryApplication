using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View.Events.Orchestrator.UpdateHostViewRequested
{
    public class UpdateOrchestratorViewRequested
    {
        public UpdateOrchestratorViewRequested(string caption, bool showDetailsTabCollection)
        {
            Caption = caption;
            ShowDetailsTabCollection = showDetailsTabCollection;
        }
        public string Caption { get; }
        public bool ShowDetailsTabCollection { get; }
    }
}
