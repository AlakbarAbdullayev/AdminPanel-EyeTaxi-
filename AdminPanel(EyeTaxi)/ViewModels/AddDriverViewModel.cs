using AdminPanel_EyeTaxi_.Commands;
using AdminPanel_EyeTaxi_.Models;
using Microsoft.Maps.MapControl.WPF;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AdminPanel_EyeTaxi_.ViewModels
{
    class AddDriverViewModel : BaseViewModel
    {
        Drivers driver;

        string jsonpath = "Drivers.json";

        private string _drivername;
        public string drivername
        {
            get { return _drivername; }
            set
            {
                _drivername = value;
                OnPropertyChanged();
            }
        }


        private string _driversurname;
        public string driversurname
        {
            get { return _driversurname; }
            set
            {
                _driversurname = value;
                OnPropertyChanged();
            }
        }



        private string _driverphone;
        public string driverphone
        {
            get { return _driverphone; }
            set
            {
                _driverphone = value;
                OnPropertyChanged();
            }
        }

        private string _drivercarmodel;
        public string drivercarmodel
        {
            get { return _drivercarmodel; }
            set
            {
                _drivercarmodel = value;
                OnPropertyChanged();
            }
        }


        private string _drivercarvendor;
        public string drivercarvendor
        {
            get { return _drivercarvendor; }
            set
            {
                _drivercarvendor = value;
                OnPropertyChanged();
            }
        }


        private string _drivercarnumber;

        public string drivercarnumber
        {
            get { return _drivercarnumber; }
            set
            {
                _drivercarnumber = value;
                OnPropertyChanged();
            }
        }


        private string _lon;

        public string lon
        {
            get { return _lon; }
            set
            {
                _lon = value;
                OnPropertyChanged();
            }
        }

        private string _lat;

        public string lat
        {
            get { return _lat; }
            set
            {
                _lat = value;
                OnPropertyChanged();
            }
        }


        private string _driverrating;

        public string driverrating
        {
            get { return _driverrating; }
            set
            {
                _driverrating = value;
                OnPropertyChanged();
            }
        }





        public AddDriverViewModel()
        {
            drivername = string.Empty;
            driversurname = string.Empty;
            driverphone = string.Empty;
            drivercarmodel = string.Empty;
            drivercarvendor = string.Empty;
            drivercarnumber = string.Empty;
            lat = string.Empty;
            lon = string.Empty;
            driverrating = string.Empty;
        }

        public RelayCommand AddDriverButtonCommand => new RelayCommand(e =>
        {
            if (drivername.Length > 0)
            {
                drivername = drivername.Trim();
                if (driversurname.Length > 0)
                {
                    driversurname = driversurname.Trim();
                }
                if (driverphone.Length > 0)
                {
                    driverphone = driverphone.Trim();
                }

                if (drivercarmodel.Length > 0)
                {
                    drivercarmodel = drivercarmodel.Trim();
                }
                if (drivercarvendor.Length > 0)
                {
                    drivercarvendor = drivercarvendor.Trim();
                }
                if (_drivercarnumber.Length > 0)
                {
                    drivercarnumber = drivercarnumber.Trim();
                }
            }

            if (drivername.Length > 0)
            {
                if (driversurname.Length > 0)
                {
                    if (driverphone.Length > 0)
                    {
                        try
                        {
                            int phone = Convert.ToInt32(driverphone);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Driver phone number is not correct.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                            return;
                        }
                        if (drivercarmodel.Length > 0)
                        {
                            if (drivercarvendor.Length > 0)
                            {
                                if (drivercarnumber.Length > 0)
                                {
                                    if (lat.Length > 0)
                                    {
                                        if (lat.Contains(",") == true)
                                        {
                                            MessageBox.Show("Bu ededleri bu isare \".\" ile daxil etmeyiniz xais olunur(lat).", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                                            return;
                                        }

                                        double latdouble = 0;
                                        try
                                        {
                                            latdouble = Double.Parse(lat, System.Globalization.CultureInfo.InvariantCulture);
                                        }
                                        catch (Exception)
                                        {
                                            MessageBox.Show("Lat is not correct.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                                            return;
                                        }

                                        if (lon.Length > 0)
                                        {
                                            if (lon.Contains(",") == true)
                                            {
                                                MessageBox.Show("Bu ededleri bu isare \".\" ile daxil etmeyiniz xais olunur(lon).", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                                                return;
                                            }

                                            double londouble = 0;
                                            try
                                            {
                                                londouble = Double.Parse(lon, System.Globalization.CultureInfo.InvariantCulture);
                                            }
                                            catch (Exception)
                                            {
                                                MessageBox.Show("Lon is not correct.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                                                return;
                                            }

                                            if (driverrating.Length > 0)
                                            {
                                                if (driverrating.Contains(",") == true)
                                                {
                                                    MessageBox.Show("Bu ededleri bu isare \".\" ile daxil etmeyiniz xais olunur(rating).", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                                                    return;
                                                }

                                                double ratingdouble = 0;
                                                try
                                                {
                                                    ratingdouble = Double.Parse(driverrating, System.Globalization.CultureInfo.InvariantCulture);
                                                }
                                                catch (Exception)
                                                {
                                                    MessageBox.Show("Rating is not correct.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                                                    return;
                                                }
                                                //List<Drivers> driverslist;
                                                //var serializer = new JsonSerializer();
                                                //using (var sr = new StreamReader(jsonpath))
                                                //{
                                                //    using (var jr = new JsonTextReader(sr))
                                                //    {
                                                //        driverslist = serializer.Deserialize<Drivers[]>(jr).ToList();
                                                //    }

                                                //    MessageBox.Show("OK");
                                                //}

                                                Location location = new Location(latdouble, londouble);
                                                driver = new Drivers(drivername, driversurname, driverphone, drivercarmodel, drivercarvendor, drivercarnumber, location, ratingdouble);
                                                var jsonData = System.IO.File.ReadAllText(jsonpath);
                                                var driverlist = JsonConvert.DeserializeObject<List<Drivers>>(jsonData) ?? new List<Drivers>();
                                                driverlist.Add(driver);
                                                jsonData = JsonConvert.SerializeObject(driverlist);
                                                System.IO.File.WriteAllText(jsonpath, jsonData);
                                                MessageBox.Show("Driver adds to driver list.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);



                                                drivername = string.Empty;
                                                driversurname = string.Empty;
                                                driverphone = string.Empty;
                                                drivercarmodel = string.Empty;
                                                drivercarvendor = string.Empty;
                                                drivercarnumber = string.Empty;
                                                lat = string.Empty;
                                                lon = string.Empty;
                                                driverrating = string.Empty;
                                                driver = null;
                                            }

                                            else
                                            {
                                                MessageBox.Show("Rating must enter.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                                            }

                                        }

                                        else
                                        {
                                            MessageBox.Show("Lon must enter.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                                        }
                                    }

                                    else
                                    {
                                        MessageBox.Show("Lat must enter.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                                    }

                                }

                                else
                                {
                                    MessageBox.Show("Driver car number number must enter.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                                }
                            }

                            else
                            {
                                MessageBox.Show("Driver car vendor number must enter.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                            }
                        }

                        else
                        {
                            MessageBox.Show("Driver car model number must enter.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                    }

                    else
                    {
                        MessageBox.Show("Driver phone number must enter.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }

                else
                {
                    MessageBox.Show("Driver surname must enter.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

            }
            else
            {
                MessageBox.Show("Driver name must enter.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        });



    }
}
