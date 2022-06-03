namespace BrewHelper.Web.Ingredients.Yeasts.Stores.Yeast;

using System;
using System.Threading.Tasks;
using BrewHelper.Business.Yeasts;
using BrewHelper.Web.Ingredients.Yeasts.Stores.Yeast.Actions;
using BrewHelper.Web.Ingredients.Yeasts.Stores.Yeasts.Actions;
using BrewHelper.Web.Shared.Snackbar.Stores.Actions;
using Fluxor;

public class YeastEffect
{
    private readonly IYeastService yeastService;

    public YeastEffect(IYeastService yeastService)
    {
        this.yeastService = yeastService;
    }

    [EffectMethod]
    public async Task GetYeast(GetYeastAction action, IDispatcher dispatcher)
    {
        try
        {
            var yeast = await this.yeastService.GetYeast(action.Id);
            var inUse = await this.yeastService.YeastInUse(yeast);

            dispatcher.Dispatch(new GetYeastResultAction(yeast, inUse));
        }
        catch (Exception e)
        {
            dispatcher.Dispatch(new ErrorMessageAction(e));
        }

        return;
    }

    [EffectMethod]
    public async Task CreateYeast(CreateYeastAction action, IDispatcher dispatcher)
    {
        try
        {
            await this.yeastService.CreateYeast(action.Yeast);
            dispatcher.Dispatch(new SuccessMessageAction("Yeast created successfully"));
            dispatcher.Dispatch(new GetYeastsAction());
        }
        catch (Exception e)
        {
            dispatcher.Dispatch(new ErrorMessageAction(e));
        }

        return;
    }

    [EffectMethod]
    public async Task CreateYeastVersion(CreateYeastVersionAction action, IDispatcher dispatcher)
    {
        try
        {
            await this.yeastService.CreateYeastVersion(action.YeastToCopy);
            dispatcher.Dispatch(new SuccessMessageAction("Yeast copied successfully"));
            dispatcher.Dispatch(new GetYeastsAction());
        }
        catch (Exception e)
        {
            dispatcher.Dispatch(new ErrorMessageAction(e));
        }

        return;
    }

    [EffectMethod]
    public async Task DeleteYeast(DeleteYeastAction action, IDispatcher dispatcher)
    {
        try
        {
            await this.yeastService.DeleteYeast(action.Yeast.Id);
            dispatcher.Dispatch(new SuccessMessageAction("Yeast deleted successfully"));
            dispatcher.Dispatch(new GetYeastsAction());
        }
        catch (Exception e)
        {
            dispatcher.Dispatch(new ErrorMessageAction(e));
        }

        return;
    }

    [EffectMethod]
    public async Task UpdateYeast(UpdateYeastAction action, IDispatcher dispatcher)
    {
        try
        {
            var fermentable = await this.yeastService.UpdateYeast(action.Yeast);
            var inUse = await this.yeastService.YeastInUse(fermentable);
            dispatcher.Dispatch(new SuccessMessageAction("Yeast updated successfully"));
            dispatcher.Dispatch(new GetYeastResultAction(fermentable, inUse));
            dispatcher.Dispatch(new GetYeastsAction());
        }
        catch (Exception e)
        {
            dispatcher.Dispatch(new ErrorMessageAction(e));
        }

        return;
    }
}