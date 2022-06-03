namespace BrewHelper.Web.Ingredients.Hops.Stores.Hop;

using BrewHelper.Data.Entities;
using Fluxor;

[FeatureState]
public class HopState
{
    public HopState(bool isLoading, Hop? hop, bool? inUse)
    {
        this.IsLoading = isLoading;
        this.Hop = hop;
        this.InUse = inUse;
    }

    private HopState()
    {
        this.IsLoading = true;
        this.Hop = null;
        this.InUse = null;
    }

    public bool IsLoading { get; }

    public Hop? Hop { get; }

    public bool? InUse { get; }
}