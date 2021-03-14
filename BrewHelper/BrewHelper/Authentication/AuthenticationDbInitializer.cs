using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrewHelper.Authentication
{
    public class AuthenticationDbInitializer
    {
        public static void SeedAdmin(UserManager<ApplicationUser> userManager)
        {
            if (userManager.FindByNameAsync("Admin").Result == null)
            {
                ApplicationUser user = new ApplicationUser
                {
                    UserName = "Admin",
                    Email = "admin@brewhelper.nl",
                };

                IdentityResult result = userManager.CreateAsync(user, "BrewHelperAdm1n!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRolesAsync(user, new string[] { ApplicationRoles.Admin.ToString(), ApplicationRoles.User.ToString() });
                }
            }
        }
    }
}
