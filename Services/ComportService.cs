using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO.Ports;
using System; 

namespace WemosClock.Services;

public class ComportService : IComportService
{
    public event Action<string>? DataReceived;
    protected static SerialPort _serialPort = new();
    List<string> _portList = []; 

    /// <summary>
    /// Поиск устройств 
    /// </summary>
    /// <returns></returns>
    public IEnumerable<string> SearchDevices()
    {
        string[] ports = SerialPort.GetPortNames();
        _portList.Clear();

        if (ports.Length > 0)
        {
            for (int i = 0; i < ports.Length; i++)
            {
                _portList.Add($"{ports[i]}");
            }
        }
        return _portList;
    }

    /// <summary>
    /// Инициализация порта
    /// </summary>
    /// <param name="comport"></param>
    /// <param name="baudRate"></param>
    public void Init(string comport, int baudRate)
    {
        _serialPort.PortName = comport;
        _serialPort.BaudRate = baudRate;
        _serialPort.DataBits = 8;
        _serialPort.DtrEnable = true;

        _serialPort.ReadTimeout = 500;
        _serialPort.WriteTimeout = 500;
        _serialPort.Handshake = Handshake.None;
        _serialPort.DataReceived += SerialPortDataReceived;
    }

    /// <summary>
    /// Выводит данные по событию SerialDataReceivedEventArgs
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void SerialPortDataReceived(object sender, SerialDataReceivedEventArgs e)
    {
        try
        {
            SerialPort port = (SerialPort)sender;
            string data = port.ReadLine();
            DataReceived?.Invoke(data.TrimEnd());
            //Console.WriteLine($"{data.TrimEnd()}");
        }
        catch (TimeoutException) {}
    }

    /// <summary>
    /// Открывает порт для чтения или записи данных
    /// </summary>
    /// <returns></returns>
    public bool Open()
    {   
        _serialPort.Open();
        return _serialPort.IsOpen;
    }

    /// <summary>
    /// Закрывает порт 
    /// </summary>
    /// <returns></returns>
    public bool Close()
    {
        _serialPort.Close();
        return _serialPort.IsOpen;
    }

    /// <summary>
    /// Закрывает порт 
    /// </summary>
    /// <param name="message"></param>
    public void Write(string message){
        _serialPort.WriteLine(message);
    }
}