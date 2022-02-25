namespace BrewHelper.Web.Recipes
{
    using System.Threading.Tasks;
    using BrewHelper.Business.Recipes;
    using BrewHelper.Web.Recipes.Stores.Actions;
    using BrewHelper.Web.Recipes.Stores.States;
    using Fluxor;
    using Microsoft.AspNetCore.Components;
    using MudBlazor;

    public partial class Recipes
    {
        [Inject]
        private IState<RecipesState> RecipesState { get; set; } = default!;

        [Inject]
        private IDispatcher Dispatcher { get; set; } = default!;

        [Inject]
        private IRecipeService RecipeService { get; set; } = default!;

        private MudTextField<string> TextField { get; set; } = default!;

        protected override void OnInitialized()
        {
            base.OnInitialized();

            this.Dispatcher.Dispatch(new GetRecipesAction());
        }

        private async Task AddRecipe()
        {
            await this.RecipeService.CreateRecipeFromXml(this.TextField.Value);
        }
    }
}