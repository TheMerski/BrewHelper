using System.Threading.Tasks;
using BrewHelper.Web.Ingredients.Fermentables.Stores.Fermentables.Actions;
using Fluxor;

namespace BrewHelper.Web.Ingredients.Fermentables.Stores.Filters;

using BrewHelper.Web.Ingredients.Fermentables.Stores.Filters.Actions;

public class FermentableFilterEffect
{
    [EffectMethod]
    public Task FilterFermentables(UpdateFermentablesFilterAction action, IDispatcher dispatcher)
    {
        dispatcher.Dispatch(new GetFermentablesAction(action.Filters));

        return Task.CompletedTask;
    }
}
