namespace BrewHelper.Web.Ingredients.Hops.Stores.Filters;

using System.Threading.Tasks;
using BrewHelper.Web.Ingredients.Hops.Stores.Filters.Actions;
using BrewHelper.Web.Ingredients.Hops.Stores.Hops.Actions;
using Fluxor;

public class HopFilterEffect
{
    [EffectMethod]
    public Task FilterHops(UpdateHopsFilterAction action, IDispatcher dispatcher)
    {
        dispatcher.Dispatch(new GetHopsAction(action.Filters));

        return Task.CompletedTask;
    }
}
