using System.Diagnostics;
using System.IO.Ports;
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

namespace Arduino.SerialPort.Visual
{
 
    public partial class MainWindow : Window
    {
        Random r = new Random();
        System.IO.Ports.SerialPort serialPort = new System.IO.Ports.SerialPort("COM4", 9600);
        string DATA_ = "";
        public MainWindow()
        {
            InitializeComponent();

            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
             
            serialPort.ReadTimeout = 4000;
            serialPort.WriteTimeout = 4000;
            serialPort.Encoding = Encoding.UTF8;
            serialPort.DataReceived += SerialPort_DataReceived;
            try
            {
                serialPort.Open();
            }
            catch (Exception ee)
            {

                MessageBox.Show(ee.Message);
            }
            
        }
        string[] array_ = { };
        string[] array_2 = { };
        Dictionary<string, string> map_ = new Dictionary<string, string>();
        void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                DATA_ = serialPort.ReadExisting().Replace("\n" , "|");



                array_ = DATA_.Split("|");
                foreach (var item in array_)
                {
                    array_2 = item.Split(":");
                    if (array_2.Length == 1)
                        continue;
                    if (map_.ContainsKey(array_2[0]))
                    {
                        map_[array_2[0]] = array_2[1];
                    }
                    else
                    {
                        map_.Add(array_2[0], array_2[1]);
                    }
                }
                foreach (var item in map_)
                {
                    Debug.WriteLine($"{item.Key}: {item.Value}");

                    switch (item.Key)
                    {

                        case "4":
                            if(item.Value == "1")
                                this.Dispatcher.BeginInvoke(() =>
                                {
                                    _border.Background = new SolidColorBrush(Color.FromRgb((byte)r.Next(1, 255), (byte)r.Next(1, 255), (byte)r.Next(1, 233)));

                                });

                            break;
                        default:
                            break;
                    }


                }

               



            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}