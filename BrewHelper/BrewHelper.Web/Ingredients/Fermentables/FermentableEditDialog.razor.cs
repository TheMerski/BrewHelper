using System;
using System.Collections.Generic;
using System.Linq;
using BrewHelper.Data.Entities;
using BrewHelper.Web.Ingredients.Fermentables.Stores.Fermentable.Actions;
using Fluxor;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BrewHelper.Web.Ingredients.Fermentables;

public partial class FermentableEditDialog
{
    [Parameter]
    public long FermentableId { get; set; } = default!;

    [CascadingParameter]
    private MudDialogInstance MudDialog { get; set; } = default!;
}
