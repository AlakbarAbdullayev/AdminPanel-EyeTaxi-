using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminPanel_EyeTaxi_.Models
{
    [Serializable]
    public class Drivers
    {
        public Drivers(string name, string surname, string phoneNumber, string carModel, string carVendor, string carNumber, Location location, double rating)
        {
            Name = name;
            Surname = surname;
            PhoneNumber = phoneNumber;
            CarModel = carModel;
            CarVendor = carVendor;
            CarNumber = carNumber;
            Location = location;
            Rating = rating;
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string CarModel { get; set; }
        public string CarVendor { get; set; }
        public string CarNumber { get; set; }
        public Location Location { get; set; }
        public double Rating { get; set; }

        // public double Qazanc { get; set; }
    }
}
