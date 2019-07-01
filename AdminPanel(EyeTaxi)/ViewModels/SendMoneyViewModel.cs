using AdminPanel_EyeTaxi_.Commands;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AdminPanel_EyeTaxi_.ViewModels
{
    class SendMoneyViewModel :BaseViewModel
    {
        public string whichmoney { get; set; } = "AZN";
        string daymoneypath = "daymoney.json";
        string companymoneypath = "companymoney.json";

        private string _daymoney;
        public string daymoney
        {
            get { return _daymoney; }
            set
            {
                _daymoney = value;
                OnPropertyChanged();
            }
        }


        private string _companymoney;
        public string companymoney
        {
            get { return _companymoney; }
            set
            {
                _companymoney = value;
                OnPropertyChanged();
            }
        }

        double daymoneydouble = 0;
        double companymoneydouble = 0;
        int doing = 0;


        public SendMoneyViewModel()
        {


            string json = File.ReadAllText(daymoneypath);
            try
            {
                daymoneydouble = Double.Parse(json, System.Globalization.CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {
                MessageBox.Show("There is a problem in day money.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string json1 = File.ReadAllText(companymoneypath);

            try
            {
                companymoneydouble = Double.Parse(json1, System.Globalization.CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {
                MessageBox.Show("There is a problem in company money", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            companymoney = companymoneydouble.ToString("F99").TrimEnd('0').TrimEnd('.').TrimEnd(',');
            daymoney = daymoneydouble.ToString("F99").TrimEnd('0').TrimEnd('.').TrimEnd(',');
        }

        public RelayCommand SendMoneyCommand => new RelayCommand(e =>
        {
            if (doing == 0)
            {

                double tempmoney = daymoneydouble * 15;
                tempmoney = tempmoney / 100;
                companymoneydouble = companymoneydouble + tempmoney;
                string monthmoney = Newtonsoft.Json.JsonConvert.SerializeObject(tempmoney, Newtonsoft.Json.Formatting.Indented);
                string output = Newtonsoft.Json.JsonConvert.SerializeObject(companymoneydouble, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(companymoneypath, output);
                File.WriteAllText("monthmoney.json", monthmoney);
                File.WriteAllText(daymoneypath, "0");
                MessageBox.Show("Money send to company", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                daymoneydouble = 0;
                daymoney = daymoneydouble.ToString("F99").TrimEnd('0').TrimEnd('.').TrimEnd(',');
                companymoney = companymoneydouble.ToString("F99").TrimEnd('0').TrimEnd('.').TrimEnd(',');
                doing++;
            }
        });

    }
}
