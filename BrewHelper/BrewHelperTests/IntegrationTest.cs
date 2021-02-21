using Microsoft.Extensions.Configuration;
using Respawn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

        public IntegrationTest(BrewHelperWebApplicationFactory factory)
        {
            _factory = factory;
            _client = _factory.CreateClient();

            //_checkpoint.Reset(factory._dbFixture.ConnString).Wait();
        }
    }
}
