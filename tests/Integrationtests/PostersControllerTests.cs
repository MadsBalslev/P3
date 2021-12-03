using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace tests.Integrationtests
{
    // [Collection("API tests")]
    public class PostersControllerTests : IntegrationTests
    {
        [Fact]
        public async Task Post()
        {
            //Given
            Dictionary<string, dynamic> requestBody = new();
            requestBody.Add("name", "Placeholder Poster");
            requestBody.Add("imageUrl", "https://via.placeholder.com/1080x1920");
            requestBody.Add("institution", 1);

            //When
            //Post item to server
            (HttpResponseMessage Message, IDictionary<string, dynamic> Body) postResponse =
                await Request<IDictionary<string, dynamic>>(HttpMethod.Post, "/Posters", requestBody);

            //Get item from server
            (HttpResponseMessage Message, List<IDictionary<string, dynamic>> Body) getResponse =
                await Request<List<IDictionary<string, dynamic>>>(HttpMethod.Get, "/Posters");
            var getResponseBody = getResponse.Body.Find(x =>
                x["id"].ToString() == postResponse.Body["id"].ToString());

            //Then
            Assert.Equal("OK", postResponse.Message.StatusCode.ToString());

            Assert.Equal(requestBody["name"].ToString(),
                         getResponseBody["name"].ToString());

            Assert.Equal(requestBody["imageUrl"].ToString(),
                         getResponseBody["image"].ToString());

            Assert.Equal(requestBody["institution"].ToString(),
                         getResponseBody["institution"].GetProperty("id").ToString());

            //Clean
            await Request<None>(HttpMethod.Delete, $"/Posters/{postResponse.Body["id"]}");
        }

        [Fact]
        public async Task Put()
        {
            //Given
            Dictionary<string, dynamic> postRequestBody = new();
            postRequestBody.Add("name", "Placeholder Poster");
            postRequestBody.Add("imageUrl", "https://via.placeholder.com/1080x1920");
            postRequestBody.Add("institution", 1);

            Dictionary<string, dynamic> putRequestBody = new();
            putRequestBody.Add("name", "Placeholder Poster New Format!");
            putRequestBody.Add("imageUrl", "https://via.placeholder.com/1920x1080");

            //When
            //Post item to server
            (HttpResponseMessage Message, IDictionary<string, dynamic> Body) postResponse =
                await Request<IDictionary<string, dynamic>>(HttpMethod.Post, "/Posters", postRequestBody);
            string id = postResponse.Body["id"].ToString();

            //Update(put) item on server
            (HttpResponseMessage Message, IDictionary<string, dynamic> Body) putResponse =
                await Request<IDictionary<string, dynamic>>(HttpMethod.Put,
                                                            $"/Posters/{id}",
                                                            putRequestBody);

            //Get item from server
            (HttpResponseMessage Message, List<IDictionary<string, dynamic>> Body) getResponse =
                await Request<List<IDictionary<string, dynamic>>>(HttpMethod.Get, "/Posters");
            var getResponseBody = getResponse.Body.Find(x =>
                x["id"].ToString() == postResponse.Body["id"].ToString());

            //Then
            Assert.Equal("OK", putResponse.Message.StatusCode.ToString());

            Assert.Equal(putRequestBody["name"].ToString(),
                         getResponseBody["name"].ToString());

            Assert.Equal(putRequestBody["imageUrl"].ToString(),
                         getResponseBody["image"].ToString());

            //Clean
            await Request<None>(HttpMethod.Delete, $"/Posters/{postResponse.Body["id"]}");
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
                await Request<IDictionary<string, dynamic>>(HttpMethod.Post, "/Posters", postRequestBody);
            string id = postResponse.Body["id"].ToString();

            //Delete item from server
            (HttpResponseMessage Message, IDictionary<string, dynamic> Body) deleteResponse =
                await Request<IDictionary<string, dynamic>>(HttpMethod.Delete, $"/Posters/{id}");

            //Get item from server
            (HttpResponseMessage Message, List<IDictionary<string, dynamic>> Body) getResponse =
                await Request<List<IDictionary<string, dynamic>>>(HttpMethod.Get, "/Posters");
            var getResponseBody = getResponse.Body.Find(x =>
                x["id"].ToString() == postResponse.Body["id"].ToString());

            //Then
            Assert.Equal("OK", deleteResponse.Message.StatusCode.ToString());
            Assert.Null(getResponseBody);
        }
    }}