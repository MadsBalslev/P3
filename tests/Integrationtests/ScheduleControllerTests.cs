using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace tests.Integrationtests
{
    // [Collection("API tests")]
    public class ScheduleControllerTests : IntegrationTests
    {
        [Fact]
        public async Task Post()
        {
            //Given
            Dictionary<string, dynamic> posterRequestBody = new();
            posterRequestBody.Add("name", "Placeholder Poster");
            posterRequestBody.Add("imageUrl", "https://via.placeholder.com/1080x1920");
            posterRequestBody.Add("institution", 1);

            //Post poster to server
            (HttpResponseMessage Message, IDictionary<string, dynamic> Body) posterResponse =
                await Request<IDictionary<string, dynamic>>(HttpMethod.Post,
                                                            "/Posters",
                                                            posterRequestBody);
            string posterId = posterResponse.Body["id"].ToString();

            Dictionary<string, dynamic> scheduleRequestBody = new();
            scheduleRequestBody.Add("posterId", posterId);
            scheduleRequestBody.Add("name", "Placeholder poster schedule");
            scheduleRequestBody.Add("startDate", DateTime.Now);
            scheduleRequestBody.Add("endDate", DateTime.Now.AddDays(+1));
            scheduleRequestBody.Add("zone", 1);

            //When
            //Post schedule attached to poster to server
            (HttpResponseMessage Message, IDictionary<string, dynamic> Body) scheduleResponse =
                await Request<IDictionary<string, dynamic>>(HttpMethod.Post,
                                                            "/Schedule",
                                                            scheduleRequestBody);
            string scheduleId = scheduleResponse.Body["id"].ToString();

            //Get schedule from server
            (HttpResponseMessage Message, List<IDictionary<string, dynamic>> Body) getResponse =
                await Request<List<IDictionary<string, dynamic>>>(HttpMethod.Get, "/Schedule");
            var getResponseBody = getResponse.Body.Find(x => x["id"].ToString() == scheduleId);

            //Then
            Assert.Equal("OK", scheduleResponse.Message.StatusCode.ToString());

            Assert.Equal(scheduleRequestBody["posterId"].ToString(),
                         getResponseBody["poster"].GetProperty("id").ToString());

            Assert.Equal(scheduleRequestBody["name"].ToString(),
                         getResponseBody["name"].ToString());

            Assert.Equal(DateTime.Parse(scheduleRequestBody["startDate"].ToString()),
                         DateTime.Parse(getResponseBody["startDate"].ToString()));

            Assert.Equal(DateTime.Parse(scheduleRequestBody["endDate"].ToString()),
                         DateTime.Parse(getResponseBody["endDate"].ToString()));

            Assert.Equal(scheduleRequestBody["zone"].ToString(),
                         getResponseBody["zone"].GetProperty("id").ToString());

            //Clean
            await Request<None>(HttpMethod.Delete, $"/Posters/{posterId}");
        }

        [Fact]
        public async Task Put()
        {
            //Given
            Dictionary<string, dynamic> posterRequestBody = new();
            posterRequestBody.Add("name", "Placeholder Poster");
            posterRequestBody.Add("imageUrl", "https://via.placeholder.com/1080x1920");
            posterRequestBody.Add("institution", 1);

            //Post poster to server
            (HttpResponseMessage Message, IDictionary<string, dynamic> Body) posterResponse =
                await Request<IDictionary<string, dynamic>>(HttpMethod.Post,
                                                            "/Posters",
                                                            posterRequestBody);
            string posterId = posterResponse.Body["id"].ToString();

            Dictionary<string, dynamic> schedulePostRequestBody = new();
            schedulePostRequestBody.Add("posterId", posterId);
            schedulePostRequestBody.Add("name", "Placeholder poster schedule");
            schedulePostRequestBody.Add("startDate", DateTime.Now);
            schedulePostRequestBody.Add("endDate", DateTime.Now.AddDays(+1));
            schedulePostRequestBody.Add("zone", 1);

            Dictionary<string, dynamic> schedulePutRequestBody = new();
            schedulePutRequestBody.Add("posterId", posterId);
            schedulePutRequestBody.Add("name", "Placeholder poster schedule!");
            schedulePutRequestBody.Add("startDate", DateTime.Now.AddDays(+1));
            schedulePutRequestBody.Add("endDate", DateTime.Now.AddDays(+2));
            schedulePutRequestBody.Add("zone", 1);

            //When
            //Post schedule attached to poster to server
            (HttpResponseMessage Message, IDictionary<string, dynamic> Body) schedulePostResponse =
                await Request<IDictionary<string, dynamic>>(HttpMethod.Post,
                                                            "/Schedule",
                                                            schedulePostRequestBody);
            string scheduleId = schedulePostResponse.Body["id"].ToString();

            //Put updated schedule to server
            (HttpResponseMessage Message, IDictionary<string, dynamic> Body) schedulePutResponse =
                await Request<IDictionary<string, dynamic>>(HttpMethod.Put,
                                                            $"/Schedule/{scheduleId}",
                                                            schedulePutRequestBody);
            //Get schedule from server
            (HttpResponseMessage Message, List<IDictionary<string, dynamic>> Body) getResponse =
                await Request<List<IDictionary<string, dynamic>>>(HttpMethod.Get, "/Schedule");
            var getResponseBody = getResponse.Body.Find(x => x["id"].ToString() == scheduleId);

            //Then
            Assert.Equal("OK", schedulePutResponse.Message.StatusCode.ToString());

            Assert.Equal(schedulePutRequestBody["posterId"].ToString(),
                         getResponseBody["poster"].GetProperty("id").ToString());

            Assert.Equal(schedulePutRequestBody["name"].ToString(),
                         getResponseBody["name"].ToString());

            Assert.Equal(DateTime.Parse(schedulePutRequestBody["startDate"].ToString()),
                         DateTime.Parse(getResponseBody["startDate"].ToString()));

            Assert.Equal(DateTime.Parse(schedulePutRequestBody["endDate"].ToString()),
                         DateTime.Parse(getResponseBody["endDate"].ToString()));

            Assert.Equal(schedulePutRequestBody["zone"].ToString(),
                         getResponseBody["zone"].GetProperty("id").ToString());

            //Clean
            await Request<None>(HttpMethod.Delete, $"/Posters/{posterId}");
        }

        // [Fact]
        public async Task Delete()
        {
            //Given
            Dictionary<string, dynamic> posterRequestBody = new();
            posterRequestBody.Add("name", "Placeholder Poster");
            posterRequestBody.Add("imageUrl", "https://via.placeholder.com/1080x1920");
            posterRequestBody.Add("institution", 1);

            //Post poster to server
            (HttpResponseMessage Message, IDictionary<string, dynamic> Body) posterResponse =
                await Request<IDictionary<string, dynamic>>(HttpMethod.Post,
                                                            "/Posters",
                                                            posterRequestBody);
            string posterId = posterResponse.Body["id"].ToString();

            Dictionary<string, dynamic> scheduleRequestBody = new();
            scheduleRequestBody.Add("posterId", posterId);
            scheduleRequestBody.Add("name", "Placeholder poster schedule");
            scheduleRequestBody.Add("startDate", DateTime.Now);
            scheduleRequestBody.Add("endDate", DateTime.Now.AddDays(+1));
            scheduleRequestBody.Add("zone", 1);

            //When
            //Post schedule attached to poster to server
            (HttpResponseMessage Message, IDictionary<string, dynamic> Body) schedulePostResponse =
                await Request<IDictionary<string, dynamic>>(HttpMethod.Post,
                                                            "/Schedule",
                                                            scheduleRequestBody);
            string scheduleId = schedulePostResponse.Body["id"].ToString();

            //Delete that schedule
            (HttpResponseMessage Message, IDictionary<string, dynamic> Body) scheduleDeleteResponse =
                await Request<IDictionary<String, dynamic>>(HttpMethod.Delete, $"/Schedule/{scheduleId}");

            //Get schedule from server
            (HttpResponseMessage Message, List<IDictionary<string, dynamic>> Body) getResponse =
                await Request<List<IDictionary<string, dynamic>>>(HttpMethod.Get, "/Schedule");
            var getResponseBody = getResponse.Body.Find(x => x["id"].ToString() == scheduleId);

            //Then
            Assert.Equal("OK", scheduleDeleteResponse.Message.StatusCode.ToString());
            Assert.Null(getResponseBody);

            //Clean
            await Request<None>(HttpMethod.Delete, $"/Posters/{posterId}");
        }
    }
}