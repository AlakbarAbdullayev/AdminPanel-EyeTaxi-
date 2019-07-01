using AdminPanel_EyeTaxi_.Models;
using AdminPanel_EyeTaxi_.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace AdminPanel_EyeTaxi_.Views
{
    /// <summary>
    /// Interaction logic for ShowInfoWindow.xaml
    /// </summary>
    public partial class ShowInfoWindow : Window
    {

        public ShowInfoWindow(Drivers showinfodriver)
        {
            InitializeComponent();
            this.DataContext = new ShowInfoViewModel(showinfodriver);
        }
    }
}
