namespace BrewHelper.Web.Ingredients.Miscs.Stores.Miscs.Actions;

using BrewHelper.Web.Ingredients.Miscs.Stores.Filters;

public record GetMiscsAction(MiscsFilters? Filters = null);