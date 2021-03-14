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
        protected readonly HttpClient _client;
        protected readonly IConfiguration _configuration;
        protected string token = null;

        public IntegrationTest(BrewHelperWebApplicationFactory factory)
        {
            _factory = factory;
            _client = _factory.CreateClient();
            _client.DefaultRequestHeaders.Authorization =
    new AuthenticationHeaderValue("Bearer", GetTokenAsync().Result);
            //_checkpoint.Reset(factory._dbFixture.ConnString).Wait();
        }

        public async Task<string> GetTokenAsync()
        {
            if (token != null)
            {
                return token;
            }
            LoginDTO admin = new LoginDTO
            {
                Username = "Admin",
                Password = "BrewHelperAdm1n!"
            };
            var json = JsonConvert.SerializeObject(admin);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, MediaTypeNames.Application.Json);

            var response = await _client.PostAsync($"/api/Authentication/login", stringContent);
            var result = JsonConvert.DeserializeObject<LoginResponse>(await response.Content.ReadAsStringAsync());
            token = result.token;
            return token;
        }
    }
}
