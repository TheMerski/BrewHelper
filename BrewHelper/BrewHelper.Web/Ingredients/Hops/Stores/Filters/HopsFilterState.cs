namespace BrewHelper.Web.Ingredients.Hops.Stores.Filters;

using Fluxor;

[FeatureState]
public class HopsFilterState
{
    public HopsFilterState(HopsFilters filter)
    {
        this.Filters = filter;
    }

    public HopsFilterState()
    {
        this.Filters = new();
    }

    public HopsFilters Filters { get; }
}