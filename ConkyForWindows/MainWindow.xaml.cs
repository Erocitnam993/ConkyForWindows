using System;
using System.Collections.Generic;
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
using System.Diagnostics;
using System.Threading;
using System.ComponentModel;
using System.Net;
using System.IO;
using System.Net.NetworkInformation;
using System.Timers;
using WUApiLib;
using System.Management;
using Microsoft.Win32;


namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {

        //public PerformanceCounter cpuCounter;
        public MainWindow()
        {
             
            InitializeComponent();
            
            //this.WindowStartupLocation = WindowStartupLocation.Manual;
        //    this.Left = -282;
       //     this.Top = 35;
            
            cpuUsage.Maximum = 100;
            
            bw.WorkerSupportsCancellation = true;
            bw.WorkerReportsProgress = true;
            bw.DoWork +=
                new DoWorkEventHandler(bw_DoWork);
            bw.ProgressChanged +=
                new ProgressChangedEventHandler(bw_ProgressChanged);
            
        }

        BackgroundWorker bw = new BackgroundWorker();

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            if (bw.WorkerSupportsCancellation == true)
            {
                bw.CancelAsync();
                this.Close();    
            }
        }

        public string proc;
        public double ramTotal;
        public double ramUsed;
        public double ramFree;
        public double ramPercent;
        public double driveSpace;
        public string currentUsageReceived;
        public string bytesSent;
        public string totalSent;
        public string totalReceived;
        public string bytesRecieved;
        public float asdfa;
        private int number = 0;
        public string updates;
        public bool netavailable;
        public bool netavailable2;
        public string ipLocal;
        public string ipExternal;
        public bool test;
        public string time;
        public string cpuCount;

        public NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
        public PerformanceCounter cpuCounter = new PerformanceCounter();
         
        //Does all the work on a background thread
        
        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            
            BackgroundWorker worker = sender as BackgroundWorker;
            
            cpuCounter = new PerformanceCounter();

            cpuCounter.CategoryName = "Processor";
            cpuCounter.CounterName = "% Processor Time";
            cpuCounter.InstanceName = "_Total";
            float[] avg = new float[10];

            while (true)
            {
                if ((worker.CancellationPending == true))
                {
                    e.Cancel = true;
                    break;
                }
                else
                {   
                    worker.ReportProgress((number++));
                    for (int ii = 0; ii < 9; ii++)
                    {
                        avg[ii] = cpuCounter.NextValue();
                        asdfa = avg.Average();
                        string aasdf = asdfa.ToString();

                        Thread.Sleep(100);
                    }
                    
                    //Grabs Needed Info For Disk Space etc...
                    DriveInfo[] drives
                        = DriveInfo.GetDrives();

                    DriveInfo drive = drives[0];
                    driveSpace = drive.AvailableFreeSpace / 1073741824.004733;
                 
                    //Grabs all the needed info for network usage

                    netavailable2 = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
                 
                    if (netavailable2 == true)
                    {
                        NetworkInterface ni = interfaces[2];

                        totalSent = (ni.GetIPv4Statistics().BytesSent / 1048576.0).ToString("f2") + " MB";
                        totalReceived = (ni.GetIPv4Statistics().BytesReceived / 1048576.0).ToString("f2") + " MB";
                    }
                    else if (netavailable2 == false)
                    {
                        totalReceived = "Disconnected";
                        totalSent = "Disconnected";
                    }

                      if (netavailable2 == true && number <= 1)
                      {

                          //Grabs External IP Address, and uses the HTTPGet Class
                          HTTPGet req = new HTTPGet();
                          req.Request("http://checkip.dyndns.org");
                          string[] a = req.ResponseBody.Split(':');
                          string a2 = a[1].Substring(1);
                          string[] a3 = a2.Split('<');
                          string a4 = a3[0];
                          ipExternal = a4;

                          //Grabs Local IP Address
                          ipLocal = "";
                          IPAddress[] localIPs = Dns.GetHostAddresses(Dns.GetHostName());
                          int iter = 0;
                          foreach (IPAddress i in localIPs)
                          {
                              string IP = i.ToString();
                              bool isIP = IP.Contains(".");
                              if (isIP == true)
                                  ipLocal += IP + "\r\n";
                              iter++;
                          }
                      }

                    // Calculates RAM free, usage, total, and usage in percent
                    if (number <= 1)
                    {
                        ramTotal = new Microsoft.VisualBasic.Devices.ComputerInfo().TotalPhysicalMemory / 1073741824.004733;
                    } 
                    ramFree = new Microsoft.VisualBasic.Devices.ComputerInfo().AvailablePhysicalMemory / 1073741824.004733;
                    ramUsed = ramTotal - ramFree;
                    ramPercent =ramUsed  / ramTotal * 100;

                    time = DateTime.Now.ToShortTimeString();

                    /* Possible Future Implementation of System Hardware/Software Info like OS Version, CPU Type etc..
                     * 
                    RegistryKey Rkey = Registry.LocalMachine;
                    Rkey = Rkey.OpenSubKey("HARDWARE\\DESCRIPTION\\System\\CentralProcessor\\0");
                    cpuCount = (string)Rkey.GetValue("ProcessorNameString") + "\n" + new Microsoft.VisualBasic.Devices.ComputerInfo().OSFullName;
                     *
                     */
 

                    if ( netavailable2 == true && number == 3)
                    {
                        RSS = weather.CurrentConditions();
                        WeatherImage = new Uri(weather.getImage());
                    }/*
                    else if (netavailable2 == true && number == 4)
                    {
                        UpdateSessionClass uSession = new UpdateSessionClass();
                        IUpdateSearcher uSearcher = uSession.CreateUpdateSearcher();
                        ISearchResult uResult = uSearcher.Search("IsInstalled=0");

                        foreach (IUpdate update in uResult.Updates)
                        {
                            updateCount++;
                        }
                    }*/
                    else if (netavailable2 == false)
                    {
                        updates = "Disconnected";
                    }
                }

            }
        }

        //Update GUI here with info from the background thread
       
        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            
            //this.resultLabel.Text = (e.ProgressPercentage.ToString());
            txtAvgBox.Text = asdfa.ToString("f2") + "%";
            cpuUsage.Value = asdfa;

            // Prints to textbox network usage
            txtTotalReceived.Text = totalReceived;
            txtTotalSent.Text = totalSent;

            if (netavailable == true)
            {
                txtNetOut.Text = bytesSent;
                txtNetIn.Text = bytesRecieved;
            }

            txtPing.Text = pingtime;
            txtLocal.Text = ipLocal;
            txtExternal.Text = ipExternal;

            //Converts Variables to a String so you can then format properly
            Convert.ToString(ramTotal);
            Convert.ToString(ramUsed);
            Convert.ToString(ramFree);
            Convert.ToString(ramPercent);
            Convert.ToString(driveSpace);

            //Prints free and used RAM to textboxes
            txtRam.Text = ramFree.ToString("f2") + " GB";
            txtRamPercent.Text = ramPercent.ToString("f2") + " %";
            //txtRamUsed.Text = ramTotal.ToString("f2") + " GB";

            //Prints Disk Drive Free Space
            txtDriveSpace.Text = driveSpace.ToString("f2") + " GB";

            //Shows the cooridinates of screen window
            Point scrPos = this.PointToScreen(new Point(0, 0));
            //txtPoint.Text = Convert.ToString(scrPos);

            //Prints Available Updates to screen.
            txtUpdates.Text = Convert.ToString(updateCount);

            txtTime.Text = time;
            txtWeather.Text = RSS;
            imgCloudy.Source = new BitmapImage(WeatherImage);

        }


        public int updateCount = 0;
        public string external;
        private WeatherRSS.Weather weather = new WeatherRSS.Weather();
        Uri WeatherImage = new Uri("http://s3.amazonaws.com/gt-production-icons/icons/icon/62225.jpg?1348580377");
    
        private string RSS;

        public void pingEvent(object sender, ElapsedEventArgs e)
        {
            netavailable = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
            
                if (netavailable == false)
                {
                    pingtime = "Disconnected";
                }
                else if (netavailable == true)
                {
                    //tests ping time
                    pingtime = Convert.ToString(GetPingMS("www.easytel.com"))+ " ms";
                }        
        }

        int GetPingMS(string hostNameOrAddress)
        {
            System.Net.NetworkInformation.Ping ping = new System.Net.NetworkInformation.Ping();
            return Convert.ToInt32(ping.Send(hostNameOrAddress).RoundtripTime);
        }

        public System.Timers.Timer cTimer = new System.Timers.Timer();
        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            cancel.Opacity = 0;
          
            bw.RunWorkerAsync();

            RSS = "Collecting Candy...";

            // Makes all textboxes readonly
            txtTotalReceived.IsReadOnly = true;
            txtTotalSent.IsReadOnly = true;
            txtNetOut.IsReadOnly = true;
            txtNetIn.IsReadOnly = true;
            txtPing.IsReadOnly = true;
            txtRam.IsReadOnly = true;
            txtRamPercent.IsReadOnly = true;
            //txtRamUsed.IsReadOnly = true;
            txtDriveSpace.IsReadOnly = true;
            //txtPoint.IsReadOnly = true;
            txtUpdates.IsReadOnly = true;
            txtLocal.IsReadOnly = true;
            txtExternal.IsReadOnly = true;
            txtWeather.IsReadOnly = true; 

            // Make timer for network usage.
            System.Timers.Timer aTimer = new System.Timers.Timer();
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);

            // Set the Interval to 1 seconds.
            aTimer.Interval = 1000;
            aTimer.Enabled = true;

            // Make timer for ping and IP Address time.
            System.Timers.Timer bTimer = new System.Timers.Timer();
            bTimer.Elapsed += new ElapsedEventHandler(pingEvent);

            // Set the Interval to 5 seconds.
            bTimer.Interval = 5000;
            bTimer.Enabled = true;

            // Make timer for System Update check, and weather.
            // System.Timers.Timer cTimer = new System.Timers.Timer();
            cTimer.Elapsed += new ElapsedEventHandler(fifteenMinutes);

            // Set the Interval to 15 minutes.
            cTimer.Interval = 1000;//900000;
            cTimer.Enabled = true;
        }

     
        public void fifteenMinutes(object sender, ElapsedEventArgs e)
        {
            cTimer.Interval = 900000;
            //updateCount = 0;
            UpdateSessionClass uSession = new UpdateSessionClass();
            IUpdateSearcher uSearcher = uSession.CreateUpdateSearcher();
            ISearchResult uResult = uSearcher.Search("IsInstalled=0 and Type='Software'");
            updateCount = uResult.Updates.Count;

            if (netavailable == true)
            {
                RSS = weather.CurrentConditions();
                WeatherImage = new Uri(weather.getImage());

                //Grabs External IP Address, and uses the HTTPGet Class
                HTTPGet req = new HTTPGet();
                req.Request("http://checkip.dyndns.org");
                string[] a = req.ResponseBody.Split(':');
                string a2 = a[1].Substring(1);
                string[] a3 = a2.Split('<');
                string a4 = a3[0];
                ipExternal = a4;

                //Grabs Local IP Address
                ipLocal = "";
                IPAddress[] localIPs = Dns.GetHostAddresses(Dns.GetHostName());
                int iter = 0;
                foreach (IPAddress i in localIPs)
                {
                    string IP = i.ToString();
                    bool isIP = IP.Contains(".");
                    if (isIP == true)
                        ipLocal += IP + "\r\n";
                    iter++;
                }
            }
            
        }

        private double upLoadOld = 0.0;
        private double upLoadNew = 0.0;
        private double upLoadTotal = 0.0;
        private double downLoadOld = 0.0;
        private double downLoadNew = 0.0;
        private double downLoadTotal = 0.0;
        private string pingtime;
        
        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            //Grabs all the needed info for network usage
            NetworkInterface ni = interfaces[2];
            
            upLoadNew = (ni.GetIPv4Statistics().BytesSent / 131072.0);
            upLoadTotal = upLoadNew - upLoadOld;

            //changes text between Mbps and Kbps
            if (netavailable == true)
            {
                if (upLoadTotal > 1)
                {
                    bytesSent = (upLoadTotal).ToString("f2") + " Mbps";
                    upLoadOld = upLoadNew;
                }
                else
                {
                    bytesSent = (upLoadTotal * 1024).ToString("f2") + " Kbps";
                    upLoadOld = upLoadNew;
                }

                downLoadNew = (ni.GetIPv4Statistics().BytesReceived / 131072.0);
                downLoadTotal = downLoadNew - downLoadOld;
                if (downLoadTotal > 1)
                {
                    bytesRecieved = (downLoadTotal).ToString("f2") + " Mbps";
                    downLoadOld = downLoadNew;
                }
                else
                {
                    bytesRecieved = (downLoadTotal * 1024).ToString("f2") + " Kbps";
                    downLoadOld = downLoadNew;
                }
            }
            

        }

        private void locationWindow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (locationWindow.WindowStyle == System.Windows.WindowStyle.None)
            {

                locationWindow.WindowStyle = System.Windows.WindowStyle.SingleBorderWindow;
                cancel.Opacity = 0;
                this.Left -= 3;
                this.Top -= 26;
                this.Height += 20;
            }
            else
            {
                locationWindow.WindowStyle = System.Windows.WindowStyle.None;

                cancel.Opacity = 100;
                this.Left += 3;
                this.Top += 26;
                this.Height -= 20;
            }
        }
        private Winky.Window1 newWindow = new Winky.Window1();
        private System.Timers.Timer uTimer = new System.Timers.Timer();
        private void settings_Click(object sender, RoutedEventArgs e)
        {
            newWindow.Show();
            
            uTimer.Elapsed += new ElapsedEventHandler(updateSettings);

            uTimer.Interval = 500;
            uTimer.Enabled = true;
            
        }

        private void updateSettings(object sender, ElapsedEventArgs e)
        {
            
            
            string location;
            if (!newWindow.IsVisible)
            {
                location = newWindow.location;
                cTimer.Stop();
                cTimer.Start();
                uTimer.Stop();
            }
        }
    }
 }


 