using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrewHelper.Models
{
    public class RecipeModel
    {
        private BrewhelperContext context;

        public RecipeModel()
        {

        }

        public RecipeModel(BrewhelperContext injectedRecipeContext)
        {
            context = injectedRecipeContext;
        }

        /// <summary>
        /// Get all Recipes
        /// </summary>
        /// <returns>A list of all recipes</returns>
        public virtual async Task<List<RecipeDTO>> GetAll()
        {
            return await context.Recipes.Select(r => new RecipeDTO(r)).ToListAsync();
        }

        /// <summary>
        /// Get Recipe by Id 
        /// </summary>
        /// <param name="id">The id of the recipe to get</param>
        /// <returns>Recipe with id or default</returns>
        public virtual async Task<RecipeDTO> GetRecipeById(long id)
        {
            return await context.Recipes
                .Include(r => r.Mashing)
                    .ThenInclude(s => s.Ingredients)
                    .ThenInclude(i => i.Ingredient)
                .Include(r => r.Boiling)
                    .ThenInclude(s => s.Ingredients)
                    .ThenInclude(i => i.Ingredient)
                .Include(r => r.Yeasting)
                    .ThenInclude(s => s.Ingredients)
                    .ThenInclude(i => i.Ingredient)
                .Where(r => r.Id == id)
                .Select(r => new RecipeDTO(r))
                .FirstOrDefaultAsync();
        }

        /// <summary>
        /// Add a recipe
        /// </summary>
        /// <param name="recipeDTO">The recipe to add</param>
        /// <returns>The recipe or null</returns>
        public virtual async Task<RecipeDTO> AddRecipe(RecipeDTO recipeDTO)
        {
            if (recipeDTO != null && !await context.Recipes.Where(r => r.Name.Equals(recipeDTO.Name)).AnyAsync())
            {
                Recipe recipe = new Recipe();
                SetDTOValues(recipeDTO, recipe);
                await context.Recipes.AddAsync(recipe);
                await context.SaveChangesAsync();
                return recipeDTO;
            }

            return null;
        }

        /// <summary>
        /// Update a recipe
        /// </summary>
        /// <param name="recipeDTO">The updated recipe</param>
        /// <returns>The updated Recipe</returns>
        public virtual async Task<RecipeDTO> UpdateRecipe(long id, RecipeDTO recipeDTO)
        {

            Recipe recipe = context.Recipes
                .Include(r => r.Mashing)
                    .ThenInclude(s => s.Ingredients)
                    .ThenInclude(i => i.Ingredient)
                .Include(r => r.Boiling)
                    .ThenInclude(s => s.Ingredients)
                    .ThenInclude(i => i.Ingredient)
                .Include(r => r.Yeasting)
                    .ThenInclude(s => s.Ingredients)
                    .ThenInclude(i => i.Ingredient)
                .Where(r => r.Id == recipeDTO.Id)
                .FirstOrDefault();

            SetDTOValues(recipeDTO, recipe);

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
            return recipeDTO;
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

        /// <summary>
        /// Match ingredients to there database counterpart to prevent duplicates
        /// </summary>
        /// <param name="ingredientsDict">Dictionary to store ingredients</param>
        /// <param name="step">Recipe step to match ingrecdients for</param>
        private void MatchDTORecipeStepIngredients(Dictionary<long, Ingredient> ingredientsDict, RecipeStep step, RecipeStepDTO dto)
        {
            step.Ingredients = dto.Ingredients.Select(ri => new RecipeIngredient()
            {
                Id = ri.Id,
                AddAfter = ri.AddAfter,
                Ingredient = findIngredientById(ingredientsDict, ri.IngredientId),
                Weight = ri.Weight
            }).ToList();
        }

        private void SetDTOValues(RecipeDTO dto, Recipe recipe)
        {
            Dictionary<long, Ingredient> ingredients = new Dictionary<long, Ingredient>();

            context.Entry(recipe).CurrentValues.SetValues(dto);

            context.Entry(recipe.Mashing).CurrentValues.SetValues(dto.Mashing);
            MatchDTORecipeStepIngredients(ingredients, recipe.Mashing, dto.Mashing);
            //context.Entry(recipe.Mashing.Ingredients).CurrentValues.SetValues(dto.Mashing.Ingredients);

            context.Entry(recipe.Boiling).CurrentValues.SetValues(dto.Boiling);
            MatchDTORecipeStepIngredients(ingredients, recipe.Boiling, dto.Boiling);
            //context.Entry(recipe.Boiling.Ingredients).CurrentValues.SetValues(dto.Boiling.Ingredients);

            context.Entry(recipe.Yeasting).CurrentValues.SetValues(dto.Yeasting);
            MatchDTORecipeStepIngredients(ingredients, recipe.Yeasting, dto.Yeasting);
            //context.Entry(recipe.Yeasting.Ingredients).CurrentValues.SetValues(dto.Yeasting.Ingredients);
        }

        private Ingredient findIngredientById(Dictionary<long, Ingredient> ingredientsDict, long id) {
            if (!ingredientsDict.ContainsKey(id))
            {
                ingredientsDict[id] = context.Ingredients.Find(id);
            }
            return ingredientsDict[id];
        }

    }
}
