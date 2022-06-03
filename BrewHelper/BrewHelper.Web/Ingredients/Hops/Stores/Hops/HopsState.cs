namespace BrewHelper.Web.Ingredients.Hops.Stores.Hops;

using System.Linq;
using BrewHelper.Data.Entities;
using Fluxor;

[FeatureState]
public class HopsState
{
    public HopsState(bool isLoading, IQueryable<Hop>? hops)
    {
        this.IsLoading = isLoading;
        this.Hops = hops;
    }

    private HopsState()
    {
        this.IsLoading = true;
        this.Hops = null;
    }

    public bool IsLoading { get; }

    public IQueryable<Hop>? Hops { get; }
}