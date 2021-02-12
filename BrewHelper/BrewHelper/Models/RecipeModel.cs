using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrewHelper.Models
{
    public class RecipeModel
    {
        private RecipeContext context;

        public RecipeModel()
        {

        }

        public RecipeModel(RecipeContext injectedRecipeContext)
        {
            context = injectedRecipeContext;
        }

        /// <summary>
        /// Get all Recipes
        /// </summary>
        /// <returns>A list of all recipes</returns>
        public virtual async Task<List<Recipe>> GetAll()
        {
            return await context.Recipes.ToListAsync();
        }

        /// <summary>
        /// Get Recipe by Id 
        /// </summary>
        /// <param name="id">The id of the recipe to get</param>
        /// <returns>Recipe with id or default</returns>
        public virtual async Task<Recipe> GetRecipeById(long id)
        {
            return await context.Recipes.Where(r => r.Id == id).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Add a recipe
        /// </summary>
        /// <param name="recipe">The recipe to add</param>
        /// <returns>The recipe or null</returns>
        public virtual async Task<Recipe> AddRecipe(Recipe recipe)
        {
            if (recipe != null && !await context.Recipes.Where(r => r.Name.Equals(recipe.Name)).AnyAsync())
            {
                await context.Recipes.AddAsync(recipe);
                await context.SaveChangesAsync();
                return recipe;
            }

            return null;
        }

        /// <summary>
        /// Update a recipe
        /// </summary>
        /// <param name="recipe">The updated recipe</param>
        /// <returns>The updated Recipe</returns>
        public virtual async Task<Recipe> UpdateRecipe(long id, Recipe recipe)
        {
            context.Entry(recipe).State = EntityState.Modified;
   
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await RecipeExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
            return recipe;
        }

        /// <summary>
        /// Remove an recipe by id
        /// </summary>
        /// <param name="id">The id of the recipe to remove</param>
        /// <returns></returns>
        public virtual async Task<bool> DeleteRecipeById(long id)
        {
            var recipe = await context.Recipes.FindAsync(id);
            if (recipe == null)
            {
                return false;
            }

            context.Recipes.Remove(recipe);
            await context.SaveChangesAsync();

            return true;
        }


        /// <summary>
        /// Check if recipe exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private async Task<bool> RecipeExists(long id)
        {
            return await context.Recipes.AnyAsync(r => r.Id == id);
        }
    }
}
