namespace BrewHelper.Business.Recipes;

using System.Linq;
using System.Threading.Tasks;
using BrewHelper.Data.Entities;

public interface IRecipeService
{
    /// <summary>
    /// Get a list of recipes.
    /// </summary>
    /// <returns>An IQueryable with recipes.</returns>
    public IQueryable<Recipe> GetRecipes();

    /// <summary>
    /// Create a recipe.
    /// </summary>
    /// <param name="recipe">The recipe to create.</param>
    /// <returns>The created recipe.</returns>
    public Task<Recipe> CreateRecipe(Recipe recipe);
}