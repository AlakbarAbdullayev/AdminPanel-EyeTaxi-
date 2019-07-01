using AdminPanel_EyeTaxi_.Models;
using AdminPanel_EyeTaxi_.Services;
using AdminPanel_EyeTaxi_.ViewModels;
using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
    /// Interaction logic for MapWindow.xaml
    /// </summary>
    /// 
    public partial class MapWindow : Window,INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged([CallerMemberName] string property = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
        private Drivers _driver;
        public Drivers driver
        {
            get { return _driver; }
            set
            {
                _driver = value;
                OnPropertyChanged();
            }
        }

        public MapWindow(Drivers mapdriver)
        {
            InitializeComponent();
            driver = mapdriver;
            this.DataContext = this;
            myMap.CredentialsProvider = new ApplicationIdCredentialsProvider(ConfigurationManager.ConnectionStrings["BingMapApiKey"].ConnectionString);
            AddDriverToMap.AddDriverOnTheMap(myMap, driver);


        }
    }
}
