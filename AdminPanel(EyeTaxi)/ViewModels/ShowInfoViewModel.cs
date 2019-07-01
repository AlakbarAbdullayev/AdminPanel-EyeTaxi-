using AdminPanel_EyeTaxi_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanel_EyeTaxi_.ViewModels
{
    public class ShowInfoViewModel :BaseViewModel
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

        public ShowInfoViewModel( Drivers showinfodriver)
        {
            this.driver = showinfodriver;
        }


    }
}
