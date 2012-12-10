using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Winky
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            locations.location = "http://weather.yahooapis.com/forecastrss?w=2464601";
        }

        // just in case the textbox is null we have a default location.
        private WeatherRSS.Weather locations = new WeatherRSS.Weather();
        
        //public string location = "http://weather.yahooapis.com/forecastrss?w=2464601";
        private string WOEID = "";
        private void Settings_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            locations.location = "weather.yahooapis.com/forecastrss?w=" + txtWeatherLocation.Text;
        }
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }
    }
}
