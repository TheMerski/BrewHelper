namespace BrewHelper.Business.Recipes;

using System;
using System.Linq;
using System.Threading.Tasks;
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

    public IQueryable<Recipe> GetRecipes()
    {
        return this.context.Recipes.AsQueryable();
    }

    public Task<Recipe> CreateRecipeFromXml(string recipeXml)
    {
        throw new NotImplementedException();
    }
}