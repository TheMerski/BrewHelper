namespace BrewHelper.Web.Ingredients.Fermentables.Stores.Fermentables;

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

        dispatcher.Dispatch(new GetFermentablesResultAction(fermentables));

        return Task.CompletedTask;
    }
}