namespace BrewHelper.Web.Ingredients.Miscs.Stores.Miscs;

using System.Linq;
using BrewHelper.Data.Entities;
using Fluxor;

[FeatureState]
public class MiscsState
{
    public MiscsState(bool isLoading, IQueryable<Misc>? miscs)
    {
        this.IsLoading = isLoading;
        this.Miscs = miscs;
    }

    private MiscsState()
    {
        this.IsLoading = true;
        this.Miscs = null;
    }

    public bool IsLoading { get; }

    public IQueryable<Misc>? Miscs { get; }
}