namespace BrewHelper.Web.Ingredients.Fermentables;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BrewHelper.Data.Entities;
using BrewHelper.Web.Ingredients.Fermentables.Stores.Fermentables;
using BrewHelper.Web.Ingredients.Fermentables.Stores.Fermentables.Actions;
using BrewHelper.Web.Ingredients.Fermentables.Stores.Filters;
using BrewHelper.Web.Ingredients.Fermentables.Stores.Filters.Actions;
using Fluxor;
using Microsoft.AspNetCore.Components;
using Microsoft.VisualBasic;
using MudBlazor;

public partial class Fermentables
{
    [Inject]
    private IState<FermentablesState> FermentablesState { get; set; } = default!;

    [Inject]
    private IState<FermentablesFilterState> FermentablesFilterState { get; set; } = default!;

    private FermentablesTable FermentablesTable { get; set; } = default!;

    [Inject]
    private IDispatcher Dispatcher { get; set; } = default!;

    [Inject]
    private IDialogService DialogService { get; set; } = default!;

    private MudTextField<string> FilterQueryField { get; set; } = default!;

    private MudSelect<FermentableType> FilterTypeField { get; set; } = default!;

    private string TypeFilterText { get; set; } = string.Empty;

    protected async override Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();

        this.Dispatcher.Dispatch(new GetFermentablesAction());
    }

    protected Task CreateFermentable()
    {
        var options = new DialogOptions { CloseOnEscapeKey = true };
        this.DialogService.Show<FermentableCreationDialog>("Create Fermentable", options);
        return Task.CompletedTask;
    }

    private void TableItemSelected(TableRowClickEventArgs<Fermentable> fermentableRowClick)
    {
        var options = new DialogOptions { CloseOnEscapeKey = true, CloseButton = true };
        var parameters = new DialogParameters { { nameof(FermentableEditDialog.FermentableId), fermentableRowClick.Item.Id } };
        this.DialogService.Show<FermentableEditDialog>("Edit Fermentable", parameters, options);
    }

    private void UpdateTypesFilter(IEnumerable<FermentableType> selectedValues)
    {
        this.DispatchUpdateFilters(selectedValues);
    }

    private void UpdateFilters()
    {
        this.DispatchUpdateFilters();
    }

    private void DispatchUpdateFilters(IEnumerable<FermentableType>? selectedTypes = null)
    {
        this.Dispatcher.Dispatch(new UpdateFermentablesFilterAction(new FermentablesFilters
        {
            Query = this.FilterQueryField.Value,
            Types = selectedTypes ?? this.FermentablesFilterState.Value.Filters.Types
        }));
        this.UpdateTypeFilterText();
    }

    private void UpdateTypeFilterText()
    {
        this.TypeFilterText = string.Join(", ", this.FermentablesFilterState.Value.Filters.Types);
    }
}
