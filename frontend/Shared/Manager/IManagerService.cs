using System;
using System.Threading.Tasks;

public interface IManagerService
{
    event Func<Task> RefreshRequested;
    Task RequestRefresh();
}
