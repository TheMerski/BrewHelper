namespace BrewHelper.Web.Recipes
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using BrewHelper.Data.Entities;
    using BrewHelper.Web.Recipes.Stores.Actions;
    using BrewHelper.Web.Recipes.Stores.States;
    using Fluxor;
    using Microsoft.AspNetCore.Components;
    using MudBlazor;

    public partial class RecipesTable
    {
        [Inject]
        private IState<RecipesState> RecipesState { get; set; } = default!;

        [Inject]
        private IDispatcher Dispatcher { get; set; } = default!;

        private MudTable<BrewHelperRecipe> Table { get; set; } = default!;

        protected override void OnInitialized()
        {
            base.OnInitialized();

            if (!this.RecipesState.Value.IsLoading && this.RecipesState.Value == null)
            {
                this.ReloadData();
            }

            this.RecipesState.StateChanged += this.StateChanged;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            this.RecipesState.StateChanged -= this.StateChanged;
        }

        private void StateChanged(object? sender, EventArgs e)
        {
            if (!this.RecipesState.Value.IsLoading)
            {
                this.Table.ReloadServerData();
            }
        }

        private void ReloadData()
        {
            this.Dispatcher.Dispatch(new GetRecipesAction());
        }

        private async Task<TableData<BrewHelperRecipe>> TableData(TableState state)
        {
            var recipes = this.RecipesState.Value.Recipes;

            if (recipes == null)
            {
                return await Task.FromResult(new TableData<BrewHelperRecipe>
                {
                    TotalItems = 0,
                    Items = System.Array.Empty<BrewHelperRecipe>(),
                });
            }

            recipes = state.SortLabel switch
            {
                nameof(BrewHelperRecipe.Name) =>
                    recipes.OrderByDirection(state.SortDirection, i => i.Name),
                _ =>
                    recipes.OrderBy(i => i.Name),
            };

            var skip = state.Page * state.PageSize;
            var take = state.PageSize;

            return await Task.FromResult(new TableData<BrewHelperRecipe>
            {
                TotalItems = recipes.Count(),
                Items = recipes.Skip(skip).Take(take).ToArray(),
            });
        }
    }
}