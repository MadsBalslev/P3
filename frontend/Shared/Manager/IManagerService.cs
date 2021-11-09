using System;
using System.Threading.Tasks;

namespace frontend.Shared.Manager
{
    public interface IManagerService
    {
        event Func<Task> RefreshRequested;
        Task RequestRefresh();
        ManagerMode CurrentMode { get; set; }
    }
}