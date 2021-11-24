using System.Net.Http;
using System.Threading.Tasks;

namespace frontend.Shared.Manager
{
    public abstract class CreateForm<T> : ManagerForm<T> where T : IManageable, new()
    {
        protected T _precreateItem = new T();

        protected override void OnInitialized()
        {
            base.OnInitialized();
            _precreateItem.InitializeAggregateObjects();
        }

        protected async Task OnAddItem()
        {
            await OnRequestAction(HttpMethod.Post, ManagerService.ApiPath, _precreateItem, validate: true);
        }
    }
}