namespace BrewHelper.Web.Admin.Users.Stores.Actions
{
    using System.Linq;
    using BrewHelper.Authentication.Users;

    public record GetUsersResultAction(IQueryable<ApplicationUser> Users);
}