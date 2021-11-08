using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using MudBlazor;

public abstract class CreateForm<T> : ComponentBase where T : IManageable, new()
{
    [Inject]
    private IHttpClientFactory _clientFactory { get; set; }

    [Inject]
    private IManagerService _managerService { get; set; }

    private readonly APIAttribute _apiAttribute =
    Attribute.GetCustomAttribute(typeof(T), typeof(APIAttribute)) as APIAttribute;

    protected MudForm _form;

    protected T _precreateItem = new T();
    
    protected async Task OnAddItem()
    {
        await _form.Validate();
        if (_form.IsValid)
        {
            // BUG _form.Reset does not work, this seems to be a problem with MudBlazor
            // _form.Reset();

            await PostItem();
            await _managerService.RequestRefresh();

            // this is not a great solution to the problem above as it breaks the DatePickers :(
            _precreateItem = new T();
            _form.ResetValidation();
        }
    }

    protected async Task PostItem()
    {
        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, _apiAttribute.APIPath);
        string requestMessage = _precreateItem.ToJSON();
        request.Content = new StringContent(requestMessage, Encoding.UTF8, "application/Json");

        HttpClient client = _clientFactory.CreateClient();

        HttpResponseMessage response = await client.SendAsync(request);

        if (response.IsSuccessStatusCode)
        {
        }
    }
}