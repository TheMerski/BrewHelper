namespace BrewHelper.Web.Ingredients.Miscs.Stores.Miscs.Actions;

using System.Linq;
using BrewHelper.Data.Entities;

public record GetMiscsResultAction(IQueryable<Misc>? Miscs);