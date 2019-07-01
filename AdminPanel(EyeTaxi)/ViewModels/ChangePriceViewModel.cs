using AdminPanel_EyeTaxi_.Commands;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AdminPanel_EyeTaxi_.ViewModels
{
    class ChangePriceViewModel : BaseViewModel
    {
        JsonSerializer serializer = new JsonSerializer();
        dynamic jsonObj;
        public string whichmoney { get; set; } = "$";


        private string _newprice;
        public string newprice
        {
            get { return _newprice; }
            set
            {
                _newprice = value;
                OnPropertyChanged();
            }
        }

        private string _oldprice;
        public string oldprice
        {
            get { return _oldprice; }
            set
            {
                _oldprice = value;
                OnPropertyChanged();
            }
        }

        public ChangePriceViewModel()
        {
            string json = File.ReadAllText("roadprice.json");
            oldprice = json;
        }


        public RelayCommand ChangeCommand => new RelayCommand(e =>
        {
            try
            {
                if (newprice.Length > 0)
                {
                    newprice = newprice.Trim();
                }

            }
            catch (Exception)
            {
                MessageBox.Show($"New Price must be write.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (newprice.Length > 0)
            {
                double price = 0;
                try
                {
                    if (newprice.Contains(",") == true)
                    {
                        MessageBox.Show("Bu ededleri bu isare \".\" ile daxil etmeyiniz xais olunur.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    else
                    {
                        price = Convert.ToDouble(newprice);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("New Price must be correct.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                jsonObj = price;
                string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText("roadprice.json", output);
                MessageBox.Show("Price change successfully", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                newprice = string.Empty;
                string json = File.ReadAllText("roadprice.json");
                oldprice = json;
            }
        });

    }
}
