namespace BrewHelper.Web.Ingredients.Hops.Stores.Hop.Actions;

using BrewHelper.Data.Entities;

public record GetHopResultAction(Hop Hop, bool InUse);