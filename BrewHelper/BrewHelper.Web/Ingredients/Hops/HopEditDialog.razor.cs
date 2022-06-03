using System;
using System.Collections.Generic;
using System.Linq;
using BrewHelper.Data.Entities;
using BrewHelper.Web.Ingredients.Hops.Stores.Hop.Actions;
using Fluxor;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BrewHelper.Web.Ingredients.Hops;

public partial class HopEditDialog
{
    [Parameter]
    public long HopId { get; set; } = default!;

    [CascadingParameter]
    private MudDialogInstance MudDialog { get; set; } = default!;
}
