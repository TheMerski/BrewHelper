namespace BrewHelper.Web.Ingredients.Yeasts.Stores.Yeasts;

using System.Linq;
using BrewHelper.Data.Entities;
using Fluxor;

[FeatureState]
public class YeastsState
{
    public YeastsState(bool isLoading, IQueryable<Yeast>? yeasts)
    {
        this.IsLoading = isLoading;
        this.Yeasts = yeasts;
    }

    private YeastsState()
    {
        this.IsLoading = true;
        this.Yeasts = null;
    }

    public bool IsLoading { get; }

    public IQueryable<Yeast>? Yeasts { get; }
}