namespace BrewHelper.Web.Ingredients.Fermentables.Stores.Fermentable;

using BrewHelper.Data.Entities;
using BrewHelper.Web.Ingredients.Fermentables.Stores.Fermentable.Actions;
using Fluxor;

public class FermentableReducers
{
    [ReducerMethod]
    public static FermentableState Reduce(FermentableState state, GetFermentableAction action) =>
        new(true, null, null);

    [ReducerMethod]
    public static FermentableState Reduce(FermentableState state, GetFermentableResultAction action) =>
        new(false, action.Fermentable, action.InUse);

    [ReducerMethod]
    public static FermentableState Reduce(FermentableState state, UpdateFermentableAction action) =>
        new(false, action.Fermentable, state.InUse);
}