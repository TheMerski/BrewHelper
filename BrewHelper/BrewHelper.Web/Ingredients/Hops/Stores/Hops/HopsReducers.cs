namespace BrewHelper.Web.Ingredients.Hops.Stores.Hops;

using BrewHelper.Web.Ingredients.Fermentables.Stores.Fermentables.Actions;
using BrewHelper.Web.Ingredients.Hops.Stores.Hops.Actions;
using Fluxor;

public class HopsReducers
{
    [ReducerMethod]
    public static HopsState Reduce(HopsState state, GetHopsAction action) =>
        new(true, null);

    [ReducerMethod]
    public static HopsState Reduce(HopsState state, GetHopsResultAction action) =>
        new(false, action.Hops);
}