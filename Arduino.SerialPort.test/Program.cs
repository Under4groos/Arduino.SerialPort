





using System.Diagnostics;
using System.IO.Ports;
using System.Text;
using System.Text.Unicode;

Console.WriteLine("Startup");

SerialPort serialPort = new SerialPort("COM4", 9600);
serialPort.ReadTimeout = 4000;
serialPort.WriteTimeout = 4000;
serialPort.Encoding = Encoding.UTF8;
serialPort.DataReceived += SerialPort_DataReceived;
 

byte[] bytes;
string data_ = "";
void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
{
    try
    {
        data_ = serialPort.ReadExisting();
        
    }
    catch (Exception exception)
    {
        Console.WriteLine(exception.Message);
    }
};

bool b = false;



while (true)
{
    
    if (serialPort.IsOpen && b == false)
    {
       
    }
    else
    {
        serialPort.Open();
      
    }

}


