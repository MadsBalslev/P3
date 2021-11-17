using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using MudBlazor;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace frontend.Shared.Manager
{
    public abstract class ManagerForm<T> : ComponentBase where T : IManageable, new()
    {
        protected readonly APIAttribute _apiAttribute =
        Attribute.GetCustomAttribute(typeof(T), typeof(APIAttribute)) as APIAttribute;

        protected MudForm _form;

        [Inject]
        private ISnackbar Snackbar { get; set; }

        [Inject]
        private IHttpClientFactory ClientFactory { get; set; }

        [Inject]
        protected IManagerService ManagerService { get; set; }

        [Inject]
        protected IConfiguration Configuration { get; set; }

        protected async Task<HttpResponseMessage> UpdateModelWithItem(HttpMethod method, T item, string path)
        {
            Debug.Assert(method == HttpMethod.Post || method == HttpMethod.Put || method == HttpMethod.Delete);

            HttpRequestMessage request = new HttpRequestMessage(method, path);
            string requestMessage = item.ToJSON();
            Console.WriteLine(requestMessage);
            request.Content = new StringContent(requestMessage, Encoding.UTF8, "application/Json");

            HttpClient client = ClientFactory.CreateClient();

            HttpResponseMessage response = await client.SendAsync(request);

            return response;
        }

        protected async Task OnConfirmChanges(HttpMethod method, T item, string path)
        {
            try
            {
                await _form.Validate();
                if (_form.IsValid)
                {
                    HttpResponseMessage response = await UpdateModelWithItem(method, item, path);

                    if (response.IsSuccessStatusCode)
                    {
                        Snackbar.Add("Action successful", Severity.Success);
                    }
                    else
                    {
                        Snackbar.Add($"Action failed!, status code: {response.StatusCode}", Severity.Error);
                    }
                }
            }
            catch (Exception e)
            {
                Snackbar.Add($"Something went wrong: {e.Message}", Severity.Error);
            }
            finally
            {
                await RefreshManager();
            }
        }

        protected async Task OnCancel()
        {
            await RefreshManager();
        }

        protected string GetPath()
        {
            return Configuration.GetValue<string>("ApiBaseAdress") + _apiAttribute.ApiPath + "/";
        }

        private async Task RefreshManager()
        {
            _form.Reset();
            _form.ResetValidation();
            await ManagerService.RequestRefresh();
        }
    }
}