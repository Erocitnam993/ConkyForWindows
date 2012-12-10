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
using Winky.Properties;

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
           // locations.location = "http://weather.yahooapis.com/forecastrss?w=2464601";
        }

        // just in case the textbox is null we have a default location.
      //  private WeatherRSS.Weather locations = new WeatherRSS.Weather();
        
        //public string location = "http://weather.yahooapis.com/forecastrss?w=2464601";
        private WpfApplication1.MainWindow fif = new WpfApplication1.MainWindow();
        private void Settings_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (txtWeatherLocation.Text != "")
            {
                Settings.Default.textboxLocation = "http://weather.yahooapis.com/forecastrss?w=" + txtWeatherLocation.Text;
            }
            Settings.Default.nic = comboNic.SelectedIndex;
            Settings.Default.Save();
        }
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }
    }
}
