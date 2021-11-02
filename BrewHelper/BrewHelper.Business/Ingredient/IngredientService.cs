namespace BrewHelper.Business.Ingredient
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using BrewHelper.Business.Exceptions;
    using BrewHelper.Business.Ingredient.Interfaces;
    using BrewHelper.Data.Context;
    using BrewHelper.Data.Entities;
    using Microsoft.EntityFrameworkCore;

    public class IngredientService : IIngredientService
    {
        private readonly BrewhelperContext context;

        public IngredientService(BrewhelperContext context)
        {
            this.context = context;
        }

        public IQueryable<Ingredient> GetIngredients()
        {
            return this.context.Ingredients.AsQueryable();
        }

        public async Task<long> CreateIngredientAsync(Ingredient ingredient)
        {
            if (!await this.context.Ingredients.Where(r => r.Name.Equals(ingredient.Name)).AnyAsync())
            {
                await this.context.Ingredients.AddAsync(ingredient);
                await this.context.SaveChangesAsync();
                return ingredient.Id;
            }

            throw new NameAlreadyExistsException<Ingredient>();
        }

        public async Task<Ingredient> GetIngredientAsync(long id)
        {
            var ingredient = await this.context.Ingredients.Where(r => r.Id == id).FirstOrDefaultAsync();
            return ingredient ?? throw new NotFoundException<Ingredient>();
        }
    }
}