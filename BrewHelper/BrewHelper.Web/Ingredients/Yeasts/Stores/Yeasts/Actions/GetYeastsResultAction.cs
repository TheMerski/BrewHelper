namespace BrewHelper.Web.Ingredients.Yeasts.Stores.Yeasts.Actions;

using System.Linq;
using BrewHelper.Data.Entities;

public record GetYeastsResultAction(IQueryable<Yeast>? Yeasts);