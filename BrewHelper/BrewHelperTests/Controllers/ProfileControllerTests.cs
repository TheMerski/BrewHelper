using BrewHelper.Authentication;
using BrewHelper.DTO;
using FluentAssertions;
using System.Text.Json;
using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Xunit;


namespace BrewHelperTests.Controllers
{
    public class ProfileControllerTests : IntegrationTest
    {
        public ProfileControllerTests(BrewHelperWebApplicationFactory fixture) : base(fixture) { }

        [Fact]
        public async Task Unauthorized_UpdatePassword_Post_Should_Be_Unauthorized()
        {
            UpdatePasswordDTO passwordUpdate = new UpdatePasswordDTO
            {
                CurrentPassword = "BrewHelperTestPassword1!",
                NewPassword = "BrewHelperTestPassword2!",
            };

            var json = JsonSerializer.Serialize(passwordUpdate);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, MediaTypeNames.Application.Json);

            var response = await _unauthorizedClient.PostAsync("/api/Profile/updatePassword", stringContent);
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }

        [Fact]
        public async Task Invalid_DTO_UpdatePassword_Post_Should_Return_BadRequest()
        {
            UpdatePasswordDTO passwordUpdate = new UpdatePasswordDTO
            {
                CurrentPassword = "2!",
            };

            var json = JsonSerializer.Serialize(passwordUpdate);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, MediaTypeNames.Application.Json);

            var response = await _userClient.PostAsync("/api/Profile/updatePassword", stringContent);
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Invalid_Password_UpdatePassword_Post_Should_Return_BadRequest()
        {
            UpdatePasswordDTO passwordUpdate = new UpdatePasswordDTO
            {
                CurrentPassword = "ThisIsNotTheCurrentPassword1!",
                NewPassword = "new",
            };

            var json = JsonSerializer.Serialize(passwordUpdate);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, MediaTypeNames.Application.Json);

            var response = await _userClient.PostAsync("/api/Profile/updatePassword", stringContent);
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task UpdatePassword_Post_Should_Return_Ok()
        {
            UpdatePasswordDTO passwordUpdate = new UpdatePasswordDTO
            {
                CurrentPassword = "BrewHelperUser1!",
                NewPassword = "BrewHelperUser1!",
            };

            var json = JsonSerializer.Serialize(passwordUpdate);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, MediaTypeNames.Application.Json);

            var response = await _userClient.PostAsync("/api/Profile/updatePassword", stringContent);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
