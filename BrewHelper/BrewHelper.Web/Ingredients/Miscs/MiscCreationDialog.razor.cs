namespace BrewHelper.Web.Ingredients.Miscs;

using BrewHelper.Data.Entities;
using BrewHelper.Web.Ingredients.Fermentables.Stores.Fermentable.Actions;
using BrewHelper.Web.Ingredients.Miscs.Stores.Misc.Actions;
using Fluxor;
using Microsoft.AspNetCore.Components;
using MudBlazor;

public partial class MiscCreationDialog
{
    [CascadingParameter]
    private MudDialogInstance MudDialog { get; set; } = default!;

    private Misc Misc { get; set; } = new Misc();

    private MudForm Form { get; set; } = default!;

    [Inject]
    private IDispatcher Dispatcher { get; set; } = default!;

    private void Submit()
    {
        this.Dispatcher.Dispatch(new CreateMiscAction(this.Misc));
        this.MudDialog.Close(DialogResult.Ok(true));
    }

    private void Cancel() => this.MudDialog.Cancel();
}
