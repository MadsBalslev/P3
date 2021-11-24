using System;
using System.Threading.Tasks;

namespace frontend.Shared.Manager
{
    public class ManagerService : IManagerService
    {
        public string ApiPath { get; set; }

        public event Func<Task> RefreshRequested;

        public async Task RequestRefresh()
        {
            await RefreshRequested?.Invoke();
        }
    }
}