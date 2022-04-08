namespace BrewHelper.Web.Ingredients.Fermentable.Stores.Actions;

using System.Linq;
using BrewHelper.Data.Entities;

public record GetFermentablesResultAction(IQueryable<Fermentable>? Fermentables);