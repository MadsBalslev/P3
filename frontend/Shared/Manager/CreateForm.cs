using System.Net.Http;
using System.Threading.Tasks;

namespace frontend.Shared.Manager
{
    public abstract class CreateForm<T> : ManagerForm<T> where T : IManageable, new()
    {
        protected T _precreateItem = new T();

        protected async Task OnAddItem()
        {
            await OnConfirmChanges(HttpMethod.Post, _precreateItem, _apiAttribute.APIPath);

        }
    }
}