namespace BrewHelper.Web.Ingredients.Miscs.Stores.Misc;

using BrewHelper.Data.Entities;
using Fluxor;

[FeatureState]
public class MiscState
{
    public MiscState(bool isLoading, Misc? misc, bool? inUse)
    {
        this.IsLoading = isLoading;
        this.Misc = misc;
        this.InUse = inUse;
    }

    private MiscState()
    {
        this.IsLoading = true;
        this.Misc = null;
        this.InUse = null;
    }

    public bool IsLoading { get; }

    public Misc? Misc { get; }

    public bool? InUse { get; }
}