using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanel_EyeTaxi_.ViewModels
{
    class ShowAllRoadPrice : BaseViewModel
    {
        string filepath = "companymoney.json";
        public string whichmoney { get; set; } = "AZN";


        private string _allroadprice;
        public string allroadprice
        {
            get { return _allroadprice; }
            set
            {
                _allroadprice = value;
                OnPropertyChanged();
            }
        }


        public ShowAllRoadPrice()
        {
            allroadprice = File.ReadAllText(filepath);
        }
    }
}
