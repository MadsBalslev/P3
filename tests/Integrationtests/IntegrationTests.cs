using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using server;

namespace tests.Integrationtests
{
    public class IntegrationTests
    {
        protected readonly HttpClient _client;

        protected readonly WebApplicationFactory<Startup> _factory;

        public IntegrationTests()
        {
            _factory = new WebApplicationFactory<Startup>();
            _client = _factory.CreateClient();
        }

        public async Task<(HttpResponseMessage, responseT)>
            Request<responseT>(HttpMethod method, string url, IDictionary<string, dynamic> requestBody = null)
        {
            HttpRequestMessage request = new HttpRequestMessage(method, url);
            request.Headers.Add("Authorization", "Basic YWRtaW46JDJhJDExJGdYVFdVbWhqYmhiak9xelQ2QW5mVk9SZlBqVlhUL3c0VVFoUFhrcjNHNnZzVnM3eFEzYS9D");

            if (requestBody != null)
            {
                string requestMessage = JsonSerializer.Serialize(requestBody);
                request.Content = new StringContent(requestMessage, Encoding.UTF8, "application/Json");
            }

            HttpResponseMessage response = await _client.SendAsync(request);

            using Stream responseStream = await response.Content.ReadAsStreamAsync();
            responseT responseBody =
                await JsonSerializer.DeserializeAsync<responseT>(responseStream);

            return (response, responseBody);
        }
    }
}