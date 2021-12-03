using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace tests.Integrationtests
{
    // [Collection("API tests")]
    public class InstitutionsControllerTests : IntegrationTests
    {
        [Fact]
        public async Task Post()
        {
            //Given
            Dictionary<string, dynamic> requestBody = new();
            requestBody.Add("name", "AAU");

            //When
            //Post item to server
            (HttpResponseMessage Message, IDictionary<string, dynamic> Body) postResponse =
                await Request<IDictionary<string, dynamic>>(HttpMethod.Post, "/Institutions", requestBody);
            string id = postResponse.Body["institutionDetails"].GetProperty("id").ToString();

            //Get item from server
            (HttpResponseMessage Message, List<IDictionary<string, dynamic>> Body) getResponse =
                await Request<List<IDictionary<string, dynamic>>>(HttpMethod.Get, "/Institutions");
            var getResponseBody = getResponse.Body.Find(x => x["id"].ToString() == id);

            //Then
            Assert.Equal("OK", postResponse.Message.StatusCode.ToString());

            Assert.Equal(requestBody["name"].ToString(),
                         getResponseBody["name"].ToString());

            //Clean
            await Request<None>(HttpMethod.Delete, $"/Institutions/{id}");
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
                                                            "/Institutions",
                                                            postRequestBody);
            string id = postResponse.Body["institutionDetails"].GetProperty("id").ToString();

            //Update(put) item on server
            (HttpResponseMessage Message, IDictionary<string, dynamic> Body) putResponse =
                await Request<IDictionary<string, dynamic>>(HttpMethod.Put,
                                                            $"/Institutions/{id}",
                                                            putRequestBody);

            //Get item from server
            (HttpResponseMessage Message, List<IDictionary<string, dynamic>> Body) getResponse =
                await Request<List<IDictionary<string, dynamic>>>(HttpMethod.Get, "/Institutions");
            var getResponseBody = getResponse.Body.Find(x =>
                x["id"].ToString() == id);

            //Then
            Assert.Equal("OK", putResponse.Message.StatusCode.ToString());

            Assert.Equal(putRequestBody["name"].ToString(),
                         getResponseBody["name"].ToString());

            //Clean
            await Request<None>(HttpMethod.Delete, $"/Institutions/{id}");
        }

        [Fact]
        public async Task Delete()
        {
            //Given
            Dictionary<string, dynamic> postRequestBody = new();
            postRequestBody.Add("name", "AAU");

            //When
            //Post item to the server
            (HttpResponseMessage Message, IDictionary<string, dynamic> Body) postResponse =
                await Request<IDictionary<string, dynamic>>(HttpMethod.Post, "/Institutions", postRequestBody);
            string id = postResponse.Body["institutionDetails"].GetProperty("id").ToString();

            //Delete item from server
            (HttpResponseMessage Message, IDictionary<string, dynamic> Body) deleteResponse =
                await Request<IDictionary<string, dynamic>>(HttpMethod.Delete, $"/Institutions/{id}");

            //Get item from server
            (HttpResponseMessage Message, List<IDictionary<string, dynamic>> Body) getResponse =
                await Request<List<IDictionary<string, dynamic>>>(HttpMethod.Get, "/Institutions");
            var getResponseBody = getResponse.Body.Find(x =>
                x["id"].ToString() == id);

            //Then
            Assert.Equal("OK", deleteResponse.Message.StatusCode.ToString());
            Assert.Null(getResponseBody);
        }

        [Fact]
        public async Task DeletingInstitutionCascadesToAggregates()
        {
            //Given
            Dictionary<string, dynamic> inst = new();
            inst.Add("Name", "AAU");

            (HttpResponseMessage Message, IDictionary<string, dynamic> Body) instResponse =
                await Request<IDictionary<string, dynamic>>(HttpMethod.Post, "/Institutions", inst);
            string instId = instResponse.Body["institutionDetails"]
                                        .GetProperty("id")
                                        .ToString();

            Dictionary<string, dynamic> user = new();
            user.Add("firstName", "Casper");
            user.Add("lastName", "Caspersen");
            user.Add("email", RandomString(10));
            user.Add("phoneNumber", "20234011");
            user.Add("institution", instId);
            user.Add("role", 1);
            user.Add("password", "casperErSej");

            (HttpResponseMessage Message, IDictionary<string, dynamic> Body) userResponse =
                await Request<IDictionary<string, dynamic>>(HttpMethod.Post, "/Users", user);
            string userId = userResponse.Body["id"].ToString();

            Dictionary<string, dynamic> poster = new();
            poster.Add("name", "Placeholder Poster");
            poster.Add("imageUrl", "https://via.placeholder.com/1080x1920");
            poster.Add("institution", instId);

            (HttpResponseMessage Message, IDictionary<string, dynamic> Body) posterResponse =
                await Request<IDictionary<string, dynamic>>(HttpMethod.Post, "/Posters", poster);
            string posterId = posterResponse.Body["id"].ToString();

            Dictionary<string, dynamic> schedule = new();
            schedule.Add("posterId", posterId);
            schedule.Add("name", "Placeholder Poster Schedule");
            schedule.Add("startDate", DateTime.Now);
            schedule.Add("endDate", DateTime.Now.AddDays(1));
            schedule.Add("zone", 1);

            //When
            await Request<None>(HttpMethod.Delete, $"/Institutions/{instId}");

            (HttpResponseMessage Message, List<IDictionary<string, dynamic>> Body) users =
                await Request<List<IDictionary<string, dynamic>>>(HttpMethod.Get, "/Users");
            var deletedUser =  users.Body.Find(x => x["id"].ToString() == userId);

            (HttpResponseMessage Message, List<IDictionary<string, dynamic>> Body) posters =
                await Request<List<IDictionary<string, dynamic>>>(HttpMethod.Get, "/Posters");
            var deletedPoster =  users.Body.Find(x => x["id"].ToString() == userId);

            (HttpResponseMessage Message, List<IDictionary<string, dynamic>> Body) schedules =
                await Request<List<IDictionary<string, dynamic>>>(HttpMethod.Get, "/Users");
            var deletedSchedule =  users.Body.Find(x => x["id"].ToString() == userId);

            //Then
            Assert.Null(deletedUser);
            Assert.Null(deletedPoster);
            Assert.Null(deletedSchedule);
        }
    }
}