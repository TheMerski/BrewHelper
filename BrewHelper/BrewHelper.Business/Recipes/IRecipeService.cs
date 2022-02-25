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
    public IQueryable<BrewHelperRecipe> GetRecipes();

    /// <summary>
    /// Create a recipe from an BeerXML string.
    /// </summary>
    /// <param name="recipeXml">BeerXML formatted recipe string.</param>
    /// <returns>The created recipe.</returns>
    public Task<BrewHelperRecipe> CreateRecipeFromXml(string recipeXml);
}