namespace BrewHelper.Web.Ingredients.Hops.Stores.Filters;

using BrewHelper.Web.Ingredients.Fermentables.Stores.Filters;
using BrewHelper.Web.Ingredients.Fermentables.Stores.Filters.Actions;
using BrewHelper.Web.Ingredients.Hops.Stores.Filters.Actions;
using Fluxor;

public class HopsFilterReducers
{
    [ReducerMethod]
    public static HopsFilterState Reduce(HopsFilterState state, UpdateHopsFilterAction action) =>
        new(action.Filters);

    [ReducerMethod]
    public static HopsFilterState Reduce(HopsFilterState state, ResetHopsFilterAction action) =>
        new();
}