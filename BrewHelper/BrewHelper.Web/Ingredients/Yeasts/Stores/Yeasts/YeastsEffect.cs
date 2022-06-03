namespace BrewHelper.Web.Ingredients.Yeasts.Stores.Yeasts;

using System.Linq;
using System.Threading.Tasks;
using BrewHelper.Business.Yeasts;
using BrewHelper.Web.Ingredients.Fermentables.Stores.Fermentables.Actions;
using BrewHelper.Web.Ingredients.Yeasts.Stores.Yeasts.Actions;
using Fluxor;

public class YeastsEffect
{
    private readonly IYeastService yeastService;

    public YeastsEffect(IYeastService yeastService)
    {
        this.yeastService = yeastService;
    }

    [EffectMethod]
    public Task GetYeasts(GetYeastsAction action, IDispatcher dispatcher)
    {
        var yeasts = this.yeastService.GetYeasts();

        if (action.Filters != null)
        {
            if (action.Filters.Query != null && !string.IsNullOrWhiteSpace(action.Filters.Query))
            {
                yeasts = yeasts.Where((e) => e.Name.Contains(action.Filters.Query.Trim()));
            }
        }

        dispatcher.Dispatch(new GetYeastsResultAction(yeasts));

        return Task.CompletedTask;
    }
}