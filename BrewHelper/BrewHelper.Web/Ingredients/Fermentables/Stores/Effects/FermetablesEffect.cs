namespace BrewHelper.Web.Ingredients.Fermentables.Stores.Effects;

using System;
using System.Threading.Tasks;
using BrewHelper.Business.Fermentables;
using BrewHelper.Web.Ingredients.Fermentables.Stores.Actions;
using BrewHelper.Web.Shared.Snackbar.Stores.Actions;
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

    [EffectMethod]
    public async Task CreateRecipes(CreateFermentableAction action, IDispatcher dispatcher)
    {
        try
        {
            await this.fermentableService.CreateFermentable(action.Fermentable);
            dispatcher.Dispatch(new SuccessMessageAction("Fermentable created successfully"));
            dispatcher.Dispatch(new GetFermentablesAction());
        }
        catch (Exception e)
        {
            dispatcher.Dispatch(new ErrorMessageAction(e));
        }

        return;
    }
}