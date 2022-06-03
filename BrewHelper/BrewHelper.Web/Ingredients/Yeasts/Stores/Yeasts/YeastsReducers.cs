namespace BrewHelper.Web.Ingredients.Yeasts.Stores.Yeasts;

using BrewHelper.Web.Ingredients.Fermentables.Stores.Fermentables.Actions;
using BrewHelper.Web.Ingredients.Yeasts.Stores.Yeasts.Actions;
using Fluxor;

public class YeastsReducers
{
    [ReducerMethod]
    public static YeastsState Reduce(YeastsState state, GetYeastsAction action) =>
        new(true, null);

    [ReducerMethod]
    public static YeastsState Reduce(YeastsState state, GetYeastsResultAction action) =>
        new(false, action.Yeasts);
}