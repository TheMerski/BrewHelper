namespace BrewHelper.Web.Admin.Users
{
    using BrewHelper.Authentication.Users.Interfaces;
    using BrewHelper.Web.Admin.Users.Stores.Actions;
    using Fluxor;
    using Microsoft.AspNetCore.Components;

    public partial class Users
    {
        [Inject]
        private IDispatcher Dispatcher { get; set; } = default!;

        [Inject]
        private IUsersService UsersService { get; set; } = default!;

        protected override void OnInitialized()
        {
            base.OnInitialized();

            this.Dispatcher.Dispatch(new GetUsersAction());
        }
    }
}