using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;


public abstract class CreateForm<T> : ComponentBase where T : IManageable, new()
{
    private readonly APIAttribute _apiAttribute =
    Attribute.GetCustomAttribute(typeof(T), typeof(APIAttribute)) as APIAttribute;

    protected T _precreateItem = new T();

    [Inject]
    private IHttpClientFactory _clientFactory { get; set; }

    public async Task PostItem()
    {
        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, _apiAttribute.APIPath);
        string requestMessage = _precreateItem.ToJSON();
        request.Content = new StringContent(requestMessage, Encoding.UTF8, "application/Json");

        HttpClient client = _clientFactory.CreateClient();

        HttpResponseMessage response = await client.SendAsync(request);

        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine(response.RequestMessage);

        }
    }

    // [Parameter]
    // public EventCallback<T> OnAddPoster { get; set; }

    // [Parameter]
    // public EventCallback OnCancel { get; set; }



}