using System;
using System.Threading.Tasks;

public class ManagerService<T> : IManagerService<T> where T : new()
{
    public event Func<Task> RefreshRequested;

    public async Task RequestRefresh()
    {
        await RefreshRequested?.Invoke();
    }

    public T SelectedItem { get; set; } = new();
}