namespace BrewHelper.Web.Recipes.Stores.Reducers
{
    using BrewHelper.Web.Recipes.Stores.Actions;
    using BrewHelper.Web.Recipes.Stores.States;
    using Fluxor;

    public class RecipesReducers
    {
        [ReducerMethod]
        public static RecipesState Reduce(RecipesState state, GetRecipesAction action) =>
            new(true, null);

        [ReducerMethod]
        public static RecipesState Reduce(RecipesState state, GetRecipesResultAction action) =>
            new(false, action.Recipes);
    }
}