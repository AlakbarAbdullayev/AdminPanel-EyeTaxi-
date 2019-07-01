using AdminPanel_EyeTaxi_.Models;
using Newtonsoft.Json;
using System.Windows.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;
using System.Threading;

namespace AdminPanel_EyeTaxi_.ViewModels
{
    public class MonthlyStatisticsViewModel : BaseViewModel
    {
        private ObservableCollection<MonthStatistics> _monthstatisticslist;
        public ObservableCollection<MonthStatistics> monthstatisticslist
        {
            get { return _monthstatisticslist; }
            set
            {
                _monthstatisticslist = value;
                OnPropertyChanged();
            }
        }
       


        public MonthlyStatisticsViewModel()
        {
            monthstatisticslist = new ObservableCollection<MonthStatistics>(GetDrivers());
        }
       

        public ObservableCollection<MonthStatistics> GetDrivers()
        {
            var json = File.ReadAllText("statistics.json");
            ObservableCollection<MonthStatistics> months = JsonConvert.DeserializeObject<ObservableCollection<MonthStatistics>>(json) ?? new ObservableCollection<MonthStatistics>();
            return months;
        }



    }
}