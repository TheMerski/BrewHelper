namespace BrewHelper.Web.Ingredients.Miscs.Stores.Misc.Actions;

using BrewHelper.Data.Entities;

public record GetMiscResultAction(Misc Misc, bool InUse);