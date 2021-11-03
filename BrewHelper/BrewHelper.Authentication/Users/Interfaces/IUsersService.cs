namespace BrewHelper.Authentication.Users.Interfaces
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IUsersService
    {
        public IQueryable<ApplicationUser> GetUsers();

        public Task<List<ApplicationRoles>> GetUserRoles(ApplicationUser user);

        public Task UpdateUserRoles(ApplicationUser user, List<ApplicationRoles> userRoles);
    }
}