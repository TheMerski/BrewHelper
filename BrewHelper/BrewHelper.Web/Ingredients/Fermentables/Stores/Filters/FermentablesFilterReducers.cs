namespace BrewHelper.Web.Ingredients.Fermentables.Stores.Filters;

using BrewHelper.Data.Entities;
using BrewHelper.Web.Ingredients.Fermentables.Stores.Fermentable.Actions;
using BrewHelper.Web.Ingredients.Fermentables.Stores.Filters.Actions;
using Fluxor;

public class FermentablesFilterReducers
{
    [ReducerMethod]
    public static FermentablesFilterState Reduce(FermentablesFilterState state, UpdateFermentablesFilterAction action) =>
        new(action.Filters);

    [ReducerMethod]
    public static FermentablesFilterState Reduce(FermentablesFilterState state, ResetFermentablesFilterAction action) =>
        new();
}