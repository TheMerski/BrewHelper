namespace BrewHelper.Web.Ingredients.Fermentable;

using Fluxor;
using Microsoft.AspNetCore.Components;

public partial class FermentableCreationForm
{
    [Inject]
    private IDispatcher Dispatcher { get; set; } = default!;
}