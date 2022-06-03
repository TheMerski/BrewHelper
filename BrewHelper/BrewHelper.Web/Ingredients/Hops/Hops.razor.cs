namespace BrewHelper.Web.Ingredients.Hops;

using System.Threading.Tasks;
using BrewHelper.Data.Entities;
using BrewHelper.Web.Ingredients.Hops.Stores.Filters;
using BrewHelper.Web.Ingredients.Hops.Stores.Filters.Actions;
using BrewHelper.Web.Ingredients.Hops.Stores.Hops;
using BrewHelper.Web.Ingredients.Hops.Stores.Hops.Actions;
using Fluxor;
using Microsoft.AspNetCore.Components;
using MudBlazor;

public partial class Hops
{
    [Inject]
    private IState<HopsState> HopsState { get; set; } = default!;

    [Inject]
    private IState<HopsFilterState> HopsFilterState { get; set; } = default!;

    private HopsTable HopsTable { get; set; } = default!;

    [Inject]
    private IDispatcher Dispatcher { get; set; } = default!;

    [Inject]
    private IDialogService DialogService { get; set; } = default!;

    private MudTextField<string> FilterQueryField { get; set; } = default!;

    protected async override Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();

        this.Dispatcher.Dispatch(new GetHopsAction());
    }

    protected Task CreateHop()
    {
        var options = new DialogOptions { CloseOnEscapeKey = true };
        this.DialogService.Show<HopCreationDialog>("Create Hop", options);
        return Task.CompletedTask;
    }

    private void TableItemSelected(TableRowClickEventArgs<Hop> hopRowClick)
    {
        var options = new DialogOptions { CloseOnEscapeKey = true, CloseButton = true };
        var parameters = new DialogParameters { { nameof(HopEditDialog.HopId), hopRowClick.Item.Id } };
        this.DialogService.Show<HopEditDialog>("Edit Hop", parameters, options);
    }

    private void UpdateFilters()
    {
        this.DispatchUpdateFilters();
    }

    private void DispatchUpdateFilters()
    {
        this.Dispatcher.Dispatch(new UpdateHopsFilterAction(new HopsFilters
        {
            Query = this.FilterQueryField.Value,
        }));
    }
}
