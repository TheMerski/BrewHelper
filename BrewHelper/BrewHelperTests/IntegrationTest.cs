using BrewHelper.Authentication;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Respawn;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using BrewHelper.Authentication.DTO;
using Xunit;

namespace BrewHelperTests
{
    [Collection("Database")]
    public abstract class IntegrationTest : IAsyncLifetime, IClassFixture<BrewHelperWebApplicationFactory>
    {
        private readonly Checkpoint _checkpoint;
        private Dictionary<string, string> _userTokens;


        protected readonly BrewHelperWebApplicationFactory _factory;
        protected readonly HttpClient _adminClient;
        protected readonly HttpClient _userClient;
        protected readonly HttpClient _unauthorizedClient;
        protected readonly IConfiguration _configuration;
        protected readonly JsonSerializerOptions _serializeOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        public IntegrationTest(BrewHelperWebApplicationFactory factory)
        {
            _userTokens = new Dictionary<string, string>();
            _factory = factory;
            _adminClient = _factory.CreateClient();
            _userClient = _factory.CreateClient();
            _unauthorizedClient = _factory.CreateClient();
            _checkpoint = new Checkpoint
            {
                TablesToIgnore = new string[] {
                 "AspNetRoleClaims",
                 "AspNetUserClaims",
                 "AspNetUserLogins",
                 "AspNetUserRoles",
                 "AspNetUserTokens",
                 "AspNetRoles",
                 "AspNetUsers"
                }
            };
        }

        //public async Task ResetDB()
        //{
        //    await _checkpoint.Reset(_factory._dbFixture.ConnString);
        //}

        public async Task<string> GetTokenAsync(string username, string password)
        {
            if (_userTokens.ContainsKey(username))
            {
                return _userTokens[username];
            }
            LoginDTO user = new LoginDTO
            {
                Username = username,
                Password = password
            };
            var json = JsonConvert.SerializeObject(user);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, MediaTypeNames.Application.Json);

            var response = await _adminClient.PostAsync($"/api/Authentication/login", stringContent);
            var result = JsonConvert.DeserializeObject<LoginResponse>(await response.Content.ReadAsStringAsync());
            _userTokens[username] = result.Token;
            return result.Token;
        }

        public async Task InitializeAsync()
        {
            _adminClient.DefaultRequestHeaders.Authorization =
    new AuthenticationHeaderValue("Bearer", await GetTokenAsync("Admin", "BrewHelperAdmin1!"));

            _userClient.DefaultRequestHeaders.Authorization =
    new AuthenticationHeaderValue("Bearer", await GetTokenAsync("User", "BrewHelperUser1!"));

        }

        public Task DisposeAsync()
        {
            return Task.CompletedTask;
        }
    }
}
