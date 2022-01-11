namespace BrewHelper.Web.Admin.Users.Stores.Effects
{
    using System.Threading.Tasks;
    using BrewHelper.Authentication.Users.Interfaces;
    using BrewHelper.Web.Admin.Users.Stores.Actions;
    using Fluxor;

    public class UsersEffects
    {
        private readonly IUsersService usersService;

        public UsersEffects(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        [EffectMethod]
        public Task GetUsers(GetUsersAction action, IDispatcher dispatcher)
        {
            var users = this.usersService.GetUsers();

            dispatcher.Dispatch(new GetUsersResultAction(users));

            return Task.CompletedTask;
        }
    }
}