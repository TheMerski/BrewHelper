namespace BrewHelper.Web.Ingredients.Hops.Stores.Hop;

using BrewHelper.Web.Ingredients.Fermentables.Stores.Fermentable;
using BrewHelper.Web.Ingredients.Fermentables.Stores.Fermentable.Actions;
using BrewHelper.Web.Ingredients.Hops.Stores.Hop.Actions;
using Fluxor;

public class HopReducers
{
    [ReducerMethod]
    public static HopState Reduce(HopState state, GetHopAction action) =>
        new(true, null, null);

    [ReducerMethod]
    public static HopState Reduce(HopState state, GetHopResultAction action) =>
        new(false, action.Hop, action.InUse);

    [ReducerMethod]
    public static HopState Reduce(HopState state, UpdateHopAction action) =>
        new(false, action.Hop, state.InUse);
}