namespace BrewHelper.Web.Ingredients
{
    using System.Linq;
    using System.Threading.Tasks;
    using BrewHelper.Data.Entities;
    using BrewHelper.Web.Ingredients.Stores.States;
    using Fluxor;
    using Microsoft.AspNetCore.Components;
    using MudBlazor;

    public partial class IngredientsTable
    {
        [Inject]
        private IState<IngredientsState> IngredientsState { get; set; } = default!;

        private MudTable<Ingredient> Table { get; set; } = default!;

        private async Task<TableData<Ingredient>> TableData(TableState state)
        {
            var ingredients = this.IngredientsState.Value.Ingredients;

            if (ingredients == null)
            {
                return await Task.FromResult(new TableData<Ingredient>
                {
                    TotalItems = 0,
                    Items = System.Array.Empty<Ingredient>(),
                });
            }

            ingredients = state.SortLabel switch
            {
                nameof(Ingredient.Name) =>
                    ingredients.OrderByDirection(state.SortDirection, i => i.Name),
                _ =>
                    ingredients,
            };

            var skip = state.Page * state.PageSize;
            var take = state.PageSize;

            return await Task.FromResult(new TableData<Ingredient>
            {
                TotalItems = ingredients.Count(),
                Items = ingredients.Skip(skip).Take(take).ToArray(),
            });
        }
    }
}