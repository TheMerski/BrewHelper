namespace BrewHelper.Web.Recipes
{
    using BrewHelper.Web.Recipes.Stores.Actions;
    using BrewHelper.Web.Recipes.Stores.States;
    using Fluxor;
    using Microsoft.AspNetCore.Components;

    public partial class Recipes
    {
        [Inject]
        private IState<RecipesState> RecipesState { get; set; } = default!;

        [Inject]
        private IDispatcher Dispatcher { get; set; } = default!;

        protected override void OnInitialized()
        {
            base.OnInitialized();

            this.Dispatcher.Dispatch(new GetRecipesAction());
        }
    }
}