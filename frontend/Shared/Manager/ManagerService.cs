using System;
using System.Threading.Tasks;

namespace frontend.Shared.Manager
{
    public class ManagerService : IManagerService
    {
        public event Func<Task> RefreshRequested;

        public async Task RequestRefresh()
        {
            await RefreshRequested?.Invoke();
        }

        public ManagerMode CurrentMode { get; set; } = ManagerMode.Initial;
    }
}