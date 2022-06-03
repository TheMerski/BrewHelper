namespace BrewHelper.Web.Ingredients.Yeasts.Stores.Yeast;

using BrewHelper.Data.Entities;
using Fluxor;

[FeatureState]
public class YeastState
{
    public YeastState(bool isLoading, Yeast? yeast, bool? inUse)
    {
        this.IsLoading = isLoading;
        this.Yeast = yeast;
        this.InUse = inUse;
    }

    private YeastState()
    {
        this.IsLoading = true;
        this.Yeast = null;
        this.InUse = null;
    }

    public bool IsLoading { get; }

    public Yeast? Yeast { get; }

    public bool? InUse { get; }
}