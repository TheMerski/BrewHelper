namespace BrewHelper.Web.Ingredients.Miscs.Stores.Misc;

using System;
using System.Threading.Tasks;
using BrewHelper.Business.Miscs;
using BrewHelper.Web.Ingredients.Miscs.Stores.Misc.Actions;
using BrewHelper.Web.Ingredients.Miscs.Stores.Miscs.Actions;
using BrewHelper.Web.Shared.Snackbar.Stores.Actions;
using Fluxor;

public class MiscEffect
{
    private readonly IMiscService miscService;

    public MiscEffect(IMiscService miscService)
    {
        this.miscService = miscService;
    }

    [EffectMethod]
    public async Task GetMisc(GetMiscAction action, IDispatcher dispatcher)
    {
        try
        {
            var misc = await this.miscService.GetMisc(action.Id);
            var inUse = await this.miscService.MiscInUse(misc);

            dispatcher.Dispatch(new GetMiscResultAction(misc, inUse));
        }
        catch (Exception e)
        {
            dispatcher.Dispatch(new ErrorMessageAction(e));
        }

        return;
    }

    [EffectMethod]
    public async Task CreateMisc(CreateMiscAction action, IDispatcher dispatcher)
    {
        try
        {
            await this.miscService.CreateMisc(action.Misc);
            dispatcher.Dispatch(new SuccessMessageAction("Misc created successfully"));
            dispatcher.Dispatch(new GetMiscsAction());
        }
        catch (Exception e)
        {
            dispatcher.Dispatch(new ErrorMessageAction(e));
        }

        return;
    }

    [EffectMethod]
    public async Task CreateMiscVersion(CreateMiscVersionAction action, IDispatcher dispatcher)
    {
        try
        {
            await this.miscService.CreateMiscVersion(action.MiscToCopy);
            dispatcher.Dispatch(new SuccessMessageAction("Misc copied successfully"));
            dispatcher.Dispatch(new GetMiscsAction());
        }
        catch (Exception e)
        {
            dispatcher.Dispatch(new ErrorMessageAction(e));
        }

        return;
    }

    [EffectMethod]
    public async Task DeleteMisc(DeleteMiscAction action, IDispatcher dispatcher)
    {
        try
        {
            await this.miscService.DeleteMisc(action.Misc.Id);
            dispatcher.Dispatch(new SuccessMessageAction("Misc deleted successfully"));
            dispatcher.Dispatch(new GetMiscsAction());
        }
        catch (Exception e)
        {
            dispatcher.Dispatch(new ErrorMessageAction(e));
        }

        return;
    }

    [EffectMethod]
    public async Task UpdateMisc(UpdateMiscAction action, IDispatcher dispatcher)
    {
        try
        {
            var fermentable = await this.miscService.UpdateMisc(action.Misc);
            var inUse = await this.miscService.MiscInUse(fermentable);
            dispatcher.Dispatch(new SuccessMessageAction("Misc updated successfully"));
            dispatcher.Dispatch(new GetMiscResultAction(fermentable, inUse));
            dispatcher.Dispatch(new GetMiscsAction());
        }
        catch (Exception e)
        {
            dispatcher.Dispatch(new ErrorMessageAction(e));
        }

        return;
    }
}