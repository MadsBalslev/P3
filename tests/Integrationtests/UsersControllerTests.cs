using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace tests.Integrationtests
{
    // // [Collection("API tests")]
    public class UsersControllerTests : IntegrationTests
    {
        // https://stackoverflow.com/questions/1344221/how-can-i-generate-random-alphanumeric-strings
        private static Random random = new Random();

        // https://stackoverflow.com/questions/1344221/how-can-i-generate-random-alphanumeric-strings
        private static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        [Fact]
        public async Task Post()
        {
            //Given
            Dictionary<string, dynamic> requestBody = new();
            requestBody.Add("firstName", "Casper");
            requestBody.Add("lastName", "Caspersen");
            requestBody.Add("email", RandomString(10));
            requestBody.Add("phoneNumber", "28292522");
            requestBody.Add("institution", 1);
            requestBody.Add("role", 1);
            requestBody.Add("password", "casperErSej123");

            //When
            (HttpResponseMessage Message, IDictionary<String, dynamic> Body) postResponse =
                await Request<IDictionary<String, dynamic>>(HttpMethod.Post, "/Users", requestBody);

            (HttpResponseMessage Message, List<IDictionary<String, dynamic>> Body) getResponse =
                await Request<List<IDictionary<string, dynamic>>>(HttpMethod.Get, "/Users");
            var getResponseBody = getResponse.Body.Find(x =>
                x["id"].ToString() == postResponse.Body["id"].ToString());

            //Then
            Assert.Equal("OK", postResponse.Message.StatusCode.ToString());

            Assert.Equal(requestBody["firstName"].ToString(),
                         getResponseBody["firstName"].ToString());

            Assert.Equal(requestBody["lastName"].ToString(),
                         getResponseBody["lastName"].ToString());

            Assert.Equal(requestBody["email"].ToString(),
                         getResponseBody["email"].ToString());

            Assert.Equal(requestBody["phoneNumber"].ToString(),
                         getResponseBody["phoneNumber"].ToString());

            Assert.Equal(requestBody["institution"].ToString(),
                         getResponseBody["institution"].GetProperty("id").ToString());

            Assert.Equal(requestBody["role"].ToString(),
                         getResponseBody["role"].ToString());

            //Clean
            await Request<None>(HttpMethod.Delete, $"/Users/{postResponse.Body["id"]}");
        }

        [Fact]
        public async Task Put()
        {
            //Given
            Dictionary<string, dynamic> postRequestBody = new();
            postRequestBody.Add("firstName", "Casper");
            postRequestBody.Add("lastName", "Caspersen");
            postRequestBody.Add("email", RandomString(10));
            postRequestBody.Add("phoneNumber", "28292522");
            postRequestBody.Add("institution", 1);
            postRequestBody.Add("role", 1);
            postRequestBody.Add("password", "casperErSej123");

            Dictionary<string, dynamic> putRequestBody = new();
            putRequestBody.Add("firstName", "Mads");
            putRequestBody.Add("lastName", "Madsen");
            putRequestBody.Add("email", RandomString(10));
            putRequestBody.Add("phoneNumber", "33292522");
            putRequestBody.Add("role", 2);
            putRequestBody.Add("password", "MadsErSej123");

            //When
            (HttpResponseMessage Message, IDictionary<String, dynamic> Body) postResponse =
                await Request<IDictionary<String, dynamic>>(HttpMethod.Post, "/Users", postRequestBody);
            string id = postResponse.Body["id"].ToString();

            (HttpResponseMessage Message, IDictionary<String, dynamic> Body) putResponse =
                await Request<IDictionary<String, dynamic>>(HttpMethod.Put,
                                                            $"/Users/{id}",
                                                            putRequestBody);

            (HttpResponseMessage Message, List<IDictionary<String, dynamic>> Body) getResponse =
                await Request<List<IDictionary<string, dynamic>>>(HttpMethod.Get, "/Users");
            var getResponseBody = getResponse.Body.Find(x =>
                x["id"].ToString() == postResponse.Body["id"].ToString());

            // holy fucking shit never have i ever....

            //Then
            Assert.Equal("OK", postResponse.Message.StatusCode.ToString());

            Assert.Equal(putRequestBody["firstName"].ToString(),
                         getResponseBody["firstName"].ToString());

            Assert.Equal(putRequestBody["lastName"].ToString(),
                         getResponseBody["lastName"].ToString());

            Assert.Equal(putRequestBody["email"].ToString(),
                         getResponseBody["email"].ToString());

            Assert.Equal(putRequestBody["phoneNumber"].ToString(),
                         getResponseBody["phoneNumber"].ToString());

            Assert.Equal(putRequestBody["role"].ToString(),
                         getResponseBody["role"].ToString());

            //Clean
            await Request<None>(HttpMethod.Delete, $"/Users/{postResponse.Body["id"]}");
        }

        [Fact]
        public async Task Delete()
        {
            //Given
            Dictionary<string, dynamic> postRequestBody = new();
            postRequestBody.Add("firstName", "Casper");
            postRequestBody.Add("lastName", "Caspersen");
            postRequestBody.Add("email", RandomString(10));
            postRequestBody.Add("phoneNumber", "28292522");
            postRequestBody.Add("institution", 1);
            postRequestBody.Add("role", 1);
            postRequestBody.Add("password", "casperErSej123");

            Dictionary<string, dynamic> putRequestBody = new();
            putRequestBody.Add("firstName", "Mads");
            putRequestBody.Add("lastName", "Madsen");
            putRequestBody.Add("email", RandomString(10));
            putRequestBody.Add("phoneNumber", "33292522");
            putRequestBody.Add("role", 2);
            putRequestBody.Add("password", "MadsErSej123");

            //When
            (HttpResponseMessage Message, IDictionary<String, dynamic> Body) postResponse =
                await Request<IDictionary<String, dynamic>>(HttpMethod.Post, "/Users", postRequestBody);
            string id = postResponse.Body["id"].ToString();

            (HttpResponseMessage Message, IDictionary<String, dynamic> Body) putResponse =
                await Request<IDictionary<String, dynamic>>(HttpMethod.Put,
                                                            $"/Users/{id}",
                                                            putRequestBody);

            (HttpResponseMessage Message, List<IDictionary<String, dynamic>> Body) getResponse =
                await Request<List<IDictionary<string, dynamic>>>(HttpMethod.Get, "/Users");
            var getResponseBody = getResponse.Body.Find(x =>
                x["id"].ToString() == postResponse.Body["id"].ToString());

            // holy fucking shit never have i ever....

            //Then
            Assert.Equal("OK", postResponse.Message.StatusCode.ToString());

            Assert.Equal(putRequestBody["firstName"].ToString(),
                         getResponseBody["firstName"].ToString());

            Assert.Equal(putRequestBody["lastName"].ToString(),
                         getResponseBody["lastName"].ToString());

            Assert.Equal(putRequestBody["email"].ToString(),
                         getResponseBody["email"].ToString());

            Assert.Equal(putRequestBody["phoneNumber"].ToString(),
                         getResponseBody["phoneNumber"].ToString());

            Assert.Equal(putRequestBody["role"].ToString(),
                         getResponseBody["role"].ToString());

            //Clean
            await Request<None>(HttpMethod.Delete, $"/Users/{postResponse.Body["id"]}");
        }
    }
}