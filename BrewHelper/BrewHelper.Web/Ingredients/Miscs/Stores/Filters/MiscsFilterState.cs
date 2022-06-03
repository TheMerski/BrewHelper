namespace BrewHelper.Web.Ingredients.Miscs.Stores.Filters;

using Fluxor;

[FeatureState]
public class MiscsFilterState
{
    public MiscsFilterState(MiscsFilters filter)
    {
        this.Filters = filter;
    }

    public MiscsFilterState()
    {
        this.Filters = new();
    }

    public MiscsFilters Filters { get; }
}