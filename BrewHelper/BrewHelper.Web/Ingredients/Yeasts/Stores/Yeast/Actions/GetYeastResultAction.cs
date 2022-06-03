namespace BrewHelper.Web.Ingredients.Yeasts.Stores.Yeast.Actions;

using BrewHelper.Data.Entities;

public record GetYeastResultAction(Yeast Yeast, bool InUse);