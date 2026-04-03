using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO.Ports;
using System; 

namespace WemosClock.Services;

public class ComportService : IComportService
{
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
                _portList.Add($"[ {i} ] {ports[i]}");
            }
        }
        return _portList;
    }
}