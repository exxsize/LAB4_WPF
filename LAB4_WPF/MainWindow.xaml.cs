using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace LAB4_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer1 = new DispatcherTimer();
        int t;
        public MainWindow()
        {
            InitializeComponent();
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("ru-RU");
            timer1.Interval = TimeSpan.FromMilliseconds(1000);
            timer1.Tick += timer1_Tick;
            timer1.Start();
            timer1_Tick(null, null);
        }

        void timer1_Tick(object sender, EventArgs e)
        {
            if ((bool)checkBox1.IsChecked)
            {
                t++;
                label1.Text = String.Format("{0}:{1}", t / 10, t % 10);
            }
            else
            label1.Text = DateTime.Now.ToLongTimeString();
        }

         private void checkBox1_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)checkBox1.IsChecked)
            {
                t = -1;
                timer1.Interval = TimeSpan.FromMilliseconds(100);
            }
            else
                timer1.Interval = TimeSpan.FromMilliseconds(1000);
            timer1_Tick(null, null);
            button1.IsEnabled = button2.IsEnabled = (bool)checkBox1.IsChecked;
            timer1.IsEnabled = true;
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            timer1.IsEnabled = !timer1.IsEnabled;
        }
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            timer1.IsEnabled = false;
            t = 0;
            label1.Text = "0:0";
        }
    }
}
