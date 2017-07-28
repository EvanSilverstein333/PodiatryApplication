using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controllers.ViewInterfaces;
using Controllers.Controllers;
using System.Windows;
using System.Windows.Forms.Integration;
using View.Events;
using View.Events.Orchestrator.UpdateHostViewRequested;
using View.ViewLauncher;
using View.ViewLauncher.PatientView;
using View.ViewLauncher.HomeView;
using Controllers.ViewInterfaces.Orchestrator;

namespace View.Views
{
    public partial class OrchestratorView : Form, IOrchestratorView
    {
        private OrchestratorController _controller;
        private IViewLauncher _eventRaiser;

        private Control _masterControl;
        private IEnumerable<Control> _detailControls;
        private Control _actionpane;
        private IEnumerable<Control> _allControls
        {
            get
            {
                var controls = new List<Control>();
                if (_masterControl != null) { controls.Add(_masterControl); }
                if(_detailControls != null) { controls.AddRange(_detailControls); }
                if(_actionpane != null) { controls.Add(_actionpane); }
                return controls;
            }
        }

        public OrchestratorView(IViewLauncher eventRaiser, IEventListener<UpdateOrchestratorViewRequested> eventListener)
        {
            _eventRaiser = eventRaiser;
            eventListener.MessageReceived += UpdateOrchestratorViewRequested;
            InitializeComponent();
            btnHome.Click += BtnHome_Click;
            btnPatients.Click += BtnPatients_Click;
            btnFullScreenMaster.Click += BtnFullScreenMaster_Click;
            btnFullScreenDetails.Click += BtnFullScreenDetails_Click;
            FormatFullScreenBtn(btnFullScreenMaster, true);
            FormatFullScreenBtn(btnFullScreenDetails, true);

        }

        private void UpdateOrchestratorViewRequested(UpdateOrchestratorViewRequested obj)
        {
            Text = obj.Caption;
            SetDetailTabCollectionVisible(obj.ShowDetailsTabCollection);
        }

        private void BtnPatients_Click(object sender, EventArgs e)
        {
            _eventRaiser.Raise(new LaunchPatientIndexViewEvent());

        }

        private void BtnHome_Click(object sender, EventArgs e)
        {
            _eventRaiser.Raise(new LaunchHomeViewEvent());
        }

        private void BtnFullScreenMaster_Click(object sender, EventArgs e)
        {
            var newScreenMode = viewContainer.Panel2Collapsed;
            viewContainer.Panel2Collapsed = !newScreenMode;
            FormatFullScreenBtn(btnFullScreenMaster, newScreenMode);

        }

        private void BtnFullScreenDetails_Click(object sender, EventArgs e)
        {
            var newScreenMode = viewContainer.Panel1Collapsed;
            viewContainer.Panel1Collapsed = !newScreenMode;
            FormatFullScreenBtn(btnFullScreenDetails, newScreenMode); 
        }

        private void FormatFullScreenBtn(ToolStripButton btn, bool fullScreen)
        {
            btn.Image = (fullScreen) ? imageList1.Images["imageFullScreen"] : imageList1.Images["imageSplitScreen"]; 
        }

        public void ComposeView(IViewBase masterView, IViewBase actionPane = null, params IViewBase[] detailViews)
        {
            ClearExistingControls();
            _masterControl = ConvertViewToControl(masterView);
            _actionpane = ConvertViewToControl(actionPane);
            var controls = new List<Control>();
            foreach(var view in detailViews)
            {
                var control = ConvertViewToControl(view);
                controls.Add(control);
            }
            _detailControls = controls;

            foreach (var control in _allControls)
            {
                if(control != null) // could be the case if only provide master or only details
                {
                    FormatAsSubcontrol(control);
                    DockControl(control);
                    FormatColour(control); // this must come after docking


                }
            }
            SetWindowStyles();
            ShowSubControls();
        }

        private Control ConvertViewToControl(IViewBase view)
        {
            if (view == null) { return null; } // could be the case if only provide master or only details
            else if(view is Control) { return view as Control; }
            else if(view is UIElement)
            {
                var controlHost = new ElementHost();
                controlHost.Child = view as UIElement;
                controlHost.Text = view.Text;
                return controlHost;
            }
            else { throw new Exception("view is not a GUI type"); } 
        }

        private void ShowSubControls()
        {
            foreach(var control in _allControls)
            {
                if(control != null)
                {
                    control.Show();
                }
            }
        }
        private void ClearExistingControls()
        {

            panelMaster.Controls.Clear();
            detailsTabCollection.TabPages.Clear();
            panelActionPane.Controls.Clear();
            foreach (var control in _allControls)
            {
                if(control is ElementHost)
                {
                    var host = control as ElementHost;
                    host.Child = null;
                }
                control.Dispose();
            }
        }


        private void FormatAsSubcontrol(Control control)
        {
            if(control is Form)
            {
                var form = control as Form;
                form.TopLevel = false;
                form.FormBorderStyle = FormBorderStyle.None;
            }
            control.Dock = DockStyle.Fill;
        }

        private void DockControl(Control control)
        {
            if(control == _masterControl)
            {
                _masterControl.Parent = panelMaster;
                lblMasterCaption.Text = control.Text;
            }
            else if(control == _actionpane)
            {
                _actionpane.Parent = panelActionPane;
            }
            else
            {
                var tab = new TabPage(control.Text);
                detailsTabCollection.TabPages.Add(tab);
                tab.BackColor = Color.White;
                //tab.Margin = new Padding(0);
                control.Parent = tab;
            }

        }

        private void FormatColour(Control control)
        {
            control.BackColor = control.Parent.BackColor;
        }


        protected virtual void SetWindowStyles()
        {
            //SetDefaultNavigationWindowStyle();
            SetDefaultActionPaneWindowStyle();
            SetDefaultViewWindowStyle();
        }

        protected virtual void SetDefaultViewWindowStyle()
        {
            viewContainer.Panel1Collapsed = false;
            viewContainer.Panel2Collapsed = false;
            if (_masterControl == null) { viewContainer.Panel1Collapsed = true; }
            else if (_detailControls.Count() == 0) { viewContainer.Panel2Collapsed = true; }
            FormatFullScreenBtn(btnFullScreenMaster, !viewContainer.Panel2Collapsed);
            FormatFullScreenBtn(btnFullScreenDetails, !viewContainer.Panel1Collapsed);
            toolStripDetails.Visible = toolStripMaster.Visible = viewContainer.Panel1Collapsed == viewContainer.Panel2Collapsed; // only show bars if both master and details exists
            lblMasterCaption.Visible = lblMasterCaption.Text != "";
            //btnFullScreenDetails.Visible = !(_masterControl == null);
            //btnFullScreenMaster.Visible = !(_detailControls.Count() == 0);
        }

        protected virtual void SetDefaultActionPaneWindowStyle()
        {
            actionPaneContainer.Panel1Collapsed = false;
            actionPaneContainer.Panel2Collapsed = false;
            if(_actionpane == null) { actionPaneContainer.Panel2Collapsed = true; }
        }

        //protected virtual void SetDefaultNavigationWindowStyle()
        //{
        //    navigationContainer.Panel1Collapsed = false;
        //    navigationContainer.Panel2Collapsed = false;
        //}




        public void SetController(OrchestratorController controller)
        {
            _controller = controller;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            //foreach (var control in _allControls)
            //{
            //    if (control != null) { control.Show(); }
            //}
        }

        public void SetDetailTabCollectionVisible(bool visible)
        {
            detailsTabCollection.Visible = visible;
        }
    }
}
