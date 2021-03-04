﻿using BrewHelper.DTO;
using BrewHelper.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
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
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<GetIngredientListResponseDTO> GetByPageAsync(int limit, int page, string name, Ingredient.IngredientType[] types, CancellationToken cancellationToken)
        {
            var query = context.Ingredients.AsNoTracking();

            if (name != null)
                query = query.Where(i => i.Name.ToUpper().Contains(name.ToUpper()));

            if (types != null && types.Length > 0)
            {
                query = query.Where(i => types.Contains(i.Type));
            }
                

            var ingredients = await query.OrderBy(i => i.Name).PaginateAsync(page, limit, cancellationToken);

            return new GetIngredientListResponseDTO
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
        public virtual async Task<Ingredient> GetIngredientById(long id)
        {
            return await context.Ingredients.Where(r => r.Id == id).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Add a Ingredient
        /// </summary>
        /// <param name="Ingredient">The Ingredient to add</param>
        /// <returns>The Ingredient or null</returns>
        public virtual async Task<Ingredient> AddIngredient(Ingredient Ingredient)
        {
            if (Ingredient != null && !await context.Ingredients.Where(r => r.Name.Equals(Ingredient.Name)).AnyAsync())
            {
                await context.Ingredients.AddAsync(Ingredient);
                await context.SaveChangesAsync();
                return Ingredient;
            }

            return null;
        }

        /// <summary>
        /// Update a Ingredient
        /// </summary>
        /// <param name="Ingredient">The updated Ingredient</param>
        /// <returns>The updated Ingredient</returns>
        public virtual async Task<Ingredient> UpdateIngredient(long id, Ingredient Ingredient)
        {
            context.Entry(Ingredient).State = EntityState.Modified;

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
            return Ingredient;
        }

        /// <summary>
        /// Remove an Ingredient by id
        /// </summary>
        /// <param name="id">The id of the Ingredient to remove</param>
        /// <returns></returns>
        public virtual async Task<bool> DeleteIngredientById(long id)
        {
            var Ingredient = await context.Ingredients.FindAsync(id);
            if (Ingredient == null)
            {
                return false;
            }

            context.Ingredients.Remove(Ingredient);
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
