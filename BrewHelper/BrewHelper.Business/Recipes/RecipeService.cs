namespace BrewHelper.Business.Recipes;

using System;
using System.Linq;
using System.Threading.Tasks;
using BrewHelper.Business.Exceptions;
using BrewHelper.Data.Context;
using BrewHelper.Data.Entities;
using Microsoft.EntityFrameworkCore;
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
        return this.context.Recipes.AsSplitQuery().AsNoTracking().AsQueryable();
    }

    public async Task<Recipe> CreateRecipe(Recipe recipe)
    {
        if (await this.context.Recipes.AnyAsync((r) => r.Name == recipe.Name && r.Version == recipe.Version))
        {
            throw new NameAlreadyExistsException<Recipe>();
        }

        this.context.Add(recipe);
        await this.context.SaveChangesAsync();
        return recipe;
    }
}