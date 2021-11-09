using System;
using System.Threading.Tasks;

public interface IManagerService<T>
{
    event Func<Task> RefreshRequested;
    Task RequestRefresh();
    public T SelectedItem { get; set; }
}