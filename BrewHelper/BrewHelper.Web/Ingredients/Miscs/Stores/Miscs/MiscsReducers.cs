namespace BrewHelper.Web.Ingredients.Miscs.Stores.Miscs;

using BrewHelper.Web.Ingredients.Miscs.Stores.Miscs.Actions;
using Fluxor;

public class MiscsReducers
{
    [ReducerMethod]
    public static MiscsState Reduce(MiscsState state, GetMiscsAction action) =>
        new(true, null);

    [ReducerMethod]
    public static MiscsState Reduce(MiscsState state, GetMiscsResultAction action) =>
        new(false, action.Miscs);
}