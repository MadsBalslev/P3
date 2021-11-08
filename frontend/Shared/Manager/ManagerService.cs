using System;
using System.Threading.Tasks;

public class ManagerService : IManagerService
{
    public event Func<Task> RefreshRequested;

    public async Task RequestRefresh()
    {
        Console.WriteLine("RequestRefresh was called");
        await RefreshRequested?.Invoke();
    }
}