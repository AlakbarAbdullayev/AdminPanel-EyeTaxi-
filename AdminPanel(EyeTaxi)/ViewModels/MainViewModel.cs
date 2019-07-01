using AdminPanel_EyeTaxi_.Commands;
using AdminPanel_EyeTaxi_.Models;
using AdminPanel_EyeTaxi_.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace AdminPanel_EyeTaxi_.ViewModels
{
    class MainViewModel : BaseViewModel
    {
        static DateTime currenttime = DateTime.Now;
        public static DateTime lastsavetime;
        public MainWindow mainwindow { get; set; }

        public DispatcherTimer Timer { get; set; } = new DispatcherTimer();
        public DispatcherTimer Timer1 { get; set; } = new DispatcherTimer();


        public MainViewModel()
        {
            //currenttime = DateTime.Now;
            //string json = File.ReadAllText("lastsavedate.json");
            //if (json.Length == 0)
            //{
            //    System.IO.File.WriteAllText("lastsavedate.json", currenttime.ToString("dd MMMM yyyy hh:mm:ss tt"));
            //    json = File.ReadAllText("lastsavedate.json");
            //}
            //CheckTime();
            //Timer.Interval = new TimeSpan(0, 1, 0);
            //Timer.Tick += Timer_Tick;
            //Timer.Start();

            //Timer1.Interval = new TimeSpan(0, 0, 1);
            //Timer1.Tick += Timer1_Tick;
            //Timer1.Start();

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            currenttime = DateTime.Now;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            CheckTime();
        }




        //COMMANDS

        public RelayCommand DriversListCommand => new RelayCommand(e =>
        {
            this.mainwindow.MyGrid.Children.Clear();
            DriversListViewModel driverslist = new DriversListViewModel();
            DriversListUserControl uc = new DriversListUserControl();
            uc.DataContext = driverslist;
            this.mainwindow.MyGrid.Children.Add(uc);
        });

        public RelayCommand AddDriverCommand => new RelayCommand(e =>
        {
            this.mainwindow.MyGrid.Children.Clear();
            AddDriverViewModel adddriver = new AddDriverViewModel();
            AddDriverUserControl uc = new AddDriverUserControl();
            uc.DataContext = adddriver;
            this.mainwindow.MyGrid.Children.Add(uc);
        });

        public RelayCommand RemoveDriverCommand => new RelayCommand(e =>
        {
            this.mainwindow.MyGrid.Children.Clear();
            RemoveDriverViewModel removedriver = new RemoveDriverViewModel();
            RemoveDriverUserControl uc = new RemoveDriverUserControl();
            uc.DataContext = removedriver;
            this.mainwindow.MyGrid.Children.Add(uc);
        });

        public RelayCommand ChangePriceCommand => new RelayCommand(e =>
        {
            this.mainwindow.MyGrid.Children.Clear();
            ChangePriceViewModel changePriceView = new ChangePriceViewModel();
            ChangePriceUserControl uc = new ChangePriceUserControl();
            uc.DataContext = changePriceView;
            this.mainwindow.MyGrid.Children.Add(uc);
        });

        public RelayCommand SendMailCommand => new RelayCommand(e =>
        {
            this.mainwindow.MyGrid.Children.Clear();
            SendMailViewModel vm = new SendMailViewModel();
            SendMailUserControl uc = new SendMailUserControl();
            uc.DataContext = vm;
            this.mainwindow.MyGrid.Children.Add(uc);

        });

        public RelayCommand SendMoneyCommand => new RelayCommand(e =>
        {
            this.mainwindow.MyGrid.Children.Clear();
            SendMoneyViewModel sendMoneyView = new SendMoneyViewModel();
            SendMoneyUserControl uc = new SendMoneyUserControl();
            uc.DataContext = sendMoneyView;
            this.mainwindow.MyGrid.Children.Add(uc);
        });

        public RelayCommand ShowAllRoadSum => new RelayCommand(e =>
        {
            this.mainwindow.MyGrid.Children.Clear();
            ShowAllRoadPrice showAllRoadPrice = new ShowAllRoadPrice();
            ShowAllRoadPriceUserControl uc = new ShowAllRoadPriceUserControl();
            uc.DataContext = showAllRoadPrice;
            this.mainwindow.MyGrid.Children.Add(uc);
        });
        public RelayCommand ShowStatistics => new RelayCommand(e =>
        {
            this.mainwindow.MyGrid.Children.Clear();
            MonthlyStatisticsViewModel monthly = new MonthlyStatisticsViewModel();
            MonthlyStatisticsUserControl uc = new MonthlyStatisticsUserControl();
            uc.DataContext = monthly;
            this.mainwindow.MyGrid.Children.Add(uc);
        });





        //MONTHCHECK

        public void CheckTime()
        {

            string json = File.ReadAllText("lastsavedate.json");
            if (json.Length == 0)
            {
                System.IO.File.WriteAllText("lastsavedate.json", currenttime.ToString("dd MMMM yyyy hh:mm:ss tt"));
                json = File.ReadAllText("lastsavedate.json");
            }

            try
            {
                lastsavetime = DateTime.Parse(json, CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {
                MessageBox.Show("There is a problem in converting lastsavetime", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            currenttime = DateTime.Now;
            if (currenttime.Month > lastsavetime.Month)
            {
                var monthsmoneyjson = File.ReadAllText("monthmoney.json");
                var monthsstatistics = File.ReadAllText("statistics.json");
                List<MonthStatistics> months = JsonConvert.DeserializeObject<List<MonthStatistics>>(monthsstatistics) ?? new List<MonthStatistics>();
                MonthStatistics statistics = new MonthStatistics();
                DateTime createDate = new DateTime(lastsavetime.Year, lastsavetime.Month, DateTime.DaysInMonth(lastsavetime.Year, lastsavetime.Month));
                statistics.Date = createDate.ToString("dd MMMM yyyy hh:mm:ss tt");
                double monthmoneydouble = 0;
                try
                {
                    monthmoneydouble = Double.Parse(monthsmoneyjson, System.Globalization.CultureInfo.InvariantCulture);
                }
                catch (Exception)
                {
                    MessageBox.Show("There is a problem in converting month money", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                int monthmoneyint = 0;
                try
                {
                monthmoneyint = Convert.ToInt32(monthmoneydouble);

                }
                catch (Exception)
                {
                    MessageBox.Show("There is a problem in converting double type to int type", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                statistics.money = monthmoneyint;
                months.Add(statistics);

                var jsonData = JsonConvert.SerializeObject(months);
                System.IO.File.WriteAllText("statistics.json", jsonData);
                lastsavetime = DateTime.Now;
                System.IO.File.WriteAllText("lastsavedate.json", lastsavetime.ToString("dd MMMM yyyy hh:mm:ss tt"));
            }
            else
            {
                lastsavetime = DateTime.Now;
                System.IO.File.WriteAllText("lastsavedate.json", lastsavetime.ToString("dd MMMM yyyy hh:mm:ss tt"));
            }
        }

    }
}
