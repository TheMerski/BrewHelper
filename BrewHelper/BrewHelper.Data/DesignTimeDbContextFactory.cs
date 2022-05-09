namespace BrewHelper.Data
{
    using System.IO;
    using BrewHelper.Data.Context;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using Microsoft.Extensions.Configuration;

    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<BrewhelperContext>
    {
        public BrewhelperContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(@Directory.GetCurrentDirectory() + "/../BrewHelper.Web/appsettings.json").Build();
            var builder = new DbContextOptionsBuilder<BrewhelperContext>();
            var connectionString = configuration.GetConnectionString("Data");
            builder.UseSqlServer(connectionString);
            return new BrewhelperContext(builder.Options);
        }
    }
}