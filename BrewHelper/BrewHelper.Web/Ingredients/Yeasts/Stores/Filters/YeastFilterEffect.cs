namespace BrewHelper.Web.Ingredients.Yeasts.Stores.Filters;

using System.Threading.Tasks;
using BrewHelper.Web.Ingredients.Yeasts.Stores.Filters.Actions;
using BrewHelper.Web.Ingredients.Yeasts.Stores.Yeasts.Actions;
using Fluxor;

public class YeastFilterEffect
{
    [EffectMethod]
    public Task FilterYeasts(UpdateYeastsFilterAction action, IDispatcher dispatcher)
    {
        dispatcher.Dispatch(new GetYeastsAction(action.Filters));

        return Task.CompletedTask;
    }
}
