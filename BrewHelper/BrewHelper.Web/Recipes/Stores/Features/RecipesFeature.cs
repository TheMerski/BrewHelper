namespace BrewHelper.Web.Recipes.Stores.Features
{
    using BrewHelper.Web.Recipes.Stores.States;
    using Fluxor;

    public class RecipesFeature : Feature<RecipesState>
    {
        public override string GetName() => nameof(RecipesState);

        protected override RecipesState GetInitialState() => new(false, null);
    }
}