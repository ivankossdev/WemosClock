using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WemosClock.Services;

public interface IComportService
{
    event Action<string>? DataReceived;
    IEnumerable<string> SearchDevices();
    void Init(string comport, int baudRate);
    public bool Open();
    public bool Close();
    public void Write(string message);
}