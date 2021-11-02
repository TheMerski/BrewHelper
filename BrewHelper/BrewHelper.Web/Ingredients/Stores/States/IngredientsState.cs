namespace BrewHelper.Web.Ingredients.Stores.States
{
    using System.Linq;
    using BrewHelper.Data.Entities;

    public record IngredientsState(bool IsLoading, IQueryable<Ingredient>? Ingredients);
}