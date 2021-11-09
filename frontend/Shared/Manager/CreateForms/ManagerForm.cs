using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using MudBlazor;

public abstract class ManagerForm<T> : ComponentBase where T : IManageable, new()
{
    protected readonly APIAttribute _apiAttribute =
    Attribute.GetCustomAttribute(typeof(T), typeof(APIAttribute)) as APIAttribute;

    protected MudForm _form;

    [Inject]
    private ISnackbar _snackbar { get; set; }

    [Inject]
    private IHttpClientFactory _clientFactory { get; set; }

    [Inject]
    protected IManagerService<T> _managerService { get; set; }

    protected async Task<HttpResponseMessage> UpdateModelWithItem(HttpMethod method, T item, string path)
    {
        Debug.Assert(method == HttpMethod.Post || method == HttpMethod.Put || method == HttpMethod.Delete);

        HttpRequestMessage request = new HttpRequestMessage(method, path);
        string requestMessage = item.ToJSON();
        request.Content = new StringContent(requestMessage, Encoding.UTF8, "application/Json");

        HttpClient client = _clientFactory.CreateClient();

        HttpResponseMessage response = await client.SendAsync(request);

        return response;
    }

    protected async Task OnConfirmChanges(HttpMethod method, T item, string path)
    {
        await _form.Validate();
        if (_form.IsValid)
        {
            HttpResponseMessage response = await UpdateModelWithItem(method, item, path);

            if (response.IsSuccessStatusCode)
            {
                _snackbar.Add("Action successful", Severity.Success);
            }
            else
            {
                _snackbar.Add("Action failed!", Severity.Error);
            }


            _form.Reset();
            _form.ResetValidation();
            await _managerService.RequestRefresh();
        }
    }
}