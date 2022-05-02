namespace BrewHelper.Web.Ingredients.Fermentables.Stores.Features;

using BrewHelper.Web.Ingredients.Fermentables.Stores.States;
using Fluxor;

public class FermentablesFeature : Feature<FermentablesState>
{
    public override string GetName() => nameof(FermentablesState);

    protected override FermentablesState GetInitialState() => new(false, null);
}