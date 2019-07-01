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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace AdminPanel_EyeTaxi_
{
    /// <summary>
    /// Interaction logic for SplashScreen.xaml
    /// </summary>
    public partial class SplashScreen : Window
    {
        DispatcherTimer dispatcher;
        public SplashScreen()
        {
            InitializeComponent();
            dispatcher = new DispatcherTimer();
            dispatcher.Interval = new TimeSpan(0, 0, 0, 10);
            dispatcher.Tick += Dispatcher_Tick;
            dispatcher.Start();
        }

        private void Dispatcher_Tick(object sender, EventArgs e)
        {
                dispatcher.Stop();
                this.Close();
        }
    }
}
