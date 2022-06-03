namespace BrewHelper.Web.Ingredients.Miscs;

using System;
using System.Linq;
using System.Threading.Tasks;
using BrewHelper.Data.Entities;
using BrewHelper.Web.Ingredients.Miscs.Stores.Filters;
using BrewHelper.Web.Ingredients.Miscs.Stores.Misc.Actions;
using BrewHelper.Web.Ingredients.Miscs.Stores.Miscs;
using BrewHelper.Web.Ingredients.Miscs.Stores.Miscs.Actions;
using Fluxor;
using Microsoft.AspNetCore.Components;
using MudBlazor;

public partial class MiscsTable
{
    [Parameter]
    public EventCallback<TableRowClickEventArgs<Misc>> RowItemClicked { get; set; }

    private MudTable<Misc> Table { get; set; } = default!;

    [Inject]
    private IState<MiscsState> MiscsState { get; set; } = default!;

    [Inject]
    private IState<MiscsFilterState> MiscsFilterState { get; set; } = default!;

    [Inject]
    private IDispatcher Dispatcher { get; set; } = default!;

    [Inject]
    private IDialogService DialogService { get; set; } = default!;

    protected override void OnInitialized()
    {
        base.OnInitialized();

        if (!this.MiscsState.Value.IsLoading && this.MiscsState.Value == null)
        {
            this.ReloadData();
        }

        this.MiscsState.StateChanged += this.StateChanged;
    }

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);

        this.MiscsState.StateChanged -= this.StateChanged;
    }

    private void StateChanged(object? sender, EventArgs e)
    {
        if (!this.MiscsState.Value.IsLoading)
        {
            this.Table.ReloadServerData();
        }
    }

    private void ReloadData()
    {
        this.Dispatcher.Dispatch(new GetMiscsAction(this.MiscsFilterState.Value.Filters));
    }

    private async Task DeleteMisc(Misc misc)
    {
        bool? result = await this.DialogService.ShowMessageBox(
            "Warning",
            "Deleting can not be undone!",
            yesText: "Delete!",
            cancelText: "Cancel");

        if (result == true)
        {
            this.Dispatcher.Dispatch(new DeleteMiscAction(misc));
        }

        return;
    }

    private void DuplicateMisc(Misc misc)
    {
        this.Dispatcher.Dispatch(new CreateMiscVersionAction(misc));
    }

    private async Task<TableData<Misc>> TableData(TableState state)
    {
        var miscs = this.MiscsState.Value.Miscs;

        if (miscs == null)
        {
            return await Task.FromResult(new TableData<Misc>
            {
                TotalItems = 0,
                Items = System.Array.Empty<Misc>(),
            });
        }

        miscs = state.SortLabel switch
        {
            nameof(Misc.Name) =>
                miscs.OrderByDirection(state.SortDirection, i => i.Name),
            nameof(Misc.Version) =>
                miscs.OrderByDirection(state.SortDirection, i => i.Version),
            nameof(Misc.StockAmount) =>
                miscs.OrderByDirection(state.SortDirection, i => i.StockAmount),
            _ =>
                miscs.OrderBy(x => x.Name),
        };

        var skip = state.Page * state.PageSize;
        var take = state.PageSize;
        var items = miscs.Skip(skip).Take(take).ToArray();

        return await Task.FromResult(new TableData<Misc>
        {
            TotalItems = miscs.Count(),
            Items = items,
        });
    }
}