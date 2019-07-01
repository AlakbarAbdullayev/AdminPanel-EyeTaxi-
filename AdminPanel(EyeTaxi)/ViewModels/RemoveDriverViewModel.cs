using AdminPanel_EyeTaxi_.Commands;
using AdminPanel_EyeTaxi_.Models;
using AdminPanel_EyeTaxi_.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AdminPanel_EyeTaxi_.ViewModels
{
    class RemoveDriverViewModel : BaseViewModel
    {
        private ObservableCollection<Drivers> _drivers;
        public ObservableCollection<Drivers> drivers
        {
            get { return _drivers; }
            set
            {
                _drivers = value;
                OnPropertyChanged();
            }
        }


        private Visibility _visible;
        public Visibility visible
        {
            get { return _visible; }
            set
            {
                _visible = value;
                OnPropertyChanged();
            }
        }

        public string jsonpath { get; set; } = "Drivers.json";

        private int? _selectedindex;
        public int? selectedindex
        {
            get { return _selectedindex; }
            set
            {
                _selectedindex = value;
                OnPropertyChanged();
            }
        }



        public RemoveDriverViewModel()
        {
            drivers = GetDrivers();
            visible = Visibility.Hidden;
        }

        public static ObservableCollection<Drivers> GetDrivers()
        {
            var json = File.ReadAllText("Drivers.json");
            ObservableCollection<Drivers> Drivers = JsonConvert.DeserializeObject<ObservableCollection<Drivers>>(json) ?? new ObservableCollection<Drivers>();
            return Drivers;
        }



        public RelayCommand SelectionChangedCommand => new RelayCommand(e =>
        {
            if (selectedindex > -1)
            {
                visible = Visibility.Visible;
            }
            else
            {
                selectedindex = -1;
                visible = Visibility.Hidden;
            }
        });




        public RelayCommand RemoveButtonCommand => new RelayCommand(e =>
        {
            if (selectedindex > -1)
            {

                if (MessageBox.Show("Are you sure that you want to delete this driver", "Question", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
                {
                    drivers.RemoveAt(selectedindex.Value);
                    var jsonData = JsonConvert.SerializeObject(drivers);
                    System.IO.File.WriteAllText(jsonpath, jsonData);
                }
                else
                {
                    selectedindex = -1;
                }
            }
        });



        public RelayCommand ShowButtonCommand => new RelayCommand(e =>
        {
            if (selectedindex > -1)
            {
                ShowInfoWindow showInfo = new ShowInfoWindow(drivers[selectedindex.Value]);
                showInfo.ShowDialog();
                bool? result = showInfo.DialogResult;
                if (result == false)
                {
                    selectedindex = -1;
                }
            }
        });

    }
}
