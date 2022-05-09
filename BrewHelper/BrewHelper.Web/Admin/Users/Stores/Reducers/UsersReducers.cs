namespace BrewHelper.Web.Admin.Users.Stores.Reducers
{
    using BrewHelper.Web.Admin.Users.Stores.Actions;
    using BrewHelper.Web.Admin.Users.Stores.States;
    using Fluxor;

    public class UsersReducers
    {
        [ReducerMethod]
        public static UsersState Reduce(UsersState state, GetUsersAction action) =>
            new(true, null);

        [ReducerMethod]
        public static UsersState Reduce(UsersState state, GetUsersResultAction action) =>
            new(false, action.Users);
    }
}