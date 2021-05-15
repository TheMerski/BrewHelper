using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BrewHelperTests
{
    [Collection("Database")]
    public class BrewHelperWebApplicationFactory : WebApplicationFactory<BrewHelper.Startup>
    {
        public readonly DbFixture _dbFixture;

        public BrewHelperWebApplicationFactory(DbFixture dbFixture)
        {
            _dbFixture = dbFixture;
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Test");


            builder.ConfigureAppConfiguration((context, config) =>
            {
                config.AddInMemoryCollection(new[]
                {
                    new KeyValuePair<string, string>(
                        "ConnectionStrings:SQL", _dbFixture.ConnString),
                    new KeyValuePair<string, string>(
                        "ConnectionStrings:Authentication", _dbFixture.AuthConnString)
                });
            });
        }
    }
}
