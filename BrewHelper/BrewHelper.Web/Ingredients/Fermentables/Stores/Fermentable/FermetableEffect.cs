namespace BrewHelper.Web.Ingredients.Fermentables.Stores.Fermentable;

using System;
using System.Threading.Tasks;
using BrewHelper.Business.Fermentables;
using BrewHelper.Web.Ingredients.Fermentables.Stores.Fermentable.Actions;
using BrewHelper.Web.Ingredients.Fermentables.Stores.Fermentables.Actions;
using BrewHelper.Web.Shared.Snackbar.Stores.Actions;
using Fluxor;

public class FermetableEffect
{
    private readonly IFermentableService fermentableService;

    public FermetableEffect(IFermentableService fermentableService)
    {
        this.fermentableService = fermentableService;
    }

    [EffectMethod]
    public async Task GetFermentable(GetFermentableAction action, IDispatcher dispatcher)
    {
        try
        {
            var fermentable = await this.fermentableService.GetFermentable(action.Id);
            var inUse = await this.fermentableService.FermentableInUse(fermentable);

            dispatcher.Dispatch(new GetFermentableResultAction(fermentable, inUse));
        }
        catch (Exception e)
        {
            dispatcher.Dispatch(new ErrorMessageAction(e));
        }

        return;
    }

    [EffectMethod]
    public async Task CreateFermentable(CreateFermentableAction action, IDispatcher dispatcher)
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

    [EffectMethod]
    public async Task DeleteFermentable(DeleteFermentableAction action, IDispatcher dispatcher)
    {
        try
        {
            await this.fermentableService.DeleteFermentable(action.Fermentable);
            dispatcher.Dispatch(new SuccessMessageAction("Fermentable deleted successfully"));
            dispatcher.Dispatch(new GetFermentablesAction());
        }
        catch (Exception e)
        {
            dispatcher.Dispatch(new ErrorMessageAction(e));
        }

        return;
    }
}