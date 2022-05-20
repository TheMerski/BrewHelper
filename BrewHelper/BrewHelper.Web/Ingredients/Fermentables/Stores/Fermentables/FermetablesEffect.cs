namespace BrewHelper.Web.Ingredients.Fermentables.Stores.Fermentables;

using System.Linq;
using System.Threading.Tasks;
using BrewHelper.Business.Fermentables;
using BrewHelper.Web.Ingredients.Fermentables.Stores.Fermentables.Actions;
using Fluxor;

public class FermetablesEffect
{
    private readonly IFermentableService fermentableService;

    public FermetablesEffect(IFermentableService fermentableService)
    {
        this.fermentableService = fermentableService;
    }

    [EffectMethod]
    public Task GetFermentables(GetFermentablesAction action, IDispatcher dispatcher)
    {
        var fermentables = this.fermentableService.GetFermentables();

        if (action.Filters != null)
        {
            if (action.Filters.Query != null && !string.IsNullOrWhiteSpace(action.Filters.Query))
            {
                fermentables = fermentables.Where((f) => f.Name.Contains(action.Filters.Query.Trim()));
            }

            fermentables = fermentables.Where((f) => action.Filters.Types.Contains(f.Type));
        }

        dispatcher.Dispatch(new GetFermentablesResultAction(fermentables));

        return Task.CompletedTask;
    }
}