using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using server;
using Xunit;

public class IntegrationTests
{
    protected readonly HttpClient _client;

    protected readonly WebApplicationFactory<server.Startup> _factory;

    public IntegrationTests()
    {
        _factory = new WebApplicationFactory<Startup>();
        _client = _factory.CreateClient();
    }
}

public class GenericControllerTests : IntegrationTests
{
    [Theory]
    [InlineData("/Institutions")]
    [InlineData("/Posters")]
    [InlineData("/Schedule")]
    [InlineData("/Users")]
    [InlineData("/Zones")]
    public async Task Get_EndpointsReturnNotAuthorizedWithNoAuthorizationHeader(string url)
    {
        // Arrange

        // Act
        var response = await _client.GetAsync(url);

        // Assert
        Assert.Equal("Unauthorized", response.StatusCode.ToString());
    }

    [Theory]
    [InlineData("/MetaData/1")]
    [InlineData("/Zones/Active/1")]
    public async Task Get_EndpointsReturnOkNoAuthorizationHeader(string url)
    {
        // Arrange

        // Act
        var response = await _client.GetAsync(url);

        // Assert
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
        // Arrange
        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
        request.Headers.Add("Authorization", $"Basic YWRtaW46JDJhJDExJGdYVFdVbWhqYmhiak9xelQ2QW5mVk9SZlBqVlhUL3c0VVFoUFhrcjNHNnZzVnM3eFEzYS9D");

        // Act
        HttpResponseMessage response = await _client.SendAsync(request);

        // Assert
        Assert.Equal("OK", response.StatusCode.ToString());
    }
}

public class PostersControllerTests : IntegrationTests
{
    [Fact]
    public async Task Post()
    {
        // Arrange
        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "/Posters");
        request.Headers.Add("Authorization", $"Basic YWRtaW46JDJhJDExJGdYVFdVbWhqYmhiak9xelQ2QW5mVk9SZlBqVlhUL3c0VVFoUFhrcjNHNnZzVnM3eFEzYS9D");

        // Act
        HttpResponseMessage response = await _client.SendAsync(request);

        using Stream responseStream = await response.Content.ReadAsStreamAsync();
        string body = await JsonSerializer.DeserializeAsync<string>(responseStream);

        // Assert
        Assert.Equal("OK", );
    }

}