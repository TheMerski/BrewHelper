namespace BrewHelper.Web.Recipes.Stores.States
{
    using System.Linq;
    using BrewHelper.Data.Entities;

    public record RecipesState(bool IsLoading, IQueryable<BrewHelperRecipe>? Recipes);
}