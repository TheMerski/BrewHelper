namespace BrewHelper.Web.Ingredients.Fermentables.Stores.Fermentables;

using System.Linq;
using BrewHelper.Data.Entities;
using Fluxor;

[FeatureState]
public class FermentablesState
{
    public FermentablesState(bool isLoading, IQueryable<Fermentable>? fermentables)
    {
        this.IsLoading = isLoading;
        this.Fermentables = fermentables;
    }

    private FermentablesState()
    {
        this.IsLoading = true;
        this.Fermentables = null;
    }

    public bool IsLoading { get; }

    public IQueryable<Fermentable>? Fermentables { get; }
}