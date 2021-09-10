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
    public class IngredientModel
    {
        private readonly BrewhelperContext context;

        public IngredientModel(BrewhelperContext injectedIngredientContext)
        {
            context = injectedIngredientContext;
        }

        /// <summary>
        /// Get all Ingredients
        /// </summary>
        /// <returns>A list of all Ingredients</returns>
        public virtual async Task<List<Ingredient>> GetAll()
        {
            return await context.Ingredients.ToListAsync();
        }

        /// <summary>
        /// Get a page with ingredients
        /// </summary>
        /// <param name="limit">Page limit</param>
        /// <param name="page">Page number</param>
        /// <param name="name">name search</param>
        /// <param name="ids">array of id's the Ingredient should be in</param>
        /// <param name="types">The types the Ingredient should be in</param>
        /// <param name="inStock">Wether the ingredient is in stock</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<GenericListResponseDTO<Ingredient>> GetByPageAsync(int limit, int page, string? name, long[]? ids, Ingredient.IngredientType[]? types, bool? inStock, CancellationToken cancellationToken)
        {
            var query = context.Ingredients.AsNoTracking();

            if (name != null)
                query = query.Where(i => i.Name.ToUpper().Contains(name.ToUpper()));

            if (ids != null && ids.Length > 0)
                query = query.Where(i => ids.Contains(i.Id));

            if (inStock != null)
                query = query.Where(i => i.InStock > 0 == inStock);

            if (types != null && types.Length > 0)
            {
                query = query.Where(i => types.Contains(i.Type));
            }
                
            var ingredients = await query.OrderBy(i => i.Name).PaginateAsync(page, limit, cancellationToken);

            return new GenericListResponseDTO<Ingredient>
            {
                CurrentPage = ingredients.CurrentPage,
                TotalItems = ingredients.TotalItems,
                TotalPages = ingredients.TotalPages,
                Items = ingredients.Items
            };
        }

        /// <summary>
        /// Get Ingredient by Id 
        /// </summary>
        /// <param name="id">The id of the Ingredient to get</param>
        /// <returns>Ingredient with id or default</returns>
        public virtual async Task<Ingredient?> GetIngredientById(long id)
        {
            return await context.Ingredients.Where(r => r.Id == id).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Add a Ingredient
        /// </summary>
        /// <param name="ingredient">The Ingredient to add</param>
        /// <returns>The Ingredient or null</returns>
        public virtual async Task<Ingredient?> AddIngredient(Ingredient? ingredient)
        {
            if (ingredient != null && !await context.Ingredients.Where(r => r.Name.Equals(ingredient.Name)).AnyAsync())
            {
                await context.Ingredients.AddAsync(ingredient);
                await context.SaveChangesAsync();
                return ingredient;
            }

            return null;
        }

        /// <summary>
        /// Update a Ingredient
        /// </summary>
        /// <param name="id">Ingredient id</param>
        /// <param name="ingredient">The updated Ingredient</param>
        /// <returns>The updated Ingredient</returns>
        public virtual async Task<Ingredient?> UpdateIngredient(long id, Ingredient ingredient)
        {
            context.Entry(ingredient).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await IngredientExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
            return ingredient;
        }

        /// <summary>
        /// Remove an Ingredient by id
        /// </summary>
        /// <param name="id">The id of the Ingredient to remove</param>
        /// <returns></returns>
        public virtual async Task<bool> DeleteIngredientById(long id)
        {
            var ingredient = await context.Ingredients.FindAsync(id);
            if (ingredient == null)
            {
                return false;
            }

            context.Ingredients.Remove(ingredient);
            await context.SaveChangesAsync();

            return true;
        }


        /// <summary>
        /// Check if Ingredient exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private async Task<bool> IngredientExists(long id)
        {
            return await context.Ingredients.AnyAsync(r => r.Id == id);
        }
    }
}
