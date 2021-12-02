using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace tests.Integrationtests
{
    [TestCaseOrderer("tests.PriorityOrderer", "tests")]
    public class InstitutionControllerTests : IntegrationTests
    {
        [Fact, TestPriority(1)]
        public async Task Post()
        {
            // Arrange
            Institution institution = new() { name = "test" };

            // Act
            (HttpResponseMessage Message, Institution Body) response =
                await request<Institution, Institution>(HttpMethod.Post, "/Institutions", institution);

            // Assert
            Assert.Equal("OK", response.Message.StatusCode.ToString());
            Assert.Equal(institution.name, response.Body.name);
        }

        [Fact, TestPriority(2)]
        public async Task Put()
        {
            // Arrange
            Institution institution = new() { name = "changed" };

            // Act
            (HttpResponseMessage Message, Institution Body) response =
                await request<Institution, Institution>(HttpMethod.Put, "/Institutions/2", institution);

            // Assert
            Assert.Equal("OK", response.Message.StatusCode.ToString());
            Assert.Equal(institution.name, response.Body.name);
        }

        [Fact, TestPriority(3)]
        public async Task Get()
        {
            // Arrange
            // Act
            (HttpResponseMessage Message, List<Institution> Body) response =
                await request<None, List<Institution>>(HttpMethod.Get, "/institutions");

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
            Assert.Equal("changed", deleteResponse.Body.name);
            Assert.Equal("NotFound", getResponse.Message.StatusCode.ToString());
        }
    }
}