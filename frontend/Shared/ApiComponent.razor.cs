using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using frontend.Shared.Manager;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using MudBlazor;

public abstract class ApiComponent : ComponentBase
{

    [Inject]
    public ISnackbar Snackbar { get; set; }

    [Inject]
    public IHttpClientFactory ClientFactory { get; set; }

    [Inject]
    public IManagerService ManagerService { get; set; }

    [Inject]
    public IConfiguration Configuration { get; set; }

    [Inject]
    public IUser User { get; set; }

    protected async Task<ReturnT> onRequest<InputT, ReturnT>(HttpMethod method,
                                                              string ApiPath,
                                                              InputT body = default(InputT),
                                                              MudForm optionalForm = null,
                                                              string requestSuccessPopup = null,
                                                              string requestFailurePopup = null,
                                                              string exceptionPopup = null)
                                                              where InputT : IToJSON
    {
        if (optionalForm == null)
            optionalForm = new MudForm();

        try
        {
            await optionalForm.Validate();
            if (optionalForm.IsValid)
            {
                HttpResponseMessage response = await ApiRequest(method, ApiPath, body);

                if (response.IsSuccessStatusCode)
                {
                    ReturnT responseBody = await getResponseBody<ReturnT>(response);
                    DisplayPopup(requestSuccessPopup, Severity.Success);
                    return responseBody;
                }
                else
                {
                    DisplayPopup($"{requestFailurePopup}, status code: {response.StatusCode}", Severity.Error);
                    return default(ReturnT);
                }
            }
            else
            {
                return default(ReturnT);
            }
        }
        catch (Exception e)
        {
            Snackbar.Add($"{exceptionPopup}{e.Message}", Severity.Error);
            return default(ReturnT);
        }
    }

    private void DisplayPopup(string popup, Severity severity)
    {
        if (popup != null)
            Snackbar.Add(popup, severity);
    }

    private async Task<HttpResponseMessage> ApiRequest<InputT>(HttpMethod method,
                                                               string ApiPath,
                                                               InputT body) where InputT : IToJSON
    {
        if (method != HttpMethod.Post &&
            method != HttpMethod.Put &&
            method != HttpMethod.Delete &&
            method != HttpMethod.Get)
        {
            throw new NotImplementedException($"{method.ToString()} is not implemented");
        }

        string ApiFullAddress = Configuration.GetValue<string>("ApiBaseAddress") + ApiPath;
        HttpRequestMessage request = new HttpRequestMessage(method, ApiFullAddress);
        request.Headers.Add("Authorization", $"Basic {User.password}");
        HttpClient client = ClientFactory.CreateClient();

        if (body != null)
        {
            string requestMessage = body.ToJSON();
            request.Content = new StringContent(requestMessage, Encoding.UTF8, "application/Json");
        }

        HttpResponseMessage response = await client.SendAsync(request);
        return response;
    }

    private async Task<ReturnT> getResponseBody<ReturnT>(HttpResponseMessage response)
    {
        using Stream responseStream = await response.Content.ReadAsStreamAsync();
        return await JsonSerializer.DeserializeAsync<ReturnT>(responseStream);
    }
}

public interface IToJSON
{
    public string ToJSON();
}