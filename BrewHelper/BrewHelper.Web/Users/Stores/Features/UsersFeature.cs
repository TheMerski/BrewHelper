namespace BrewHelper.Web.Users.Stores.Features
{
    using BrewHelper.Web.Users.Stores.States;
    using Fluxor;

    public class UsersFeature : Feature<UsersState>
    {
        public override string GetName() => nameof(UsersState);

        protected override UsersState GetInitialState() =>
            new(false, null);
    }
}