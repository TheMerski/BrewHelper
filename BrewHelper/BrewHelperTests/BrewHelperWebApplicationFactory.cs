using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using Xunit;

namespace BrewHelperTests
{
    [Collection("Database")]
    public class BrewHelperWebApplicationFactory : WebApplicationFactory<BrewHelper.Startup>
    {
        public readonly DbFixture DbFixture;

        public BrewHelperWebApplicationFactory(DbFixture dbFixture)
        {
            DbFixture = dbFixture;
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Test");


            builder.ConfigureAppConfiguration((context, config) =>
            {
                config.AddInMemoryCollection(new[]
                {
                    new KeyValuePair<string, string>(
                        "ConnectionStrings:SQL", DbFixture.ConnString),
                    new KeyValuePair<string, string>(
                        "ConnectionStrings:Authentication", DbFixture.ConnString)
                });
            });
        }
    }
}
