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

        [Fact]
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

        [Theory]
        [InlineData(1, 0, 0, 1, 0, 0)]
        [InlineData(0, 1, 0, 0, 1, 0)]
        [InlineData(0, 0, 1, 0, 0, 1)]
        [InlineData(7, 4, 3, 2, 8, 4)]
        public async Task ActiveSchedulesReturnSchedulesThatAreActiveAndWithinZone(int startDateMinutesOffset,
                                                                                   int startDateHoursOffset,
                                                                                   int startDateDaysOffset,
                                                                                   int endDateMinutesOffset,
                                                                                   int endDateHoursOffset,
                                                                                   int endDateDaysOffset)
        {
            //Given
            Dictionary<string, dynamic> poster = new();
            poster.Add("Name", "Active Poster");
            poster.Add("imageUrl", "https://via.placeholder.com/1080x1920");
            poster.Add("institution", 1);


            (HttpResponseMessage Message, IDictionary<string, dynamic> Body) posterResponse =
                await Request<IDictionary<string, dynamic>>(HttpMethod.Post, "/Posters", poster);

            Dictionary<string, dynamic> schedule = new();
            schedule.Add("posterId", posterResponse.Body["id"]);
            schedule.Add("name", "Active Poster Schedule");
            schedule.Add("startDate", DateTime.Now
                                              .AddMinutes(-startDateMinutesOffset)
                                              .AddHours(-startDateHoursOffset)
                                              .AddDays(-startDateDaysOffset));
            schedule.Add("endDate", DateTime.Now
                                            .AddMinutes(endDateMinutesOffset)
                                            .AddHours(endDateHoursOffset)
                                            .AddDays(endDateDaysOffset));
            schedule.Add("zone", 1);

            (HttpResponseMessage Message, IDictionary<string, dynamic> Body) scheduleResponse =
                await Request<IDictionary<string, dynamic>>(HttpMethod.Post, "/Schedule", schedule);

            //When
            (HttpResponseMessage Message, List<IDictionary<string, dynamic>> Body) posters =
                await Request<List<IDictionary<string, dynamic>>>(HttpMethod.Get, "/Zones/Active/1");
            var foundActivePoster = posters.Body.Find(x =>
                x["id"].ToString() == posterResponse.Body["id"].ToString());

            //Then
            Assert.Equal(poster["imageUrl"].ToString(), foundActivePoster["image"].ToString());

            //clean
            await Request<None>(HttpMethod.Delete, $"/Posters/{posterResponse.Body["id"]}");
        }

        [Fact]
        public async Task ActiveShedulesDoesNotReturnShedulesNotWitninDateLimit()
        {
            //Given
            Dictionary<string, dynamic> poster = new();
            poster.Add("Name", "Active Poster");
            poster.Add("imageUrl", "https://via.placeholder.com/1080x1920");
            poster.Add("institution", 1);


            (HttpResponseMessage Message, IDictionary<string, dynamic> Body) posterResponse =
                await Request<IDictionary<string, dynamic>>(HttpMethod.Post, "/Posters", poster);

            Dictionary<string, dynamic> schedule = new();
            schedule.Add("posterId", posterResponse.Body["id"]);
            schedule.Add("name", "Active Poster Schedule");
            schedule.Add("startDate", DateTime.Now.AddDays(1));
            schedule.Add("endDate", DateTime.Now.AddDays(-1));
            schedule.Add("zone", 1);

            (HttpResponseMessage Message, IDictionary<string, dynamic> Body) scheduleResponse =
                await Request<IDictionary<string, dynamic>>(HttpMethod.Post, "/Schedule", schedule);

            //When
            (HttpResponseMessage Message, List<IDictionary<string, dynamic>> Body) posters =
                await Request<List<IDictionary<string, dynamic>>>(HttpMethod.Get, "/Zones/Active/1");
            var shouldNotBeFound = posters.Body.Find(x =>
                x["id"].ToString() == posterResponse.Body["id"].ToString());

            //Then
            Assert.Null(shouldNotBeFound);

            //clean
            await Request<None>(HttpMethod.Delete, $"/Posters/{posterResponse.Body["id"]}");
        }

        [Fact]
        public async Task ActiveShedulesDoesNotReturnShedulesNotWitninZone()
        {
            //Given
            Dictionary<string, dynamic> poster = new();
            poster.Add("Name", "Active Poster");
            poster.Add("imageUrl", "https://via.placeholder.com/1080x1920");
            poster.Add("institution", 1);


            (HttpResponseMessage Message, IDictionary<string, dynamic> Body) posterResponse =
                await Request<IDictionary<string, dynamic>>(HttpMethod.Post, "/Posters", poster);

            Dictionary<string, dynamic> zone = new();
            zone.Add("Name", "Active Zone");

            (HttpResponseMessage Message, IDictionary<string, dynamic> Body) zoneResponse =
                await Request<IDictionary<string, dynamic>>(HttpMethod.Post, "/Zones", zone);
            string zoneId = zoneResponse.Body["zoneDetaile"].GetProperty("id").ToString();

            Dictionary<string, dynamic> schedule = new();
            schedule.Add("posterId", posterResponse.Body["id"]);
            schedule.Add("name", "Active Poster Schedule");
            schedule.Add("startDate", DateTime.Now.AddDays(1));
            schedule.Add("endDate", DateTime.Now.AddDays(-1));
            schedule.Add("zone", zoneId);

            (HttpResponseMessage Message, IDictionary<string, dynamic> Body) scheduleResponse =
                await Request<IDictionary<string, dynamic>>(HttpMethod.Post, "/Schedule", schedule);

            //When
            (HttpResponseMessage Message, List<IDictionary<string, dynamic>> Body) posters =
                await Request<List<IDictionary<string, dynamic>>>(HttpMethod.Get, $"/Zones/Active/{zoneId}");
            var shouldNotBeFound = posters.Body.Find(x =>
                x["id"].ToString() == posterResponse.Body["id"].ToString());

            //Then
            Assert.Null(shouldNotBeFound);

            //clean
            await Request<None>(HttpMethod.Delete, $"/Posters/{posterResponse.Body["id"]}");
            await Request<None>(HttpMethod.Delete, $"/Zones/{zoneId}");
        }
    }
}