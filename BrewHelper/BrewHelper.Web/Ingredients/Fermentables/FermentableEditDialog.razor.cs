using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BrewHelper.Web.Ingredients.Fermentables;

public partial class FermentableEditDialog
{
    [CascadingParameter]
    private MudDialogInstance MudDialog { get; set; } = default!;

    private FermentableEditForm? Form { get; set; }

    private void Submit()
    {
        this.Form?.Save();
        this.MudDialog.Close(DialogResult.Ok(true));
    }

    private void Cancel() => this.MudDialog.Cancel();
}
