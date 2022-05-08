using System;
using System.Collections.Generic;
using System.Linq;
using BrewHelper.Data.Entities;
using BrewHelper.Web.Ingredients.Fermentables.Stores.Fermentable.Actions;
using Fluxor;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BrewHelper.Web.Ingredients.Fermentables;

public partial class FermentableCreationDialog
{
    [CascadingParameter]
    private MudDialogInstance MudDialog { get; set; } = default!;

    private Fermentable Fermentable { get; set; } = new Fermentable();

    private MudForm Form { get; set; } = default!;

    [Inject]
    private IDispatcher Dispatcher { get; set; } = default!;

    private void Submit()
    {
        this.Dispatcher.Dispatch(new CreateFermentableAction(this.Fermentable));
        this.MudDialog.Close(DialogResult.Ok(true));
    }

    private void Cancel() => this.MudDialog.Cancel();
}
