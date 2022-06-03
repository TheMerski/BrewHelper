namespace BrewHelper.Web.Ingredients.Hops;

using System;
using System.Linq;
using System.Threading.Tasks;
using BrewHelper.Data.Entities;
using BrewHelper.Web.Ingredients.Hops.Stores.Filters;
using BrewHelper.Web.Ingredients.Hops.Stores.Hop.Actions;
using BrewHelper.Web.Ingredients.Hops.Stores.Hops;
using BrewHelper.Web.Ingredients.Hops.Stores.Hops.Actions;
using Fluxor;
using Microsoft.AspNetCore.Components;
using MudBlazor;

public partial class HopsTable
{
    [Parameter]
    public EventCallback<TableRowClickEventArgs<Hop>> RowItemClicked { get; set; }

    private MudTable<Hop> Table { get; set; } = default!;

    [Inject]
    private IState<HopsState> HopsState { get; set; } = default!;

    [Inject]
    private IState<HopsFilterState> HopsFilterState { get; set; } = default!;

    [Inject]
    private IDispatcher Dispatcher { get; set; } = default!;

    [Inject]
    private IDialogService DialogService { get; set; } = default!;

    protected override void OnInitialized()
    {
        base.OnInitialized();

        if (!this.HopsState.Value.IsLoading && this.HopsState.Value == null)
        {
            this.ReloadData();
        }

        this.HopsState.StateChanged += this.StateChanged;
    }

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);

        this.HopsState.StateChanged -= this.StateChanged;
    }

    private void StateChanged(object? sender, EventArgs e)
    {
        if (!this.HopsState.Value.IsLoading)
        {
            this.Table.ReloadServerData();
        }
    }

    private void ReloadData()
    {
        this.Dispatcher.Dispatch(new GetHopsAction(this.HopsFilterState.Value.Filters));
    }

    private async Task DeleteHop(Hop hop)
    {
        bool? result = await this.DialogService.ShowMessageBox(
            "Warning",
            "Deleting can not be undone!",
            yesText: "Delete!",
            cancelText: "Cancel");

        if (result == true)
        {
            this.Dispatcher.Dispatch(new DeleteHopAction(hop));
        }

        return;
    }

    private void DuplicateHop(Hop hop)
    {
        this.Dispatcher.Dispatch(new CreateHopVersionAction(hop));
    }

    private async Task<TableData<Hop>> TableData(TableState state)
    {
        var hops = this.HopsState.Value.Hops;

        if (hops == null)
        {
            return await Task.FromResult(new TableData<Hop>
            {
                TotalItems = 0,
                Items = System.Array.Empty<Hop>(),
            });
        }

        hops = state.SortLabel switch
        {
            nameof(Hop.Name) =>
                hops.OrderByDirection(state.SortDirection, i => i.Name),
            nameof(Hop.Version) =>
                hops.OrderByDirection(state.SortDirection, i => i.Version),
            nameof(Hop.StockAmount) =>
                hops.OrderByDirection(state.SortDirection, i => i.StockAmount),
            _ =>
                hops.OrderBy(x => x.Name),
        };

        var skip = state.Page * state.PageSize;
        var take = state.PageSize;
        var items = hops.Skip(skip).Take(take).ToArray();

        return await Task.FromResult(new TableData<Hop>
        {
            TotalItems = hops.Count(),
            Items = items,
        });
    }
}