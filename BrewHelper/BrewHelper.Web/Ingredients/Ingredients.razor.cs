namespace BrewHelper.Web.Ingredients
{
    using BrewHelper.Web.Ingredients.Stores.Actions;
    using BrewHelper.Web.Ingredients.Stores.States;
    using Fluxor;
    using Microsoft.AspNetCore.Components;

    public partial class Ingredients
    {
        [Inject]
        private IState<IngredientsState> IngredientsState { get; set; } = default!;

        [Inject]
        private IDispatcher Dispatcher { get; set; } = default!;

        protected override void OnInitialized()
        {
            base.OnInitialized();

            this.Dispatcher.Dispatch(new GetIngredientsAction());
        }
    }
}