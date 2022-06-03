namespace BrewHelper.Web.Ingredients.Miscs.Stores.Filters;

using BrewHelper.Web.Ingredients.Miscs.Stores.Filters.Actions;
using Fluxor;

public class MiscsFilterReducers
{
    [ReducerMethod]
    public static MiscsFilterState Reduce(MiscsFilterState state, UpdateMiscsFilterAction action) =>
        new(action.Filters);

    [ReducerMethod]
    public static MiscsFilterState Reduce(MiscsFilterState state, ResetMiscsFilterAction action) =>
        new();
}