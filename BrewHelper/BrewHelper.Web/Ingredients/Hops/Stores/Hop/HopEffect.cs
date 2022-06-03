namespace BrewHelper.Web.Ingredients.Hops.Stores.Hop;

using System;
using System.Threading.Tasks;
using BrewHelper.Business.Hops;
using BrewHelper.Web.Ingredients.Hops.Stores.Hop.Actions;
using BrewHelper.Web.Ingredients.Hops.Stores.Hops.Actions;
using BrewHelper.Web.Shared.Snackbar.Stores.Actions;
using Fluxor;

public class HopEffect
{
    private readonly IHopService hopService;

    public HopEffect(IHopService hopService)
    {
        this.hopService = hopService;
    }

    [EffectMethod]
    public async Task GetHop(GetHopAction action, IDispatcher dispatcher)
    {
        try
        {
            var hop = await this.hopService.GetHop(action.Id);
            var inUse = await this.hopService.HopInUse(hop);

            dispatcher.Dispatch(new GetHopResultAction(hop, inUse));
        }
        catch (Exception e)
        {
            dispatcher.Dispatch(new ErrorMessageAction(e));
        }

        return;
    }

    [EffectMethod]
    public async Task CreateHop(CreateHopAction action, IDispatcher dispatcher)
    {
        try
        {
            await this.hopService.CreateHop(action.Hop);
            dispatcher.Dispatch(new SuccessMessageAction("Hop created successfully"));
            dispatcher.Dispatch(new GetHopsAction());
        }
        catch (Exception e)
        {
            dispatcher.Dispatch(new ErrorMessageAction(e));
        }

        return;
    }

    [EffectMethod]
    public async Task CreateHopVersion(CreateHopVersionAction action, IDispatcher dispatcher)
    {
        try
        {
            await this.hopService.CreateHopVersion(action.HopToCopy);
            dispatcher.Dispatch(new SuccessMessageAction("Hop copied successfully"));
            dispatcher.Dispatch(new GetHopsAction());
        }
        catch (Exception e)
        {
            dispatcher.Dispatch(new ErrorMessageAction(e));
        }

        return;
    }

    [EffectMethod]
    public async Task DeleteHop(DeleteHopAction action, IDispatcher dispatcher)
    {
        try
        {
            await this.hopService.DeleteHop(action.Hop.Id);
            dispatcher.Dispatch(new SuccessMessageAction("Hop deleted successfully"));
            dispatcher.Dispatch(new GetHopsAction());
        }
        catch (Exception e)
        {
            dispatcher.Dispatch(new ErrorMessageAction(e));
        }

        return;
    }

    [EffectMethod]
    public async Task UpdateHop(UpdateHopAction action, IDispatcher dispatcher)
    {
        try
        {
            var fermentable = await this.hopService.UpdateHop(action.Hop);
            var inUse = await this.hopService.HopInUse(fermentable);
            dispatcher.Dispatch(new SuccessMessageAction("Hop updated successfully"));
            dispatcher.Dispatch(new GetHopResultAction(fermentable, inUse));
            dispatcher.Dispatch(new GetHopsAction());
        }
        catch (Exception e)
        {
            dispatcher.Dispatch(new ErrorMessageAction(e));
        }

        return;
    }
}