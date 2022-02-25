namespace BrewHelper.Business.Recipes;

using System.Linq;
using System.Threading.Tasks;
using BeerXMLSharp;
using BrewHelper.Data.Context;
using BrewHelper.Data.Entities;
using Microsoft.Extensions.Logging;

public class RecipeService : IRecipeService
{
    private readonly ILogger<RecipeService> logger;
    private readonly BrewhelperContext context;

    public RecipeService(ILogger<RecipeService> logger, BrewhelperContext context)
    {
        this.logger = logger;
        this.context = context;
    }

    public IQueryable<BrewHelperRecipe> GetRecipes()
    {
        return this.context.Recipes.AsQueryable();
    }

    public async Task<BrewHelperRecipe> CreateRecipeFromXml(string recipeXml)
    {
        BeerXML.StrictModeEnabled = false;
        BrewHelperRecipe recipe = new BrewHelperRecipe(recipeXml);
        await this.context.Recipes.AddAsync(recipe);
        return recipe;
    }
}