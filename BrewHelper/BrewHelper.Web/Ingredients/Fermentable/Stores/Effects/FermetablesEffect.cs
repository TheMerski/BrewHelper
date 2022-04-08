namespace BrewHelper.Web.Ingredients.Fermentable.Stores.Effects;

using System.Threading.Tasks;
using BrewHelper.Business.Fermentables;
using BrewHelper.Web.Ingredients.Fermentable.Stores.Actions;
using Fluxor;

public class FermetablesEffect
{
    private readonly IFermentableService fermentableService;

    public FermetablesEffect(IFermentableService fermentableService)
    {
        this.fermentableService = fermentableService;
    }

    [EffectMethod]
    public Task GetRecipes(GetFermentablesAction action, IDispatcher dispatcher)
    {
        var fermentables = this.fermentableService.GetFermentables();

        dispatcher.Dispatch(new GetFermentablesResultAction(fermentables));

        return Task.CompletedTask;
    }
}