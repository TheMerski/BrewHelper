namespace BrewHelper.Web.Ingredients.Yeasts.Stores.Yeasts.Actions;

using BrewHelper.Web.Ingredients.Yeasts.Stores.Filters;

public record GetYeastsAction(YeastsFilters? Filters = null);