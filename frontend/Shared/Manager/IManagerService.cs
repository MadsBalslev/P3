using System;
using System.Threading.Tasks;

namespace frontend.Shared.Manager
{
    public interface IManagerService
    {

        string ApiPath { get; set; }
        event Func<Task> RefreshRequested;
        Task RequestRefresh();
    }
}