namespace BrewHelper.Web.Ingredients.Stores.Effects
{
    using System.Threading.Tasks;
    using BrewHelper.Business.Ingredient.Interfaces;
    using BrewHelper.Web.Ingredients.Stores.Actions;
    using Fluxor;

    public class IngredientsEffects
    {
        private readonly IIngredientService ingredientService;

        public IngredientsEffects(IIngredientService ingredientService)
        {
            this.ingredientService = ingredientService;
        }

        [EffectMethod]
        public Task GetIngredients(GetIngredientsAction action, IDispatcher dispatcher)
        {
            var ingredients = this.ingredientService.GetIngredients();

            dispatcher.Dispatch(new GetIngredientsResultAction(ingredients));

            return Task.CompletedTask;
        }
    }
}