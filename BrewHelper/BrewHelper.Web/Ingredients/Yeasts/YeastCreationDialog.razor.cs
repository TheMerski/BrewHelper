namespace BrewHelper.Web.Ingredients.Yeasts;

using BrewHelper.Data.Entities;
using BrewHelper.Web.Ingredients.Fermentables.Stores.Fermentable.Actions;
using BrewHelper.Web.Ingredients.Yeasts.Stores.Yeast.Actions;
using Fluxor;
using Microsoft.AspNetCore.Components;
using MudBlazor;

public partial class YeastCreationDialog
{
    [CascadingParameter]
    private MudDialogInstance MudDialog { get; set; } = default!;

    private Yeast Yeast { get; set; } = new Yeast();

    private MudForm Form { get; set; } = default!;

    [Inject]
    private IDispatcher Dispatcher { get; set; } = default!;

    private void Submit()
    {
        this.Dispatcher.Dispatch(new CreateYeastAction(this.Yeast));
        this.MudDialog.Close(DialogResult.Ok(true));
    }

    private void Cancel() => this.MudDialog.Cancel();
}
