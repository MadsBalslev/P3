using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace tests.Integrationtests
{
    [TestCaseOrderer("tests.PriorityOrderer", "tests")]
    public class ZoneControllerTests : IntegrationTests
    {
        [Fact, TestPriority(1)]
        public async Task Post()
        {
            // Arrange
            Zone zone = new() { name = "test" };

            // Act
            (HttpResponseMessage Message, Zone Body) response =
                await request<Zone, Zone>(HttpMethod.Post, "/Zones", zone);

            // Assert
            Assert.Equal("OK", response.Message.StatusCode.ToString());
            Assert.Equal(zone.name, response.Body.name);
        }

        [Fact, TestPriority(2)]
        public async Task Put()
        {
            // Arrange
            Zone zone = new() { name = "changed" };

            // Act
            (HttpResponseMessage Message, Zone Body) response =
                await request<Zone, Zone>(HttpMethod.Put, "/Zones/2", zone);

            // Assert
            Assert.Equal("OK", response.Message.StatusCode.ToString());
            Assert.Equal(zone.name, response.Body.name);
        }

        [Fact, TestPriority(3)]
        public async Task Get()
        {
            // Arrange
            // Act
            (HttpResponseMessage Message, List<Zone> Body) response =
                await request<None, List<Zone>>(HttpMethod.Get, "/zones");

            // Assert
            Assert.Equal("OK", response.Message.StatusCode.ToString());
            Assert.Equal("changed", response.Body[1].name);
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