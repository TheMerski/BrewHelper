namespace BrewHelper.Web.Ingredients.Fermentables.Stores.Reducers;

using BrewHelper.Web.Ingredients.Fermentables.Stores.Actions;
using BrewHelper.Web.Ingredients.Fermentables.Stores.States;
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