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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xamlasdf
    /// </summary>
    public partial class MainWindow : Window
    {
        //public PerformanceCounter cpuCounter;
        public MainWindow()
        {
            InitializeComponent();

            cpuUsage.Maximum = 100;

            bw.WorkerSupportsCancellation = true;
            bw.WorkerReportsProgress = true;
            bw.DoWork +=
                new DoWorkEventHandler(bw_DoWork);
            bw.ProgressChanged +=
                new ProgressChangedEventHandler(bw_ProgressChanged);
            bw.RunWorkerCompleted +=
                new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
        }

        BackgroundWorker bw = new BackgroundWorker();

        private void Async_Click(object sender, RoutedEventArgs e)
        {
            if (bw.IsBusy != true)
            {
                bw.RunWorkerAsync();
            }
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            if (bw.WorkerSupportsCancellation == true)
            {
                bw.CancelAsync();
            }
        }
        public float asdfa;
        private int number = 0;
        public PerformanceCounter cpuCounter = new PerformanceCounter();
        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;

            cpuCounter = new PerformanceCounter();
            cpuCounter.CategoryName = "Processor";
            cpuCounter.CounterName = "% Processor Time";
            cpuCounter.InstanceName = "_Total";
            float[] avg = new float[10];
            while (true)//for (int i = 1; (i <= 10); i++)
            {
                //HTTPGet req = new HTTPGet();
                //req.Request("http://checkip.dyndns.org");
                //string[] a = req.ResponseBody.Split(':');
                //string a2 = a[1].Substring(1);
                //string[] a3 = a2.Split('<');
                //string a4 = a3[0];
                //Console.WriteLine(a4);
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


                }
            }
        }
        private void bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //this.resultLabel.Text = (e.ProgressPercentage.ToString() + "%");
            avgBox.Text = asdfa.ToString();
            cpuUsage.Value = asdfa;

        }
        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((e.Cancelled == true))
            {
                //this.resultLabel.Text = "Canceled!";
            }

            else if (!(e.Error == null))
            {
                //this.resultLabel.Text = ("Error: " + e.Error.Message);
            }

            else
            {
                //this.resultLabel.Text = "Done!";
                //avgBox.Text = asdfa.ToString();
            }
        }
        
    }
}
