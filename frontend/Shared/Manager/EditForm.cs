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
            string path = ManagerService.ApiFullAddress + "/" + _selectedItem.id;
            await OnConfirmChanges(HttpMethod.Put, _selectedItem, path);
        }

        protected async Task OnDelete()
        {
            string path = ManagerService.ApiFullAddress + "/" + _selectedItem.id;
            await OnConfirmChanges(HttpMethod.Delete, _selectedItem, path);
        }
    }
}