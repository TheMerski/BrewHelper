using BrewHelper.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrewHelper
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string connection = Configuration.GetConnectionString("Dev");

            services.AddDbContext<BrewhelperContext>(opt =>
                                           opt.UseSqlServer(connection));

            services.AddCors();

            services.AddOpenApiDocument(config =>
            {
                config.GenerateEnumMappingDescription = true;
            });

            services.AddControllers();

            services.AddTransient<RecipeModel>();
            services.AddTransient<IngredientModel>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                using var serviceScope = app.ApplicationServices
                            .GetRequiredService<IServiceScopeFactory>()
                            .CreateScope();
                var service = serviceScope.ServiceProvider;

                TestDataSeeder.Seed(service);
            }

            app.UseCors(
                    options => options.WithOrigins("https://localhost:3000").AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin()
                );

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseOpenApi(); // serve OpenAPI/Swagger documents
            app.UseSwaggerUi3(); // serve Swagger UI
            app.UseReDoc(); // serve ReDoc UI
        }
    }
}
