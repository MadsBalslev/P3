using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace tests.Integrationtests
{
    [TestCaseOrderer("tests.PriorityOrderer", "tests")]
    public class PostersControllerTests : IntegrationTests
    {
        [Fact, TestPriority(1)]
        public async Task Post()
        {
            // Arrange
            Institution institution = new() { id = 1 };
            Poster poster = new() { name = "test", image = "test", institution = institution };

            // Act
            (HttpResponseMessage Message, Poster Body) response =
                await request<Poster, Poster>(HttpMethod.Post, "/posters", poster);

            // Assert
            Assert.Equal("OK", response.Message.StatusCode.ToString());
            Assert.Equal(poster.name, response.Body.name);
            Assert.Equal(poster.image, response.Body.image);
            Assert.Equal(poster.institution.id.ToString(), response.Body.institution.id.ToString());
        }

        [Fact, TestPriority(2)]
        public async Task Put()
        {
            // Arrange
            Institution institution = new() { id = 1 };
            Poster poster = new() { name = "changed", image = "changed", institution = institution };

            // Act
            (HttpResponseMessage Message, Poster Body) response =
                await request<Poster, Poster>(HttpMethod.Put, "/posters/1", poster);

            // Assert
            Assert.Equal("OK", response.Message.StatusCode.ToString());
            Assert.Equal(poster.name, response.Body.name);
            Assert.Equal(poster.image, response.Body.image);
            Assert.Equal(poster.institution.id.ToString(), response.Body.institution.id.ToString());
        }

        [Fact, TestPriority(3)]
        public async Task Get()
        {
            // Arrange
            // Act
            (HttpResponseMessage Message, List<Poster> Body) response =
                await request<None, List<Poster>>(HttpMethod.Get, "/posters");

            // Assert
            Assert.Equal("OK", response.Message.StatusCode.ToString());
            Assert.Equal("changed", response.Body[0].name);
            Assert.Equal("changed", response.Body[0].image);
            Assert.Equal("1", response.Body[0].institution.id.ToString());
        }

        [Fact, TestPriority(4)]
        public async Task Delete()
        {
            // Arrange
            // Act
            (HttpResponseMessage Message, Institution Body) deleteResponse =
                await request<None, Institution>(HttpMethod.Delete, "/institutions/2");

            (HttpResponseMessage Message, Institution Body) getResponse =
                await request<None, Institution>(HttpMethod.Get, "/institutions/2");

            // Assert
            Assert.Equal("OK", deleteResponse.Message.StatusCode.ToString());
            // Assert.Equal("changed", deleteResponse.Body.name);
            Assert.Equal("NotFound", getResponse.Message.StatusCode.ToString());
        }
    }
}