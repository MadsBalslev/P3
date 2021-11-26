using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using MudBlazor;

namespace frontend.Shared
{
    public abstract class ApiComponent : ComponentBase
    {

        [Inject]
        public ISnackbar Snackbar { get; set; }

        [Inject]
        public IHttpClientFactory ClientFactory { get; set; }

        [Inject]
        public IConfiguration Configuration { get; set; }

        [Inject]
        public ICurrentUserService CurrentUserService { get; set; }

        protected async Task<ReturnT> RequestHandler<InputT, ReturnT>(HttpMethod method,
                                                                      string ApiPath,
                                                                      InputT body = default,
                                                                      MudForm optionalForm = null,
                                                                      string requestSuccessPopup = null,
                                                                      string ErrorPopup = "Something went wrong: ")
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
                        DisplayNotNullPopup(requestSuccessPopup, Severity.Success);
                        return responseBody;
                    }
                    else
                    {
                        throw new Exception(response.StatusCode.ToString());
                    }
                }
                else
                {
                    return default;
                }
            }
            catch (Exception e)
            {
                Snackbar.Add($"{ErrorPopup}{e.Message}", Severity.Error);
                return default;
                // throw;

                // TODO it's probably better that this catch statement retrows the error, as
                // RequestHandler() is only responsible for loggin the error to the user, not
                // fixing it.
                // Though this will break the system in several places in subtle ways hmmm.
            }
        }

        private void DisplayNotNullPopup(string popup, Severity severity)
        {
            if (popup != null)
                Snackbar.Add(popup, severity);
        }

        protected async Task<HttpResponseMessage> ApiRequest<InputT>(HttpMethod method,
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
            request.Headers.Add("Authorization", $"Basic {CurrentUserService.Authorization}");
            HttpClient client = ClientFactory.CreateClient();

            if (body != null)
            {
                string requestMessage = body.ToJSON();
                Console.WriteLine("HAHAAAHHA" + requestMessage);
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
}