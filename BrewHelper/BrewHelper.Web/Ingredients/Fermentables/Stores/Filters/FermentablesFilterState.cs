namespace BrewHelper.Web.Ingredients.Fermentables.Stores.Filters;

using System.Linq;
using BrewHelper.Data.Entities;
using Fluxor;

[FeatureState]
public class FermentablesFilterState
{
    public FermentablesFilterState(FermentablesFilters filter)
    {
        this.Filters = filter;
    }

    public FermentablesFilterState()
    {
        this.Filters = new();
    }

    public FermentablesFilters Filters { get; }
}