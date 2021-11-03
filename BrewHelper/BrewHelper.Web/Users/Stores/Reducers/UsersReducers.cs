namespace BrewHelper.Web.Users.Stores.Reducers
{
    using BrewHelper.Web.Users.Stores.Actions;
    using BrewHelper.Web.Users.Stores.States;
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