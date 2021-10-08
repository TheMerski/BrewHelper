using BrewHelper.Authentication;
using BrewHelper.DTO;
using FluentAssertions;
using System.Text.Json;
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
    public class UsersControllerTests : IntegrationTest
    {
        public UsersControllerTests(BrewHelperWebApplicationFactory fixture) : base(fixture) { }

        private async Task<UserDTO> GetNewUser(List<ApplicationRoles> roles = null)
        {
            RegisterDTO newUser = new RegisterDTO
            {
                Username = $"updateTestUser{Guid.NewGuid()}",
                Email = "test@brewhelper.nl",
                Password = "BrewHelperTestUser1!",
                Roles = roles
            };
            var json = JsonSerializer.Serialize(newUser);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, MediaTypeNames.Application.Json);
            var newUserResponse = await _adminClient.PostAsync($"/api/Users", stringContent);
            return JsonSerializer.Deserialize<UserDTO>(await newUserResponse.Content.ReadAsStringAsync(), _serializeOptions);
        }

        [Fact]
        public async Task GetNewUser_Should_Get_newUser() {
            UserDTO newUser = await GetNewUser(new List<ApplicationRoles> { ApplicationRoles.Admin });
            newUser.Id.Should().NotBeNull();
            newUser.Username.Should().NotBeNull();
            newUser.Roles.Count().Should().BeGreaterThan(1);
        }

        [Fact]
        public async Task Unauthorized_Get_Should_Be_Unauthorized()
        {
            var response = await _unauthorizedClient.GetAsync("/api/Users");
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }

        [Fact]
        public async Task User_Get_Should_Be_Forbidden()
        {
            var response = await _userClient.GetAsync("/api/Users");
            response.StatusCode.Should().Be(HttpStatusCode.Forbidden);
        }

        [Fact]
        public async Task Admin_Get_Should_Retrieve_Users()
        {
            var response = await _adminClient.GetAsync("/api/Users");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var Users = JsonSerializer.Deserialize<GenericListResponseDTO<UserDTO>>(await response.Content.ReadAsStringAsync(), _serializeOptions);
            Users.Items.Should().NotBeEmpty();
            Users.Items.Should().NotContainNulls(u => u.Username);
        }

        [Fact]
        public async Task Get_Should_Retrieve_Limit_Users()
        {
            var response = await _adminClient.GetAsync("/api/Users?limit=1");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var Users = JsonSerializer.Deserialize<GenericListResponseDTO<UserDTO>>(await response.Content.ReadAsStringAsync(), _serializeOptions);
            Users.Items.Count.Should().Be(1);
            Users.TotalPages.Should().BeGreaterThan(1);
            Users.TotalItems.Should().BeGreaterThan(1);
        }


        [Fact]
        public async Task Get_Should_Retrieve_Pages_Users()
        {
            var response1 = await _adminClient.GetAsync("/api/Users?limit=1&Page=1");
            response1.StatusCode.Should().Be(HttpStatusCode.OK);

            var UsersPage1 = JsonSerializer.Deserialize<GenericListResponseDTO<UserDTO>>(await response1.Content.ReadAsStringAsync(), _serializeOptions);
            UsersPage1.Items.Count.Should().Be(1);
            UsersPage1.CurrentPage.Should().Be(1);
            UserDTO ing1 = UsersPage1.Items.First();

            var response2 = await _adminClient.GetAsync("/api/Users?limit=1&Page=2");
            response2.StatusCode.Should().Be(HttpStatusCode.OK);

            var UsersPage2 = JsonSerializer.Deserialize<GenericListResponseDTO<UserDTO>>(await response2.Content.ReadAsStringAsync(), _serializeOptions);
            UsersPage2.Items.Count.Should().Be(1);
            UsersPage2.CurrentPage.Should().Be(2);
            UserDTO ing2 = UsersPage2.Items.First();

            Assert.NotEqual<UserDTO>(ing1, ing2);
        }

        [Fact]
        public async Task Get_Should_Retrieve_BadRequest_Pages_Users()
        {
            var response1 = await _adminClient.GetAsync("/api/Users?Page=dsa");
            response1.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Get_Should_Retrieve_BadRequest_Limit_Users()
        {
            var response1 = await _adminClient.GetAsync("/api/Users?limit=dsa");
            response1.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Get_Should_Retrieve_User()
        {
            var usersRes = await _adminClient.GetAsync("/api/Users?limit=1");
            var Users = JsonSerializer.Deserialize<GenericListResponseDTO<UserDTO>>(await usersRes.Content.ReadAsStringAsync(), _serializeOptions);
            string id = Users.Items.First().Id;

            var response = await _adminClient.GetAsync($"/api/Users/{id}");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var user = JsonSerializer.Deserialize<UserDTO>(await response.Content.ReadAsStringAsync(), _serializeOptions);
            user.Should().BeOfType<UserDTO>();
            user.Username.Should().NotBeNull();
        }

        [Fact]
        public async Task User_Get_Single_Should_Retrieve_Forbidden()
        {
            var usersRes = await _adminClient.GetAsync("/api/Users?limit=1");
            var Users = JsonSerializer.Deserialize<GenericListResponseDTO<UserDTO>>(await usersRes.Content.ReadAsStringAsync(), _serializeOptions);
            string id = Users.Items.First().Id;

            var response = await _userClient.GetAsync($"/api/Users/{id}");
            response.StatusCode.Should().Be(HttpStatusCode.Forbidden);
        }

        [Fact]
        public async Task Get_Should_Retrieve_NotFound()
        {
            var response = await _adminClient.GetAsync("/api/Users/99999999");
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task User_Post_Should_Return_Forbidden()
        {
            RegisterDTO newUser = new RegisterDTO
            {
                Username = $"newTestUser{Guid.NewGuid()}",
                Email = "test@brewhelper.nl",
                Password = "BrewHelperTestUser1!",
            };

            var json = JsonSerializer.Serialize(newUser);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, MediaTypeNames.Application.Json);

            var response = await _userClient.PostAsync($"/api/Users", stringContent);
            response.StatusCode.Should().Be(HttpStatusCode.Forbidden);
        }

        [Fact]
        public async Task Post_Without_Roles_Should_Create()
        {
            RegisterDTO newUser = new RegisterDTO
            {
                Username = $"newTestUser{Guid.NewGuid()}",
                Email = "test@brewhelper.nl",
                Password = "BrewHelperTestUser1!",
            };

            var json = JsonSerializer.Serialize(newUser);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, MediaTypeNames.Application.Json);

            var response = await _adminClient.PostAsync($"/api/Users", stringContent);
            response.StatusCode.Should().Be(HttpStatusCode.Created);
            UserDTO user = JsonSerializer.Deserialize<UserDTO>(await response.Content.ReadAsStringAsync(), _serializeOptions);
            user.Username.Should().Be(newUser.Username);
            user.Email.Should().Be(newUser.Email);
            user.Roles.Count.Should().Be(1);
            user.Roles.Should().Contain(ApplicationRoles.User);
        }

        [Fact]
        public async Task Post_With_All_Roles_Should_Create()
        {
            RegisterDTO newUser = new RegisterDTO
            {
                Username = $"newTestUser{Guid.NewGuid()}",
                Email = "test@brewhelper.nl",
                Password = "BrewHelperTestUser1!",
                Roles = new List<ApplicationRoles> { ApplicationRoles.Admin, ApplicationRoles.User }
            };

            var json = JsonSerializer.Serialize(newUser);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, MediaTypeNames.Application.Json);

            var response = await _adminClient.PostAsync($"/api/Users", stringContent);
            response.StatusCode.Should().Be(HttpStatusCode.Created);
            UserDTO user = JsonSerializer.Deserialize<UserDTO>(await response.Content.ReadAsStringAsync(), _serializeOptions);
            user.Username.Should().Be(newUser.Username);
            user.Email.Should().Be(newUser.Email);
            user.Roles.Count.Should().Be(2);
            user.Roles.Should().Contain(newUser.Roles);
        }

        [Fact]
        public async Task Post_With_Admin_Role_Should_Create()
        {
            RegisterDTO newUser = new RegisterDTO
            {
                Username = $"newTestUser{Guid.NewGuid()}",
                Email = "test@brewhelper.nl",
                Password = "BrewHelperTestUser1!",
                Roles = new List<ApplicationRoles> { ApplicationRoles.Admin }
            };

            var json = JsonSerializer.Serialize(newUser);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, MediaTypeNames.Application.Json);

            var response = await _adminClient.PostAsync($"/api/Users", stringContent);
            response.StatusCode.Should().Be(HttpStatusCode.Created);
            UserDTO user = JsonSerializer.Deserialize<UserDTO>(await response.Content.ReadAsStringAsync(), _serializeOptions);
            user.Username.Should().Be(newUser.Username);
            user.Email.Should().Be(newUser.Email);
            user.Roles.Count.Should().Be(2);
            user.Roles.Should().Contain(ApplicationRoles.User);
        }

        [Fact]
        public async Task Post_Should_Return_Conflict()
        {
            var usersRes = await _adminClient.GetAsync("/api/Users?limit=1");
            var Users = JsonSerializer.Deserialize<GenericListResponseDTO<UserDTO>>(await usersRes.Content.ReadAsStringAsync(), _serializeOptions);

            RegisterDTO newUser = new RegisterDTO
            {
                Username = Users.Items.First().Username,
                Email = "test@brewhelper.nl",
                Password = "BrewHelperTestUser1!",
            };

            var json = JsonSerializer.Serialize(newUser);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, MediaTypeNames.Application.Json);

            var response = await _adminClient.PostAsync($"/api/Users", stringContent);
            response.StatusCode.Should().Be(HttpStatusCode.Conflict);
        }

        [Fact]
        public async Task Post_Incorrect_Password_Should_Return_BadRequest()
        {
            RegisterDTO newUser = new RegisterDTO
            {
                Username = "Test",
                Email = "test@brewhelper.nl",
                Password = "1!",
            };

            var json = JsonSerializer.Serialize(newUser);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, MediaTypeNames.Application.Json);

            var response = await _adminClient.PostAsync($"/api/Users", stringContent);
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Post_Incorrect_Username_Should_Return_BadRequest()
        {
            RegisterDTO newUser = new RegisterDTO
            {
                Username = "test incorrect username",
                Email = "test@brewhelper.nl",
                Password = "BrewHelperTestUser1!",
            };

            var json = JsonSerializer.Serialize(newUser);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, MediaTypeNames.Application.Json);

            var response = await _adminClient.PostAsync($"/api/Users", stringContent);
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Post_Incorrect_Email_Should_Return_BadRequest()
        {
            RegisterDTO newUser = new RegisterDTO
            {
                Username = "Test",
                Email = "nah",
                Password = "BrewHelperTestUser1!",
            };

            var json = JsonSerializer.Serialize(newUser);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, MediaTypeNames.Application.Json);

            var response = await _adminClient.PostAsync($"/api/Users", stringContent);
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task User_Put_Should_Return_Forbidden()
        {
            UserDTO newUser = await GetNewUser();

            newUser.Username = "UpdatedUserName";
            newUser.Email = "testUpdated@brewhelper.nl";

            var json = JsonSerializer.Serialize(newUser);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, MediaTypeNames.Application.Json);

            var response = await _userClient.PutAsync($"/api/Users/{newUser.Id}", stringContent);
            response.StatusCode.Should().Be(HttpStatusCode.Forbidden);
        }

        [Fact]
        public async Task Put_Should_Update_User_Details()
        {
            UserDTO newUser = await GetNewUser();

            newUser.Username = "UpdatedUserName";
            newUser.Email = "testUpdated@brewhelper.nl";

            var json = JsonSerializer.Serialize(newUser);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, MediaTypeNames.Application.Json);

            var response = await _adminClient.PutAsync($"/api/Users/{newUser.Id}", stringContent);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            UserDTO updatedUser = JsonSerializer.Deserialize<UserDTO>(await response.Content.ReadAsStringAsync(), _serializeOptions);

            updatedUser.Should().BeOfType<UserDTO>();

            updatedUser.Username.Should().Be(newUser.Username);
            updatedUser.Email.Should().Be(newUser.Email);
        }

        [Fact]
        public async Task Put_Should_Remove_User_Roles()
        {
            UserDTO newUser = await GetNewUser(new List<ApplicationRoles> { ApplicationRoles.Admin });
            newUser.Roles = new List<ApplicationRoles> { ApplicationRoles.User };

            var json = JsonSerializer.Serialize(newUser);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, MediaTypeNames.Application.Json);

            var response = await _adminClient.PutAsync($"/api/Users/{newUser.Id}", stringContent);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            UserDTO updatedUser = JsonSerializer.Deserialize<UserDTO>(await response.Content.ReadAsStringAsync(), _serializeOptions);

            updatedUser.Roles.Should().ContainSingle();
        }

        [Fact]
        public async Task Put_Should_Add_User_Roles()
        {
            UserDTO newUser = await GetNewUser();
            newUser.Roles = new List<ApplicationRoles> { ApplicationRoles.User, ApplicationRoles.Admin};

            var json = JsonSerializer.Serialize(newUser);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, MediaTypeNames.Application.Json);

            var response = await _adminClient.PutAsync($"/api/Users/{newUser.Id}", stringContent);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            UserDTO updatedUser = JsonSerializer.Deserialize<UserDTO>(await response.Content.ReadAsStringAsync(), _serializeOptions);

            updatedUser.Roles.Count().Should().Be(2);
            updatedUser.Roles.Should().Contain(ApplicationRoles.Admin);
        }

        [Fact]
        public async Task Put_Should_Return_BadRequest()
        {
            UserDTO newUser = await GetNewUser();

            newUser.Username = "UpdatedUserName";
            newUser.Email = "testUpdated@brewhelper.nl";

            var json = JsonSerializer.Serialize(newUser);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, MediaTypeNames.Application.Json);

            var response = await _adminClient.PutAsync($"/api/Users/1", stringContent);
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }


        [Fact]
        public async Task Put_Should_Return_NotFound()
        {
            UserDTO newUser = await GetNewUser();

            newUser.Id = "1";
            newUser.Username = "UpdatedUserName";
            newUser.Email = "testUpdated@brewhelper.nl";

            var json = JsonSerializer.Serialize(newUser);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, MediaTypeNames.Application.Json);

            var response = await _adminClient.PutAsync($"/api/Users/1", stringContent);
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task User_Delete_Should_Return_Forbidden()
        {
            UserDTO newUser = await GetNewUser();

            var response = await _userClient.DeleteAsync($"/api/Users/{newUser.Id}");
            response.StatusCode.Should().Be(HttpStatusCode.Forbidden);
        }

        [Fact]
        public async Task Delete_Should_Return_Delete()
        {
            UserDTO newUser = await GetNewUser();

            var response = await _adminClient.DeleteAsync($"/api/Users/{newUser.Id}");
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task Delete_Should_Return_NotFound()
        {
            var response = await _adminClient.DeleteAsync("/api/Users/1");
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task Delete_Should_Return_BadRequest()
        {
            var userRes = await _adminClient.GetAsync("/api/Users");
            var Users = JsonSerializer.Deserialize<GenericListResponseDTO<UserDTO>>(await userRes.Content.ReadAsStringAsync(), _serializeOptions);
            UserDTO admin = Users.Items.Where(u => u.Username.Equals("Admin", StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault();

            var response = await _adminClient.DeleteAsync($"/api/Users/{admin.Id}");
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }
    }
}
