namespace BrewHelper.Web.Recipes.Stores.Actions
{
    using System.Linq;
    using BrewHelper.Data.Entities;

    public record GetRecipesResultAction(IQueryable<BrewHelperRecipe>? Recipes);
}