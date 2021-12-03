
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace tests.Integrationtests
{
    // [Collection("API tests")]
    public class ZonesControllerTests : IntegrationTests
    {
        [Fact]
        public async Task Post()
        {
            //Given
            Dictionary<string, dynamic> requestBody = new();
            requestBody.Add("name", "Main Hall");

            //When
            //Post item to server
            (HttpResponseMessage Message, IDictionary<string, dynamic> Body) postResponse =
                await Request<IDictionary<string, dynamic>>(HttpMethod.Post, "/Zones", requestBody);
            string id = postResponse.Body["zoneDetaile"].GetProperty("id").ToString();

            //Get item from server
            (HttpResponseMessage Message, List<IDictionary<string, dynamic>> Body) getResponse =
                await Request<List<IDictionary<string, dynamic>>>(HttpMethod.Get, "/Zones");
            var getResponseBody = getResponse.Body.Find(x => x["id"].ToString() == id);

            //Then
            Assert.Equal("OK", postResponse.Message.StatusCode.ToString());

            Assert.Equal(requestBody["name"].ToString(),
                         getResponseBody["name"].ToString());

            //Clean
            await Request<None>(HttpMethod.Delete, $"/Zones/{id}");
        }

        [Fact]
        public async Task Put()
        {
            //Given
            Dictionary<string, dynamic> postRequestBody = new();
            postRequestBody.Add("name", "AAU");

            Dictionary<string, dynamic> putRequestBody = new();
            putRequestBody.Add("name", "DGI");

            //When
            //Post item to server
            (HttpResponseMessage Message, IDictionary<string, dynamic> Body) postResponse =
                await Request<IDictionary<string, dynamic>>(HttpMethod.Post,
                                                            "/Zones",
                                                            postRequestBody);
            string id = postResponse.Body["zoneDetaile"].GetProperty("id").ToString();

            //Update(put) item on server
            (HttpResponseMessage Message, IDictionary<string, dynamic> Body) putResponse =
                await Request<IDictionary<string, dynamic>>(HttpMethod.Put,
                                                            $"/Zones/{id}",
                                                            putRequestBody);

            //Get item from server
            (HttpResponseMessage Message, List<IDictionary<string, dynamic>> Body) getResponse =
                await Request<List<IDictionary<string, dynamic>>>(HttpMethod.Get, "/Zones");
            var getResponseBody = getResponse.Body.Find(x =>
                x["id"].ToString() == id);

            //Then
            Assert.Equal("OK", putResponse.Message.StatusCode.ToString());

            Assert.Equal(putRequestBody["name"].ToString(),
                         getResponseBody["name"].ToString());

            //Clean
            await Request<None>(HttpMethod.Delete, $"/Zones/{id}");
        }

        [Fact]
        public async Task Delete()
        {
            //Given
            Dictionary<string, dynamic> postRequestBody = new();
            postRequestBody.Add("name", "Placeholder Poster");
            postRequestBody.Add("imageUrl", "https://via.placeholder.com/1080x1920");
            postRequestBody.Add("institution", 1);

            //When
            //Post item to the server
            (HttpResponseMessage Message, IDictionary<string, dynamic> Body) postResponse =
                await Request<IDictionary<string, dynamic>>(HttpMethod.Post, "/Zones", postRequestBody);
            string id = postResponse.Body["zoneDetaile"].GetProperty("id").ToString();

            //Delete item from server
            (HttpResponseMessage Message, IDictionary<string, dynamic> Body) deleteResponse =
                await Request<IDictionary<string, dynamic>>(HttpMethod.Delete, $"/Zones/{id}");

            //Get item from server
            (HttpResponseMessage Message, List<IDictionary<string, dynamic>> Body) getResponse =
                await Request<List<IDictionary<string, dynamic>>>(HttpMethod.Get, "/Zones");
            var getResponseBody = getResponse.Body.Find(x =>
                x["id"].ToString() == id);

            //Then
            Assert.Equal("OK", deleteResponse.Message.StatusCode.ToString());
            Assert.Null(getResponseBody);
        }
    }
}