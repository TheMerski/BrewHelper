using System.IO;
using BrewHelper.Authentication.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BrewHelper.Authentication
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AuthenticationDbContext>
    {
        public AuthenticationDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(@Directory.GetCurrentDirectory() + "/../BrewHelper.Web/appsettings.json").Build();
            var builder = new DbContextOptionsBuilder<AuthenticationDbContext>();
            var connectionString = configuration.GetConnectionString("Authentication");
            builder.UseSqlServer(connectionString);
            return new AuthenticationDbContext(builder.Options);
        }
    }
}