using AdminPanel_EyeTaxi_.Models;
using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace AdminPanel_EyeTaxi_.Services
{
    public class AddDriverToMap
    {
        public static void AddDriverOnTheMap(Map map, Drivers driver)
        {
            Pushpin pushpin = new Pushpin
            {
                ToolTip = driver.Name,
                Location = driver.Location,
                //Template = Application.Current.FindResource("TaxiPushpin") as ControlTemplate,
            };
            MapLayer.SetPositionOffset(pushpin, new Point(0, 20));
            map.Children.Add(pushpin);
        }

    }
}
