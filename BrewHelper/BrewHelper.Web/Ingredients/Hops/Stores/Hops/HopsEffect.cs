namespace BrewHelper.Web.Ingredients.Hops.Stores.Hops;

using System.Linq;
using System.Threading.Tasks;
using BrewHelper.Business.Hops;
using BrewHelper.Web.Ingredients.Fermentables.Stores.Fermentables.Actions;
using BrewHelper.Web.Ingredients.Hops.Stores.Hops.Actions;
using Fluxor;

public class HopsEffect
{
    private readonly IHopService hopService;

    public HopsEffect(IHopService hopService)
    {
        this.hopService = hopService;
    }

    [EffectMethod]
    public Task GetHops(GetHopsAction action, IDispatcher dispatcher)
    {
        var hops = this.hopService.GetHops();

        if (action.Filters != null)
        {
            if (action.Filters.Query != null && !string.IsNullOrWhiteSpace(action.Filters.Query))
            {
                hops = hops.Where((e) => e.Name.Contains(action.Filters.Query.Trim()));
            }
        }

        dispatcher.Dispatch(new GetHopsResultAction(hops));

        return Task.CompletedTask;
    }
}