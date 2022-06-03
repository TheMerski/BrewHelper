namespace BrewHelper.Web.Ingredients.Yeasts.Stores.Filters;

using Fluxor;

[FeatureState]
public class YeastsFilterState
{
    public YeastsFilterState(YeastsFilters filter)
    {
        this.Filters = filter;
    }

    public YeastsFilterState()
    {
        this.Filters = new();
    }

    public YeastsFilters Filters { get; }
}