using Controllers.Controllers;
using Controllers.ViewInterfaces.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using View.ViewLauncher;
using View.ViewLauncher.PatientView;

namespace View.Views.Home
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl, IMainView
    {
        private HomeController _controller;
        private IViewLauncher _eventRaiser;


        public HomeView(IViewLauncher eventRaiser)
        {
            _eventRaiser = eventRaiser;
            InitializeComponent();
            Text = "Podiatry Manager";
        }
        public string Text { get; set; }
        public bool IsDisposed { get; set; }

 


        private void btnPatients_Click(object sender, RoutedEventArgs e)
        {
            _eventRaiser.Raise(new LaunchPatientIndexViewEvent());
        }


        public void SetController(HomeController controller)
        {
            _controller = controller;
        }


    }
}
