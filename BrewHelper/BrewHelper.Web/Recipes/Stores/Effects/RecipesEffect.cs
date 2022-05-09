namespace BrewHelper.Web.Recipes.Stores.Effects
{
    using System.Threading.Tasks;
    using BrewHelper.Business.Recipes;
    using BrewHelper.Web.Recipes.Stores.Actions;
    using Fluxor;

    public class RecipesEffect
    {
        private readonly IRecipeService recipeService;

        public RecipesEffect(IRecipeService recipeService)
        {
            this.recipeService = recipeService;
        }

        [EffectMethod]
        public Task GetRecipes(GetRecipesAction action, IDispatcher dispatcher)
        {
            var recipes = this.recipeService.GetRecipes();

            dispatcher.Dispatch(new GetRecipesResultAction(recipes));

            return Task.CompletedTask;
        }
    }
}