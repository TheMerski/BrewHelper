namespace BrewHelper.Web.Recipes.Stores.Effects
{
    using System.Threading.Tasks;
    using BrewHelper.Web.Recipes.Stores.Actions;
    using Fluxor;

    public class RecipesEffect
    {
        public RecipesEffect()
        {
            //this.ingredientService = ingredientService;
        }

        [EffectMethod]
        public Task GetIngredients(GetRecipesAction action, IDispatcher dispatcher)
        {
            // var ingredients = this.ingredientService.GetIngredients();
            //
            // dispatcher.Dispatch(new GetRecipesResultAction(ingredients));
            return Task.CompletedTask;
        }
    }
}