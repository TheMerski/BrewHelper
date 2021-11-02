namespace BrewHelper.Web.Ingredients.Stores.Features
{
    using BrewHelper.Web.Ingredients.Stores.States;
    using Fluxor;

    public class IngredientsFeature : Feature<IngredientsState>
    {
        public override string GetName() => nameof(IngredientsState);

        protected override IngredientsState GetInitialState() => new(false, null);
    }
}