namespace BrewHelper.Web.Ingredients.Fermentable.Stores.Reducers;

using BrewHelper.Web.Ingredients.Fermentable.Stores.Actions;
using BrewHelper.Web.Ingredients.Fermentable.Stores.States;
using Fluxor;

public class FermentablesReducers
{
    [ReducerMethod]
    public static FermentablesState Reduce(FermentablesState state, GetFermentablesAction action) =>
        new(true, null);

    [ReducerMethod]
    public static FermentablesState Reduce(FermentablesState state, GetFermentablesResultAction action) =>
        new(false, action.Fermentables);
}