namespace BrewHelper.Web.Ingredients.Hops.Stores.Hops.Actions;

using System.Linq;
using BrewHelper.Data.Entities;

public record GetHopsResultAction(IQueryable<Hop>? Hops);