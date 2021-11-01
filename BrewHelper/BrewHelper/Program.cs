using BrewHelper.Authentication;
using BrewHelper.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace BrewHelper
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;

            try
            {
                var dbContext = services.GetRequiredService<BrewhelperContext>();
                if (dbContext.Database.IsSqlServer())
                {
                    dbContext.Database.Migrate();
                }
            }
            catch (Exception ex)
            {
                var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

                logger.LogError(ex, "An error occurred while migrating or seeding the database");

                throw;
            }
            //
            // try
            // {
            //     var authenticationDbContext = services.GetRequiredService<AuthenticationDbContext>();
            //     if (authenticationDbContext.Database.IsSqlServer())
            //     {
            //         authenticationDbContext.Database.Migrate();
            //     }
            // }
            // catch (Exception ex)
            // {
            //     var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
            //
            //     logger.LogError(ex, "An error occurred while migrating or seeding the authentication database");
            //
            //     throw;
            // }

            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
