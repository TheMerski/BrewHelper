namespace BrewHelper.Web.Users.Stores.States
{
    using System.Linq;
    using BrewHelper.Authentication.Users;

    public record UsersState(bool IsLoading, IQueryable<ApplicationUser>? Users);
}