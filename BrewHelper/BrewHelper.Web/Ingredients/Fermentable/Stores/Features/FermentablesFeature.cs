namespace BrewHelper.Web.Ingredients.Fermentable.Stores.Features;

using BrewHelper.Web.Ingredients.Fermentable.Stores.States;
using Fluxor;

public class FermentablesFeature : Feature<FermentablesState>
{
    public override string GetName() => nameof(FermentablesState);

    protected override FermentablesState GetInitialState() => new(false, null);
}