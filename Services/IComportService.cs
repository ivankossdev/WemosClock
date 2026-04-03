using System.Collections.Generic;
using System.Threading.Tasks;

namespace WemosClock.Services;

public interface IComportService
{
    IEnumerable<string> SearchDevices();
}