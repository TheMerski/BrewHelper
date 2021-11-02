namespace BrewHelper.Business.Ingredient.Interfaces
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using BrewHelper.Data.Entities;

    public interface IIngredientService
    {
        /// <summary>
        /// Get a queryable list of ingredients.
        /// </summary>
        public IQueryable<Ingredient> GetIngredients();

        /// <summary>
        /// Create a new Ingredient.
        /// </summary>
        /// <param name="ingredient">The ingredient to create.</param>
        /// <returns>The Id of the created Ingredient.</returns>
        public Task<long> CreateIngredientAsync(Ingredient ingredient);

        /// <summary>
        /// Get a single Ingredient by Id.
        /// </summary>
        /// <param name="id">Id of the Ingredient to get.</param>
        /// <returns>The Ingredient corresponding to the Id.</returns>
        public Task<Ingredient> GetIngredientAsync(long id);
    }
}