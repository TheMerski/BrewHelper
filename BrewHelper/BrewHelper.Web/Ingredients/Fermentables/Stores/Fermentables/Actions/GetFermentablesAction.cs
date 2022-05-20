using BrewHelper.Web.Ingredients.Fermentables.Stores.Filters;

namespace BrewHelper.Web.Ingredients.Fermentables.Stores.Fermentables.Actions;

public record GetFermentablesAction(FermentablesFilters? Filters = null);