using System;
using System.Threading.Tasks;

namespace frontend.Shared.Manager
{
    public class ManagerService : IManagerService
    {
        public string ApiFullAddress { get; set; }

        public event Func<Task> RefreshRequested;

        public async Task RequestRefresh()
        {
            await RefreshRequested?.Invoke();
        }
    }
}