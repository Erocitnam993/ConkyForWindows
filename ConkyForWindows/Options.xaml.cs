using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
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
       
        //public string location = "http://weather.yahooapis.com/forecastrss?w=2464601";
        private WpfApplication1.MainWindow fif = new WpfApplication1.MainWindow();

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }

        private void options_Loaded(object sender, RoutedEventArgs e)
        {
            //Sets the WOEID texbox to last saved entry
            txtWeatherLocation.Text = Settings.Default.txtWOEID;
            comboNic.SelectedIndex = Settings.Default.nic;
            comboDisk.SelectedIndex = Settings.Default.driveSelection;

            //Scans for all NIC'sand adds them to the ComboBox
            NetworkInterface[] interfaces
               = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface ni in interfaces)
            {
                comboNic.Items.Add(ni.NetworkInterfaceType);
            }

            //Scans for all Drives and adds them to the ComboBox
            DriveInfo[] drives
                        = DriveInfo.GetDrives();
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                comboDisk.Items.Add(drive.Name);
            }

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (txtWeatherLocation.Text != "")
            {
                Settings.Default.textboxLocation = "http://weather.yahooapis.com/forecastrss?w=" + txtWeatherLocation.Text;
            }
            Settings.Default.txtWOEID = txtWeatherLocation.Text;
            Settings.Default.nic = comboNic.SelectedIndex;
            Settings.Default.driveSelection = comboDisk.SelectedIndex;
            Settings.Default.Save();
            this.Close();
        }
    }
}
