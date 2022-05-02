namespace BrewHelper.Web.Ingredients.Fermentables.Stores.Actions;

using System.Linq;
using BrewHelper.Data.Entities;

public record GetFermentablesResultAction(IQueryable<Fermentable>? Fermentables);