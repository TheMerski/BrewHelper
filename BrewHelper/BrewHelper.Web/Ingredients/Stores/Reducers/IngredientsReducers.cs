namespace BrewHelper.Web.Ingredients.Stores.Reducers
{
    using BrewHelper.Web.Ingredients.Stores.Actions;
    using BrewHelper.Web.Ingredients.Stores.States;
    using Fluxor;

    public class IngredientsReducers
    {
        [ReducerMethod]
        public static IngredientsState Reduce(IngredientsState state, GetIngredientsAction action) =>
            new(true, null);

        [ReducerMethod]
        public static IngredientsState Reduce(IngredientsState state, GetIngredientsResultAction action) =>
            new(false, action.Ingredients);
    }
}