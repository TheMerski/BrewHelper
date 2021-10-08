using Microsoft.AspNetCore.Identity;
using System;

namespace BrewHelper.Authentication
{
    public class AuthenticationDbInitializer
    {
        public static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            foreach (ApplicationRoles role in (ApplicationRoles[])Enum.GetValues(typeof(ApplicationRoles)))
            {
                if (!roleManager.RoleExistsAsync(role.ToString()).Result)
                {
                    IdentityRole iRole = new IdentityRole(role.ToString());
                    roleManager.CreateAsync(iRole).Wait();
                }
            }
        }

        public static void SeedAdmin(UserManager<ApplicationUser> userManager)
        {
            if (userManager.FindByNameAsync("Admin").Result == null)
            {
                ApplicationUser user = new ApplicationUser
                {
                    UserName = "Admin",
                    Email = "admin@brewhelper.nl",
                };

                IdentityResult result = userManager.CreateAsync(user, "BrewHelperAdmin1!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRolesAsync(user, new [] { ApplicationRoles.Admin.ToString(), ApplicationRoles.User.ToString() }).Wait();
                }
            }
        }

        public static void SeedTestUsers(UserManager<ApplicationUser> userManager)
        {
            if (userManager.FindByNameAsync("User").Result == null)
            {
                ApplicationUser user = new ApplicationUser
                {
                    UserName = "User",
                    Email = "user@brewhelper.nl",
                };

                IdentityResult result = userManager.CreateAsync(user, "BrewHelperUser1!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRolesAsync(user, new [] { ApplicationRoles.User.ToString() }).Wait();
                }
            }
        }
    }
}
