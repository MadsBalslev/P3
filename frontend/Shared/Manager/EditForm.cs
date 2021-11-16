using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;

namespace frontend.Shared.Manager
{
    public abstract class EditForm<T> : ManagerForm<T> where T : IManageable, new()
    {

        [CascadingParameter]
        protected T _selectedItem { get; set; }

        protected async Task OnEditItem()
        {
            string path = _apiAttribute.APIPath + "/" + _selectedItem.Id;
            await OnConfirmChanges(HttpMethod.Put, _selectedItem, path);
        }

        protected async Task OnDelete()
        {
            string path = _apiAttribute.APIPath + "/" + _selectedItem.Id;
            await OnConfirmChanges(HttpMethod.Delete, _selectedItem, path);
        }
    }
}