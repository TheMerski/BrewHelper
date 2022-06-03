namespace BrewHelper.Web.Ingredients.Hops.Stores.Hops.Actions;

using BrewHelper.Web.Ingredients.Hops.Stores.Filters;

public record GetHopsAction(HopsFilters? Filters = null);