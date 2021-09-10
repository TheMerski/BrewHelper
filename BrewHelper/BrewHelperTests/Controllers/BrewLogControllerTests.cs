using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BrewHelper.DTO;
using BrewHelper.Entities;
using FluentAssertions;
using Xunit;

namespace BrewHelperTests.Controllers
{
    public class BrewLogControllerTests : IntegrationTest
    {
        private readonly string endpoint;
        
        public BrewLogControllerTests(BrewHelperWebApplicationFactory factory) : base(factory)
        {
            endpoint = "/api/BrewLogs";
        }
        
        [Fact]
        public async Task Unauthorized_Get_Should_Be_Unauthorized()
        {
            var response = await _unauthorizedClient.GetAsync(endpoint);
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }

        [Fact]
        public async Task Get_Admin_Should_Retrieve_Logs()
        {
            var response = await _adminClient.GetAsync(endpoint);
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var json = await response.Content.ReadAsStringAsync();
            var logs = JsonSerializer.Deserialize<GenericListResponseDTO<BrewLog>>(json, _serializeOptions);
            
            logs.Should().NotBeNull();
            logs?.Items.Should().NotBeEmpty();
            logs?.Items[0].MashingLog.Should().BeNull();
            logs?.Items[0].BoilingLog.Should().BeNull();
            logs?.Items[0].YeastingLog.Should().BeNull();
        }
        
        [Fact]
        public async Task Get_Should_Retrieve_Logs()
        {
            var response = await _userClient.GetAsync(endpoint);
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var logs = JsonSerializer.Deserialize<GenericListResponseDTO<BrewLog>>(
                await response.Content.ReadAsStringAsync(), _serializeOptions);
            logs.Should().NotBeNull();
            logs?.Items.Should().NotBeEmpty();
            
            // Related values should be null on multiple
            logs?.Items[0].MashingLog.Should().BeNull();
            logs?.Items[0].BoilingLog.Should().BeNull();
            logs?.Items[0].YeastingLog.Should().BeNull();
        }

        [Fact]
        public async Task Get_Should_Retrieve_Limit_Logs()
        {
            var response = await _userClient.GetAsync($"{endpoint}?limit=1");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            
            var logs = JsonSerializer.Deserialize<GenericListResponseDTO<BrewLog>>(
                await response.Content.ReadAsStringAsync(), _serializeOptions);
            logs.Items.Count.Should().Be(1);
            logs.TotalItems.Should().BeGreaterThan(1);
            logs.TotalPages.Should().BeGreaterThan(1);
        }
        
        [Fact]
        public async Task Get_Should_Retrieve_Id_Logs()
        {
            var response = await _userClient.GetAsync($"{endpoint}?Id=1");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            
            var logs = JsonSerializer.Deserialize<GenericListResponseDTO<BrewLog>>(
                await response.Content.ReadAsStringAsync(), _serializeOptions);
            logs.Items.Should().NotBeEmpty();
            logs.Items.Count.Should().Be(1);
            logs.TotalItems.Should().Be(1);
            logs.Items.First().Id.Should().Be(1);
        }
        
        [Fact]
        public async Task Get_Should_Retrieve_Ids_Logs()
        {
            var response = await _userClient.GetAsync($"{endpoint}?Id=1&Id=2");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            
            var logs = JsonSerializer.Deserialize<GenericListResponseDTO<BrewLog>>(
                await response.Content.ReadAsStringAsync(), _serializeOptions);
            logs.Items.Should().NotBeEmpty();
            logs.Items.Count.Should().Be(2);
            logs.TotalItems.Should().Be(2);
        }
        
        [Fact]
        public async Task Get_Should_Retrieve_BadRequest_Logs()
        {
            var response = await _userClient.GetAsync($"{endpoint}?Id=blabla");
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Get_Should_Retrieve_Pages_Logs()
        {
            var response1 = await _userClient.GetAsync($"{endpoint}?limit=1&Page=1");
            response1.StatusCode.Should().Be(HttpStatusCode.OK);

            var LogsPage1 = JsonSerializer.Deserialize<GenericListResponseDTO<BrewLog>>(await response1.Content.ReadAsStringAsync(), _serializeOptions);
            LogsPage1.Items.Count.Should().Be(1);
            LogsPage1.CurrentPage.Should().Be(1);
            BrewLog l1 = LogsPage1.Items.First();

            var response2 = await _userClient.GetAsync($"{endpoint}?limit=1&Page=2");
            response2.StatusCode.Should().Be(HttpStatusCode.OK);

            var LogsPage2 = JsonSerializer.Deserialize<GenericListResponseDTO<BrewLog>>(await response2.Content.ReadAsStringAsync(), _serializeOptions);
            LogsPage2.Items.Count.Should().Be(1);
            LogsPage2.CurrentPage.Should().Be(2);
            BrewLog l2 = LogsPage2.Items.First();

            Assert.NotEqual<BrewLog>(l1, l2);
        }
        
        [Fact]
        public async Task Get_Should_Retrieve_BadRequest_Pages_Logs()
        {
            var response1 = await _userClient.GetAsync($"{endpoint}?Page=dsa");
            response1.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Get_Should_Retrieve_BadRequest_Limit_Logs()
        {
            var response1 = await _userClient.GetAsync($"{endpoint}?limit=dsa");
            response1.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Get_Should_Retrieve_BrewLog()
        {
            var response = await _userClient.GetAsync($"{endpoint}/1");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var log = JsonSerializer.Deserialize<BrewLog>(await response.Content.ReadAsStringAsync(), _serializeOptions);
            log.Should().BeOfType<BrewLog>();
            
            // Related values should not be null on single
            log.Recipe.Should().BeNull();
            log.MashingLog.Should().NotBeNull();
            log.BoilingLog.Should().NotBeNull();
            log.YeastingLog.Should().NotBeNull();
            
            // Related value measurements should not be null
            log.MashingLog.PhMeasurements.Should().NotBeNull();
            log.MashingLog.SgMeasurements.Should().NotBeNull();
            log.MashingLog.TemperatureMeasurements.Should().NotBeNull();
            
            log.BoilingLog.PhMeasurements.Should().NotBeNull();
            log.BoilingLog.SgMeasurements.Should().NotBeNull();
            log.BoilingLog.TemperatureMeasurements.Should().NotBeNull();
            
            log.YeastingLog.PhMeasurements.Should().NotBeNull();
            log.YeastingLog.SgMeasurements.Should().NotBeNull();
            log.YeastingLog.TemperatureMeasurements.Should().NotBeNull();
        }

        [Fact]
        public async Task Get_Should_Retrieve_NotFound()
        {
            var response = await _userClient.GetAsync($"{endpoint}/99999999999");
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
        
        
        [Fact]
        public async Task Get_Should_Retrieve_BadRequest()
        {
            var response = await _userClient.GetAsync($"{endpoint}/Test");
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Put_Should_Update_Log()
        {
            var logResponse = await _userClient.GetAsync($"{endpoint}/3");
            BrewLog log = JsonSerializer.Deserialize<BrewLog>(await logResponse.Content.ReadAsStringAsync(), _serializeOptions);

            string newNotes = "This is the new note";
            int sg = 1052;

            log.Notes = newNotes;
            log.EndSG = sg;

            var json = JsonSerializer.Serialize(log);
            var stringContent = new StringContent(json, Encoding.UTF8, MediaTypeNames.Application.Json);

            var response = await _userClient.PutAsync($"{endpoint}/3", stringContent);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            BrewLog returnedLog = JsonSerializer.Deserialize<BrewLog>(await response.Content.ReadAsStringAsync(), _serializeOptions);
            returnedLog.Should().BeOfType<BrewLog>();
            returnedLog.Notes.Should().Be(newNotes);
            returnedLog.EndSG.Should().Be(sg);
        }
        
        [Fact]
        public async Task Put_Should_Not_Update_Step_Log()
        {
            var logResponse = await _userClient.GetAsync($"{endpoint}/1");
            BrewLog log = JsonSerializer.Deserialize<BrewLog>(await logResponse.Content.ReadAsStringAsync(), _serializeOptions);

            string newNotes = "This is the new note";
            DateTime now = DateTime.UtcNow;

            log.MashingLog.Notes = newNotes;
            log.MashingLog.Start = now;
            log.BoilingLog.Notes = newNotes;
            log.BoilingLog.Start = now;
            log.YeastingLog.Notes = newNotes;
            log.YeastingLog.Start = now;

            var json = JsonSerializer.Serialize(log, _serializeOptions);
            var stringContent = new StringContent(json, Encoding.UTF8, MediaTypeNames.Application.Json);

            var response = await _userClient.PutAsync($"{endpoint}/1", stringContent);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            BrewLog returnedLog = JsonSerializer.Deserialize<BrewLog>(await response.Content.ReadAsStringAsync(), _serializeOptions);
            returnedLog.Should().BeOfType<BrewLog>();
            returnedLog.Should().NotBeNull();
            returnedLog.MashingLog.Notes.Should().NotBe(newNotes);
            returnedLog.MashingLog.Start.Should().NotBe(now);
            returnedLog.BoilingLog.Notes.Should().NotBe(newNotes);
            returnedLog.BoilingLog.Start.Should().NotBe(now);
            returnedLog.YeastingLog.Notes.Should().NotBe(newNotes);
            returnedLog.YeastingLog.Start.Should().NotBe(now);
        }
        
        [Fact]
        public async Task Put_Should_Not_Add_Step_Log()
        {
            var logResponse = await _userClient.GetAsync($"{endpoint}/4");
            BrewLog log = JsonSerializer.Deserialize<BrewLog>(await logResponse.Content.ReadAsStringAsync(), _serializeOptions);
            
            log.MashingLog = new StepLog();
            log.BoilingLog = new StepLog();
            log.YeastingLog = new StepLog();

            var json = JsonSerializer.Serialize(log, _serializeOptions);
            var stringContent = new StringContent(json, Encoding.UTF8, MediaTypeNames.Application.Json);

            var response = await _userClient.PutAsync($"{endpoint}/4", stringContent);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            BrewLog returnedLog = JsonSerializer.Deserialize<BrewLog>(await response.Content.ReadAsStringAsync(), _serializeOptions);
            returnedLog.Should().BeOfType<BrewLog>();
            returnedLog.Should().NotBeNull();
            returnedLog.MashingLog.Should().BeNull();
            returnedLog.BoilingLog.Should().BeNull();
            returnedLog.YeastingLog.Should().BeNull();
        }
        
        // [Fact]
        // public async Task Put_Should_Update_Measurements_Log()
        // {
        //     var logResponse = await _userClient.GetAsync($"{endpoint}/3");
        //     BrewLog log = JsonSerializer.Deserialize<BrewLog>(await logResponse.Content.ReadAsStringAsync());
        //
        //     Measurement measurement = new Measurement
        //     {
        //         Notes = "test",
        //         Time = new DateTime(),
        //         Value = 2.5
        //     };
        //
        //     log.MashingLog.PhMeasurements.Add(measurement);
        //     log.MashingLog.SgMeasurements.Add(measurement);
        //     log.MashingLog.TemperatureMeasurements.Add(measurement);
        //     log.BoilingLog.PhMeasurements.Add(measurement);
        //     log.BoilingLog.SgMeasurements.Add(measurement);
        //     log.BoilingLog.TemperatureMeasurements.Add(measurement);
        //     log.YeastingLog.PhMeasurements.Add(measurement);
        //     log.YeastingLog.SgMeasurements.Add(measurement);
        //     log.YeastingLog.TemperatureMeasurements.Add(measurement);
        //
        //     var json = JsonSerializer.Serialize(log);
        //     var stringContent = new StringContent(json, Encoding.UTF8, MediaTypeNames.Application.Json);
        //
        //     var response = await _userClient.PutAsync($"{endpoint}/3", stringContent);
        //     response.StatusCode.Should().Be(HttpStatusCode.OK);
        //     BrewLog returnedLog = JsonSerializer.Deserialize<BrewLog>(await response.Content.ReadAsStringAsync());
        //     returnedLog.Should().BeOfType<BrewLog>();
        //     returnedLog.MashingLog.PhMeasurements.First().Notes.Should().Be(measurement.Notes);
        //     returnedLog.MashingLog.PhMeasurements.First().Time.Should().Be(measurement.Time);
        //     returnedLog.MashingLog.SgMeasurements.First().Notes.Should().Be(measurement.Notes);
        //     returnedLog.MashingLog.SgMeasurements.First().Time.Should().Be(measurement.Time);
        //     returnedLog.MashingLog.TemperatureMeasurements.First().Notes.Should().Be(measurement.Notes);
        //     returnedLog.MashingLog.TemperatureMeasurements.First().Time.Should().Be(measurement.Time);
        //     
        //     returnedLog.BoilingLog.PhMeasurements.First().Notes.Should().Be(measurement.Notes);
        //     returnedLog.BoilingLog.PhMeasurements.First().Time.Should().Be(measurement.Time);
        //     returnedLog.BoilingLog.SgMeasurements.First().Notes.Should().Be(measurement.Notes);
        //     returnedLog.BoilingLog.SgMeasurements.First().Time.Should().Be(measurement.Time);
        //     returnedLog.BoilingLog.TemperatureMeasurements.First().Notes.Should().Be(measurement.Notes);
        //     returnedLog.BoilingLog.TemperatureMeasurements.First().Time.Should().Be(measurement.Time);
        //     
        //     returnedLog.YeastingLog.PhMeasurements.First().Notes.Should().Be(measurement.Notes);
        //     returnedLog.YeastingLog.PhMeasurements.First().Time.Should().Be(measurement.Time);
        //     returnedLog.YeastingLog.SgMeasurements.First().Notes.Should().Be(measurement.Notes);
        //     returnedLog.YeastingLog.SgMeasurements.First().Time.Should().Be(measurement.Time);
        //     returnedLog.YeastingLog.TemperatureMeasurements.First().Notes.Should().Be(measurement.Notes);
        //     returnedLog.YeastingLog.TemperatureMeasurements.First().Time.Should().Be(measurement.Time);
        // }

        [Fact]
        public async Task Put_Should_Return_BadRequest()
        {
            var logResponse = await _userClient.GetAsync($"{endpoint}/3");
            BrewLog log = JsonSerializer.Deserialize<BrewLog>(await logResponse.Content.ReadAsStringAsync(), _serializeOptions);

            string newNotes = "This is the new note";

            log.Notes = newNotes;

            var json = JsonSerializer.Serialize(log);
            var stringContent = new StringContent(json, Encoding.UTF8, MediaTypeNames.Application.Json);

            var response = await _userClient.PutAsync($"{endpoint}/1", stringContent);
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
        
        [Fact]
        public async Task Put_Should_Return_NotFound()
        {
            var logResponse = await _userClient.GetAsync($"{endpoint}/1");
            BrewLog log = JsonSerializer.Deserialize<BrewLog>(await logResponse.Content.ReadAsStringAsync(), _serializeOptions);

            string newNotes = "This is the new note";

            log.Notes = newNotes;
            log.Id = long.MaxValue;

            var json = JsonSerializer.Serialize(log);
            var stringContent = new StringContent(json, Encoding.UTF8, MediaTypeNames.Application.Json);

            var response = await _userClient.PutAsync($"{endpoint}/{long.MaxValue}", stringContent);
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task Post_Should_Return_Created()
        {
            var logCreatedResponse = await _userClient.PostAsync($"{endpoint}?RecipeId=1", null);
            logCreatedResponse.StatusCode.Should().Be(HttpStatusCode.Created);
            BrewLog log = JsonSerializer.Deserialize<BrewLog>(await logCreatedResponse.Content.ReadAsStringAsync(), _serializeOptions);
            log.Should().NotBeNull();
            log?.Recipe.Id.Should().Be(1);
        }
        
        [Fact]
        public async Task Post_Should_Return_BadRequest()
        {
            var logCreatedResponse = await _userClient.PostAsync($"{endpoint}", new StringContent("blabla"));
            logCreatedResponse.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Delete_Should_Return_Delete()
        {
            var logCreatedResponse = await _userClient.PostAsync($"{endpoint}?RecipeId=1", null);
            BrewLog log = JsonSerializer.Deserialize<BrewLog>(await logCreatedResponse.Content.ReadAsStringAsync(), _serializeOptions);
            log.Should().NotBeNull();
            
            var deleteResponse = await _userClient.DeleteAsync($"{endpoint}/{log.Id}");
            deleteResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            
            var doubleDeleteResponse = await _userClient.DeleteAsync($"{endpoint}/{log.Id}");
            doubleDeleteResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
        
        [Fact]
        public async Task Post_NextStep_Should_Create_NextSteps()
        {
            var logCreatedResponse = await _userClient.PostAsync($"{endpoint}?RecipeId=1", null);
            logCreatedResponse.StatusCode.Should().Be(HttpStatusCode.Created);
            BrewLog log = JsonSerializer.Deserialize<BrewLog>(await logCreatedResponse.Content.ReadAsStringAsync(), _serializeOptions);

            log.MashingLog.Should().BeNull();
            log.BoilingLog.Should().BeNull();
            log.YeastingLog.Should().BeNull();
            
            var logNextStepResponse = await _userClient.PostAsync($"{endpoint}/{log.Id}/nextStep", null);
            logNextStepResponse.StatusCode.Should().Be(HttpStatusCode.Created);
            BrewLog mashLog = JsonSerializer.Deserialize<BrewLog>(await logNextStepResponse.Content.ReadAsStringAsync(), _serializeOptions);
            mashLog.MashingLog.Should().NotBeNull();
            mashLog.BoilingLog.Should().BeNull();
            mashLog.YeastingLog.Should().BeNull();
            
            var logNextStepResponse2 = await _userClient.PostAsync($"{endpoint}/{log.Id}/nextStep", null);
            logNextStepResponse2.StatusCode.Should().Be(HttpStatusCode.Created);
            BrewLog boilLog = JsonSerializer.Deserialize<BrewLog>(await logNextStepResponse2.Content.ReadAsStringAsync(), _serializeOptions);
            boilLog.MashingLog.Should().NotBeNull();
            boilLog.BoilingLog.Should().NotBeNull();
            boilLog.YeastingLog.Should().BeNull();
            
            var logNextStepResponse3 = await _userClient.PostAsync($"{endpoint}/{log.Id}/nextStep", null);
            logNextStepResponse3.StatusCode.Should().Be(HttpStatusCode.Created);
            BrewLog yeastLog = JsonSerializer.Deserialize<BrewLog>(await logNextStepResponse3.Content.ReadAsStringAsync(), _serializeOptions);
            yeastLog.MashingLog.Should().NotBeNull();
            yeastLog.BoilingLog.Should().NotBeNull();
            yeastLog.YeastingLog.Should().NotBeNull();
        }
        
        [Fact]
        public async Task Post_NextStep_Should_Return_NotFound()
        {
            var logNextStepResponse = await _userClient.PostAsync($"{endpoint}/{long.MaxValue}/nextStep", null);
            logNextStepResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}