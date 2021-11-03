namespace BrewHelper.Authentication.Users
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using BrewHelper.Authentication.Extensions;
    using BrewHelper.Authentication.Users.Interfaces;
    using Microsoft.AspNetCore.Identity;

    public class UsersService : IUsersService
    {
        private readonly UserManager<ApplicationUser> userManager;

        public UsersService(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public IQueryable<ApplicationUser> GetUsers()
        {
            return this.userManager.Users;
        }

        public async Task<List<ApplicationRoles>> GetUserRoles(ApplicationUser user)
        {
            IList<string> userRoles = await this.userManager.GetRolesAsync(user);
            return userRoles.GetApplicationRoles().ToList();
        }

        public async Task UpdateUserRoles(ApplicationUser user, List<ApplicationRoles> userRoles)
        {
            List<ApplicationRoles> currentRoles = await this.GetUserRoles(user);
            if (!userRoles.All(currentRoles.Contains))
            {
                List<ApplicationRoles> newRoles = userRoles.Where(r => !currentRoles.Contains(r)).ToList();
                List<ApplicationRoles> removedRoles = currentRoles.Where(r => !userRoles.Contains(r)).ToList();
                if (newRoles.Count > 0)
                {
                    await this.userManager.AddToRolesAsync(user, newRoles.Select(r => r.ToString()).ToArray());
                }

                if (removedRoles.Count > 0)
                {
                    await this.userManager.RemoveFromRolesAsync(user, removedRoles.Select(r => r.ToString()).ToArray());
                }
            }
        }
    }
}