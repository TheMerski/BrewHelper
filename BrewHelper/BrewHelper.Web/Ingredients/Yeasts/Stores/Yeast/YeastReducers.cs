namespace BrewHelper.Web.Ingredients.Yeasts.Stores.Yeast;

using BrewHelper.Web.Ingredients.Fermentables.Stores.Fermentable;
using BrewHelper.Web.Ingredients.Fermentables.Stores.Fermentable.Actions;
using BrewHelper.Web.Ingredients.Yeasts.Stores.Yeast.Actions;
using Fluxor;

public class YeastReducers
{
    [ReducerMethod]
    public static YeastState Reduce(YeastState state, GetYeastAction action) =>
        new(true, null, null);

    [ReducerMethod]
    public static YeastState Reduce(YeastState state, GetYeastResultAction action) =>
        new(false, action.Yeast, action.InUse);

    [ReducerMethod]
    public static YeastState Reduce(YeastState state, UpdateYeastAction action) =>
        new(false, action.Yeast, state.InUse);
}