using System;
using System.Collections.Generic;
using System.Linq;
using BrewHelper.Data.Entities;
using BrewHelper.Web.Ingredients.Yeasts.Stores.Yeast.Actions;
using Fluxor;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BrewHelper.Web.Ingredients.Yeasts;

public partial class YeastEditDialog
{
    [Parameter]
    public long YeastId { get; set; } = default!;

    [CascadingParameter]
    private MudDialogInstance MudDialog { get; set; } = default!;
}
