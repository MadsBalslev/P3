using System;
using System.Threading.Tasks;

namespace frontend.Shared.Manager
{
    public interface IManagerService
    {

        string ApiFullAddress { get; set; }
        event Func<Task> RefreshRequested;
        Task RequestRefresh();
    }
}