namespace BrewHelper.Web.Ingredients.Fermentables.Stores.Fermentable.Actions;
using BrewHelper.Data.Entities;

public record GetFermentableResultAction(Fermentable Fermentable, bool InUse);