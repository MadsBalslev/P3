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
            await OnRequestAction(HttpMethod.Post, FullApiAddress(), _selectedItem, validate:true);
        }

        protected async Task OnDelete()
        {
            await OnRequestAction(HttpMethod.Delete, FullApiAddress(), _selectedItem, validate:false);
        }

        private string FullApiAddress()
        {
            return ManagerService.ApiPath + "/" + _selectedItem.id;
        }
    }
}