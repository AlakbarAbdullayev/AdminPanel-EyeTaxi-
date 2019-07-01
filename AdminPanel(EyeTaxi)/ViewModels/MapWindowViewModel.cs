using AdminPanel_EyeTaxi_.Models;
using AdminPanel_EyeTaxi_.Services;
using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanel_EyeTaxi_.ViewModels
{
    public class MapWindowViewModel:BaseViewModel
    {
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

        public MapWindowViewModel(Drivers mapdriver,Map mymap)
        {
            driver = mapdriver;
            //AddDriverToMap.AddDriverOnTheMap(mymap, mapdriver);

        }
    }

}
