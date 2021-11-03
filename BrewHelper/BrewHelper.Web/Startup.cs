namespace BrewHelper.Web
{
    using Blazored.LocalStorage;
    using Blazored.SessionStorage;
    using BrewHelper.Authentication.Context;
    using BrewHelper.Authentication.DTO;
    using BrewHelper.Authentication.Users;
    using BrewHelper.Authentication.Users.Interfaces;
    using BrewHelper.Business.Ingredient;
    using BrewHelper.Business.Ingredient.Interfaces;
    using BrewHelper.Data;
    using BrewHelper.Data.Context;
    using BrewHelper.Web.Helpers;
    using Fluxor;
    using Fluxor.Persist.Middleware;
    using Fluxor.Persist.Storage;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;
    using MudBlazor;
    using MudBlazor.Services;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BrewhelperContext>(options =>
                options.UseSqlServer(
                    this.Configuration.GetConnectionString("Data"), x => x.MigrationsAssembly("BrewHelper.Data")));

            services.AddDbContext<AuthenticationDbContext>(options =>
                options.UseSqlServer(
                    this.Configuration.GetConnectionString("Authentication"),
                    x => x.MigrationsAssembly("BrewHelper.Authentication")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<AuthenticationDbContext>()
                .AddDefaultTokenProviders();

            services.AddMvc()
                .AddRazorPagesOptions(options =>
                {
                    options.Conventions.AuthorizeAreaFolder("Identity", "/Account/Manage");
                    options.Conventions.AuthorizeAreaPage("Identity", "/Account/Logout");
                });

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = $"/Identity/Account/Login";
                options.LogoutPath = $"/Identity/Account/Logout";
                options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
            });

            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddServerSideBlazor();
            services.AddMudServices(config =>
            {
                config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomRight;
            });
            services.AddBlazoredLocalStorage();
            services.AddBlazoredSessionStorage();

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddFluxor(o => o
                .ScanAssemblies(typeof(Program).Assembly)
                .UseReduxDevTools()
                .UsePersist(options => options.UseInclusionApproach()));

            services.AddScoped<TokenProvider>();

            // Fluxor persists
            services.AddScoped<IStringStateStorage, StateStorageProvider>();
            services.AddScoped<IStoreHandler, JsonStoreHandler>();

            // Data Services
            services.AddScoped<IIngredientService, IngredientService>();
            services.AddScoped<IUsersService, UsersService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
                using var serviceScope = app.ApplicationServices
                    .GetRequiredService<IServiceScopeFactory>()
                    .CreateScope();
                var service = serviceScope.ServiceProvider;
                InitialDataSeeder.Seed(service);
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

            AuthenticationDbInitializer.SeedRoles(roleManager);
            AuthenticationDbInitializer.SeedAdmin(userManager);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });

            if (env.IsEnvironment("Test"))
            {
                AuthenticationDbInitializer.SeedTestUsers(userManager);
            }
        }
    }
}