namespace BrewHelper.Web.Ingredients.Miscs.Stores.Filters;

using System.Threading.Tasks;
using BrewHelper.Web.Ingredients.Miscs.Stores.Filters.Actions;
using BrewHelper.Web.Ingredients.Miscs.Stores.Miscs.Actions;
using Fluxor;

public class MiscFilterEffect
{
    [EffectMethod]
    public Task FilterMiscs(UpdateMiscsFilterAction action, IDispatcher dispatcher)
    {
        dispatcher.Dispatch(new GetMiscsAction(action.Filters));

        return Task.CompletedTask;
    }
}
