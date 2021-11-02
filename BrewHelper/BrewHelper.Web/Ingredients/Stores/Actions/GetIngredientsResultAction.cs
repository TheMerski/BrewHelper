namespace BrewHelper.Web.Ingredients.Stores.Actions
{
    using System.Linq;
    using BrewHelper.Data.Entities;

    public record GetIngredientsResultAction(IQueryable<Ingredient>? Ingredients);
}