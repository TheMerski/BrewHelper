using BrewHelper.DTO;
using BrewHelper.Entities;
using BrewHelper.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BrewHelper.Models
{
    public class RecipeModel
    {
        private BrewhelperContext context;

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
        /// Get Ingredients by page
        /// </summary>
        /// <returns>A page with Ingredients</returns>
        public async Task<GenericListResponseDTO<RecipeDTO>> GetByPageAsync(int limit, int page, string? name, long[]? ids, Ingredient.IngredientType[]? inStock, CancellationToken cancellationToken)
        {
            var query = context.Recipes.AsNoTracking();

            if (name != null)
                query = query.Where(r => r.Name.ToUpper().Contains(name.ToUpper()));

            if (ids != null && ids.Length > 0)
                query = query.Where(i => ids.Contains(i.Id));

            if (inStock != null)
                query = query.Where(r => r.Mashing != null && r.Mashing.Ingredients != null && r.Mashing.Ingredients.All(ri => ri.Weight <= ri.Ingredient.InStock || !inStock.Contains(ri.Ingredient.Type)))
                            .Where(r => r.Boiling != null && r.Boiling.Ingredients != null && r.Boiling.Ingredients.All(ri => ri.Weight <= ri.Ingredient.InStock || !inStock.Contains(ri.Ingredient.Type)))
                            .Where(r => r.Yeasting != null && r.Yeasting.Ingredients != null && r.Yeasting.Ingredients.All(ri => ri.Weight <= ri.Ingredient.InStock || !inStock.Contains(ri.Ingredient.Type)));

            var recipes = await query.OrderBy(i => i.Name).PaginateAsync(page, limit, cancellationToken);


            return new GenericListResponseDTO<RecipeDTO>
            {
                CurrentPage = recipes.CurrentPage,
                TotalItems = recipes.TotalItems,
                TotalPages = recipes.TotalPages,
                Items = recipes.Items.Select(r => new RecipeDTO(r)).ToList()
            };
        }

        /// <summary>
        /// Get Recipe by Id 
        /// </summary>
        /// <param name="id">The id of the recipe to get</param>
        /// <returns>Recipe with id or default</returns>
        public virtual async Task<RecipeDTO?> GetRecipeById(long id)
        {
            var recipe = await context.Recipes
                .Where(r => r.Id == id)
                .Include(r => r.Mashing)
                    .ThenInclude(s => s!.Ingredients)
                    .ThenInclude(i => i.Ingredient)
                .Include(r => r.Boiling)
                    .ThenInclude(s => s!.Ingredients)
                    .ThenInclude(i => i.Ingredient)
                .Include(r => r.Yeasting)
                    .ThenInclude(s => s!.Ingredients)
                    .ThenInclude(i => i.Ingredient)
                .AsNoTracking()
                .AsSplitQuery()
                .SingleOrDefaultAsync();

            if (recipe != null)
                return new RecipeDTO(recipe);
            return null;
        }

        

        /// <summary>
        /// Add a recipe
        /// </summary>
        /// <param name="recipeDTO">The recipe to add</param>
        /// <returns>The recipe or null</returns>
        public virtual async Task<Recipe?> AddRecipe(RecipeDTO? recipeDTO)
        {
            if (recipeDTO != null && !await context.Recipes.Where(r => r.Name.Equals(recipeDTO.Name)).AnyAsync())
            {
                Recipe recipe = new Recipe
                {
                    Mashing = new RecipeStep(),
                    Boiling = new RecipeStep(),
                    Yeasting = new RecipeStep()
                };
                SetDTOValues(recipeDTO, recipe);
                await context.Recipes.AddAsync(recipe);
                await context.SaveChangesAsync();
                return recipe;
            }

            return null;
        }

        /// <summary>
        /// Update a recipe
        /// </summary>
        /// <param name="id">Id of the recipe</param>
        /// <param name="recipeDto">The updated recipe</param>
        /// <returns>The updated Recipe</returns>
        public virtual async Task<RecipeDTO?> UpdateRecipe(long id, RecipeDTO recipeDto)
        {

            Recipe? recipe = context.Recipes
                .Where(r => r.Id == recipeDto.Id)
                .Include(r => r.Mashing)
                .ThenInclude(s => s!.Ingredients)
                .ThenInclude(i => i.Ingredient)
                .Include(r => r.Boiling)
                .ThenInclude(s => s!.Ingredients)
                .ThenInclude(i => i.Ingredient)
                .Include(r => r.Yeasting)
                .ThenInclude(s => s!.Ingredients)
                .ThenInclude(i => i.Ingredient)
                .AsSplitQuery()
                .AsNoTracking()
                .SingleOrDefault();

            if (recipe == null)
            {
                return null;
            }

            SetDTOValues(recipeDto, recipe);

            await context.SaveChangesAsync();
            return recipeDto;
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
        /// <param name="step">Recipe step to match ingredients for</param>
        /// <param name="dto">Step dto</param>
        private void MatchDTORecipeStepIngredients(Dictionary<long, Ingredient> ingredientsDict, RecipeStep? step, RecipeStepDTO dto)
        {
            if (step == null)
                return;
            
            if (step.Ingredients == null)
            {
                step.Ingredients = new List<RecipeIngredient>();
            }

            if (dto.Ingredients != null)
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

            if (dto.Mashing != null)
            {
                context.Entry(recipe.Mashing).CurrentValues.SetValues(dto.Mashing);
                MatchDTORecipeStepIngredients(ingredients, recipe.Mashing, dto.Mashing);
            }

            if (dto.Boiling != null)
            {
                context.Entry(recipe.Boiling).CurrentValues.SetValues(dto.Boiling);
                MatchDTORecipeStepIngredients(ingredients, recipe.Boiling, dto.Boiling);
            }

            if (dto.Yeasting != null)
            {
                context.Entry(recipe.Yeasting).CurrentValues.SetValues(dto.Yeasting);
                MatchDTORecipeStepIngredients(ingredients, recipe.Yeasting, dto.Yeasting);
            }
        }

        private Ingredient findIngredientById(Dictionary<long, Ingredient> ingredientsDict, long id)
        {
            if (!ingredientsDict.ContainsKey(id))
            {
                ingredientsDict[id] = context.Ingredients.Find(id);
            }
            return ingredientsDict[id];
        }

    }
}
