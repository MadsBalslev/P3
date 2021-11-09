using System.Net.Http;
using System.Threading.Tasks;

public abstract class EditForm<T> : ManagerForm<T> where T : IManageable, new()
{
    protected async Task OnEditItem()
    {
        T item = _managerService.SelectedItem;
        string path = _apiAttribute.APIPath + "/" + item.Id;
        await OnConfirmChanges(HttpMethod.Put, item, path);
    }

    protected async Task OnDelete()
    {
        T item = _managerService.SelectedItem;
        string path = _apiAttribute.APIPath + "/" + item.Id;
        await OnConfirmChanges(HttpMethod.Delete, item, path);
    }
}