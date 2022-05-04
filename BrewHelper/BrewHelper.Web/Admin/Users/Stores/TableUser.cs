namespace BrewHelper.Web.Admin.Users.Stores
{
    using System.Collections.Generic;
    using BrewHelper.Authentication.Users;

    public record TableUser(ApplicationUser User, List<ApplicationRoles> Roles);
}