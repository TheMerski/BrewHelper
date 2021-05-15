using BrewHelper.Authentication;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Respawn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace BrewHelperTests
{
    [Collection("Database")]
    public abstract class IntegrationTest : IClassFixture<BrewHelperWebApplicationFactory>
    {
        private readonly Checkpoint _checkpoint = new Checkpoint
        {
            SchemasToInclude = new[] {
            "Recipes"
            },
            WithReseed = true
        };

        protected readonly BrewHelperWebApplicationFactory _factory;
        protected readonly HttpClient _adminClient;
        protected readonly HttpClient _userClient;
        protected readonly IConfiguration _configuration;

        protected readonly JsonSerializerOptions _serializeOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        public IntegrationTest(BrewHelperWebApplicationFactory factory)
        {
            _factory = factory;
            _adminClient = _factory.CreateClient();
            _adminClient.DefaultRequestHeaders.Authorization =
    new AuthenticationHeaderValue("Bearer", GetTokenAsync("Admin", "BrewHelperAdmin1!").Result);


            _userClient = _factory.CreateClient();
            _userClient.DefaultRequestHeaders.Authorization =
    new AuthenticationHeaderValue("Bearer", GetTokenAsync("User", "BrewHelperUser1!").Result);
            //_checkpoint.Reset(factory._dbFixture.ConnString).Wait();
        }

        public async Task<string> GetTokenAsync(string username, string password)
        {

            LoginDTO user = new LoginDTO
            {
                Username = username,
                Password = password
            };
            var json = JsonConvert.SerializeObject(user);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, MediaTypeNames.Application.Json);

            var response = await _adminClient.PostAsync($"/api/Authentication/login", stringContent);
            var result = JsonConvert.DeserializeObject<LoginResponse>(await response.Content.ReadAsStringAsync());
            return result.token;
        }
    }
}
