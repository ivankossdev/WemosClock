// ComportService.cs
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WemosClock.Services;

public class ComportService : IComportService
{
    public async Task<IEnumerable<string>> SearchDevicesAsync()
    {
        // Имитация длительного поиска
        await Task.Delay(1000);
        return new List<string> { "Устройство 1", "Устройство 2", "Устройство 3" };
    }
}