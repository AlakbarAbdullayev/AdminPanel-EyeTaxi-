using AdminPanel_EyeTaxi_.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
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


namespace AdminPanel_EyeTaxi_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            MainViewModel vm = new MainViewModel();
            vm.mainwindow = this;
            this.DataContext = vm;
            SplashScreen splashScreen = new SplashScreen();
            splashScreen.ShowDialog();
            splashScreen.Close();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            MainViewModel.lastsavetime = DateTime.Now;
            File.WriteAllText("lastsavedate.json", MainViewModel.lastsavetime.ToString("dd MMMM yyyy hh:mm:ss tt"));
        }
    }
}
