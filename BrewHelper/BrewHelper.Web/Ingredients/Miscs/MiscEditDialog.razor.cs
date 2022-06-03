using System;
using System.Collections.Generic;
using System.Linq;
using BrewHelper.Data.Entities;
using BrewHelper.Web.Ingredients.Miscs.Stores.Misc.Actions;
using Fluxor;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BrewHelper.Web.Ingredients.Miscs;

public partial class MiscEditDialog
{
    [Parameter]
    public long MiscId { get; set; } = default!;

    [CascadingParameter]
    private MudDialogInstance MudDialog { get; set; } = default!;
}
