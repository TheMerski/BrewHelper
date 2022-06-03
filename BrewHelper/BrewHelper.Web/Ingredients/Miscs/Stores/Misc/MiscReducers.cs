namespace BrewHelper.Web.Ingredients.Miscs.Stores.Misc;

using BrewHelper.Web.Ingredients.Fermentables.Stores.Fermentable;
using BrewHelper.Web.Ingredients.Fermentables.Stores.Fermentable.Actions;
using BrewHelper.Web.Ingredients.Miscs.Stores.Misc.Actions;
using Fluxor;

public class MiscReducers
{
    [ReducerMethod]
    public static MiscState Reduce(MiscState state, GetMiscAction action) =>
        new(true, null, null);

    [ReducerMethod]
    public static MiscState Reduce(MiscState state, GetMiscResultAction action) =>
        new(false, action.Misc, action.InUse);

    [ReducerMethod]
    public static MiscState Reduce(MiscState state, UpdateMiscAction action) =>
        new(false, action.Misc, state.InUse);
}