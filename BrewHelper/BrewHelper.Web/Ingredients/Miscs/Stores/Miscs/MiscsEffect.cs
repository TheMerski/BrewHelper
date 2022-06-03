namespace BrewHelper.Web.Ingredients.Miscs.Stores.Miscs;

using System.Linq;
using System.Threading.Tasks;
using BrewHelper.Business.Miscs;
using BrewHelper.Web.Ingredients.Fermentables.Stores.Fermentables.Actions;
using BrewHelper.Web.Ingredients.Miscs.Stores.Miscs.Actions;
using Fluxor;

public class MiscsEffect
{
    private readonly IMiscService miscService;

    public MiscsEffect(IMiscService miscService)
    {
        this.miscService = miscService;
    }

    [EffectMethod]
    public Task GetMiscs(GetMiscsAction action, IDispatcher dispatcher)
    {
        var miscs = this.miscService.GetMiscs();

        if (action.Filters != null)
        {
            if (action.Filters.Query != null && !string.IsNullOrWhiteSpace(action.Filters.Query))
            {
                miscs = miscs.Where((e) => e.Name.Contains(action.Filters.Query.Trim()));
            }
        }

        dispatcher.Dispatch(new GetMiscsResultAction(miscs));

        return Task.CompletedTask;
    }
}