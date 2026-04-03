using System.Diagnostics;
using System.IO.Ports;
namespace WemosClock.Services;

public class ComPort
{
    protected static SerialPort _serialPort = new();

    /// <summary>
    /// Инициализаци порта, настройки подключения
    /// </summary>
    /// <param name="comport"></param>
    /// <param name="baudRate"></param>
    protected static void Init(string comport, int baudRate)
    {
        _serialPort.PortName = comport;
        _serialPort.BaudRate = baudRate;
        _serialPort.DataBits = 8;
        _serialPort.DtrEnable = true;

        _serialPort.ReadTimeout = 500;
        _serialPort.WriteTimeout = 500;
        _serialPort.Handshake = Handshake.None;
        // _serialPort.DataReceived += SerialPortDataReceived;
    }

    /// <summary>
    /// Открывает порт для чтения или записи данных
    /// </summary>
    /// <returns></returns>
    protected static bool Open()
    {   
        _serialPort.Open();
        return _serialPort.IsOpen;
    }

    /// <summary>
    /// Закрывает порт 
    /// </summary>
    /// <returns></returns>
    protected static bool Close()
    {
        _serialPort.Close();
        return _serialPort.IsOpen;
    }

    /// <summary>
    /// Закрывает порт 
    /// </summary>
    /// <param name="message"></param>
    protected static void Write(string message){
        _serialPort.WriteLine(message);
    }

    /// <summary>
    /// Читает строку из com порта
    /// </summary>
    // protected static void ReadLine()
    // {
    //     try
    //     {
    //         string message = _serialPort.ReadLine();
    //         Console.WriteLine(message);
    //     }
    //     catch (TimeoutException) { }
    // }

    /// <summary>
    /// Выводит данные по событию SerialDataReceivedEventArgs
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    // protected static void SerialPortDataReceived(object sender, SerialDataReceivedEventArgs e)
    // {
    //     SerialPort port = (SerialPort)sender;
    //     string data = port.ReadExisting();
    //     Console.WriteLine($"Получено: {data.Trim()}");
    // }
}
