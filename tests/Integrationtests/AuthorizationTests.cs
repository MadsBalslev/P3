using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace tests.Integrationtests
{
    public class AuthorizationTests : IntegrationTests
    {
        [Theory]
        [InlineData("GET", "/Institutions")]
        [InlineData("POST", "/Institutions")]
        [InlineData("PUT", "/Institutions/1")]
        [InlineData("DELETE", "/Institutions/1")]
        [InlineData("GET", "/Posters")]
        [InlineData("POST", "/Posters")]
        [InlineData("PUT", "/Posters/1")]
        [InlineData("DELETE", "/Posters/1")]
        [InlineData("GET", "/Schedule")]
        [InlineData("POST", "/Schedule")]
        [InlineData("PUT", "/Schedule/1")]
        [InlineData("DELETE", "/Schedule/1")]
        [InlineData("GET", "/Users")]
        [InlineData("POST", "/Users")]
        [InlineData("PUT", "/Users/1")]
        [InlineData("DELETE", "/Users/1")]
        [InlineData("GET", "/Zones")]
        [InlineData("POST", "/Zones")]
        [InlineData("PUT", "/Zones/1")]
        [InlineData("DELETE", "/Zones/1")]
        public async Task EndpointsReturnNotAuthorizedWithNoAuthorizationHeader(string method,
                                                                                string url)
        {
            //Given
            HttpRequestMessage request = new HttpRequestMessage(new HttpMethod(method), url);

            //When
            HttpResponseMessage response = await _client.SendAsync(request);

            //Then
            Assert.Equal("Unauthorized", response.StatusCode.ToString());
        }

        [Theory]
        [InlineData("/MetaData/1")]
        [InlineData("/Zones/Active/1")]
        public async Task Get_EndpointsReturnOkNoAuthorizationHeader(string url)
        {
            //Given
            //When
            var response = await _client.GetAsync(url);

            //Then
            Assert.Equal("OK", response.StatusCode.ToString());
        }

        [Theory]
        [InlineData("/Institutions")]
        [InlineData("/Posters")]
        [InlineData("/Schedule")]
        [InlineData("/Users")]
        [InlineData("/Zones")]
        public async Task Get_EndpointsReturnOkWithValidAuthorizationHeader(string url)
        {
            //Given
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
            request.Headers.Add("Authorization", "Basic YWRtaW46JDJhJDExJGdYVFdVbWhqYmhiak9xelQ2QW5mVk9SZlBqVlhUL3c0VVFoUFhrcjNHNnZzVnM3eFEzYS9D");

            //When
            HttpResponseMessage response = await _client.SendAsync(request);

            //Then
            Assert.Equal("OK", response.StatusCode.ToString());
        }

        [Theory]
        [InlineData("GET", "/Institutions", "")]
        [InlineData("POST", "/Institutions", "123")]
        [InlineData("PUT", "/Institutions/1", "YWRtaW46JDJhJDExJGdYVFdVbWhqYmhiak9xelQ2QW12Vk9SZlBqVlhUL3c0VVFoUFhrcjNHNnZzVnM3eFEzYS9D")]
        [InlineData("DELETE", "/Institutions/1", " ")]
        [InlineData("GET", "/Posters", "admin")]
        [InlineData("POST", "/Posters", "123412341234")]
        [InlineData("PUT", "/Posters/1", "              ")]
        [InlineData("DELETE", "/Posters/1", "tissemand")]
        [InlineData("GET", "/Schedule", ":)")]
        [InlineData("POST", "/Schedule", "jeg vil gerne logge ind")]
        [InlineData("PUT", "/Schedule/1", "0xC0")]
        [InlineData("DELETE", "/Schedule/1", "0x11111000")]
        [InlineData("GET", "/Users", "riqerghnioqerghio")]
        [InlineData("POST", "/Users", "ssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssssss")]
        [InlineData("PUT", "/Users/1", "jsdfjgsdfg")]
        [InlineData("DELETE", "/Users/1", "ttttt")]
        [InlineData("GET", "/Zones", "819034850234059834098590345903409583409583049580349583495834905834")]
        [InlineData("POST", "/Zones", "سأقتلك كلبك")]
        [InlineData("PUT", "/Zones/1", "本先令")]
        [InlineData("DELETE", "/Zones/1", "бин шиллинг")]
        public async Task EndpointsReturnUnauthorizedWithinvalidAuthorizationHeader(string method,
                                                                                    string url,
                                                                                    string auth)
        {
            //Given
            HttpRequestMessage request = new HttpRequestMessage(new HttpMethod(method), url);
            request.Headers.Add("Authorization", $"Basic {auth}");

            //When
            HttpResponseMessage response = await _client.SendAsync(request);

            //Then
            Assert.Equal("Unauthorized", response.StatusCode.ToString());
        }
    }
}