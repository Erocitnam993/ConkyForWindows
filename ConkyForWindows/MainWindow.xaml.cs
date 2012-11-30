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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public PerformanceCounter cpuCounter;
        public MainWindow()
        {
            InitializeComponent();
            
        }
        private int number = 0;
        
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            
            textBox1.Text = Convert.ToInt32((asdfa-5)).ToString();
            
        }
        public float asdfa;
        public void Avg()
        {
            
            float[] avg = new float[100];
            while (stop==false)
            {
                avg[number] = cpuCounter.NextValue();//getCurrentCpuUsage();
                number++;
                asdfa = avg.Average();
                string aasdf = asdfa.ToString();
                if (number > 99)
                {
                    number = 0;
                    //thing();
                    //textBox1.Text = avg.Average().ToString();
                }
                Thread.Sleep(50);
                //Dispatcher.BeginInvoke(textBox1.Text = aasdf,asdfa);
                //textBox1.Text = asdfa.ToString();
            }

        }




        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cpuCounter = new PerformanceCounter();
            cpuCounter.CategoryName = "Processor";
            cpuCounter.CounterName = "% Processor Time";
            cpuCounter.InstanceName = "_Total";

            Thread t = new Thread(new ThreadStart(Avg));
            t.Start();
            Thread.Sleep(1);
            
            
        }
        public bool stop = false;
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            stop = true;
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            textBox1.Text = Convert.ToInt32((asdfa - 5)).ToString();
        }

        
    }
}
