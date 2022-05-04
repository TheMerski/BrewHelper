namespace BrewHelper.Web.Ingredients.Fermentables.Stores.Fermentable;

using System.Linq;
using BrewHelper.Data.Entities;
using Fluxor;

[FeatureState]
public class FermentableState
{
    public FermentableState(bool isLoading, Fermentable? fermentable, bool? inUse)
    {
        this.IsLoading = isLoading;
        this.Fermentable = fermentable;
        this.InUse = inUse;
    }

    private FermentableState()
    {
        this.IsLoading = true;
        this.Fermentable = null;
        this.InUse = null;
    }

    public bool IsLoading { get; }

    public Fermentable? Fermentable { get; }

    public bool? InUse { get; }
}