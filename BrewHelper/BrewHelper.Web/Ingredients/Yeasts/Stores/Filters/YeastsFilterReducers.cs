namespace BrewHelper.Web.Ingredients.Yeasts.Stores.Filters;

using BrewHelper.Web.Ingredients.Fermentables.Stores.Filters;
using BrewHelper.Web.Ingredients.Fermentables.Stores.Filters.Actions;
using BrewHelper.Web.Ingredients.Yeasts.Stores.Filters.Actions;
using Fluxor;

public class YeastsFilterReducers
{
    [ReducerMethod]
    public static YeastsFilterState Reduce(YeastsFilterState state, UpdateYeastsFilterAction action) =>
        new(action.Filters);

    [ReducerMethod]
    public static YeastsFilterState Reduce(YeastsFilterState state, ResetYeastsFilterAction action) =>
        new();
}