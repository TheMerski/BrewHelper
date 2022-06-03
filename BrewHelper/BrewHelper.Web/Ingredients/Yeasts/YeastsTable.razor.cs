namespace BrewHelper.Web.Ingredients.Yeasts;

using System;
using System.Linq;
using System.Threading.Tasks;
using BrewHelper.Data.Entities;
using BrewHelper.Web.Ingredients.Yeasts.Stores.Filters;
using BrewHelper.Web.Ingredients.Yeasts.Stores.Yeast.Actions;
using BrewHelper.Web.Ingredients.Yeasts.Stores.Yeasts;
using BrewHelper.Web.Ingredients.Yeasts.Stores.Yeasts.Actions;
using Fluxor;
using Microsoft.AspNetCore.Components;
using MudBlazor;

public partial class YeastsTable
{
    [Parameter]
    public EventCallback<TableRowClickEventArgs<Yeast>> RowItemClicked { get; set; }

    private MudTable<Yeast> Table { get; set; } = default!;

    [Inject]
    private IState<YeastsState> YeastsState { get; set; } = default!;

    [Inject]
    private IState<YeastsFilterState> YeastsFilterState { get; set; } = default!;

    [Inject]
    private IDispatcher Dispatcher { get; set; } = default!;

    [Inject]
    private IDialogService DialogService { get; set; } = default!;

    protected override void OnInitialized()
    {
        base.OnInitialized();

        if (!this.YeastsState.Value.IsLoading && this.YeastsState.Value == null)
        {
            this.ReloadData();
        }

        this.YeastsState.StateChanged += this.StateChanged;
    }

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);

        this.YeastsState.StateChanged -= this.StateChanged;
    }

    private void StateChanged(object? sender, EventArgs e)
    {
        if (!this.YeastsState.Value.IsLoading)
        {
            this.Table.ReloadServerData();
        }
    }

    private void ReloadData()
    {
        this.Dispatcher.Dispatch(new GetYeastsAction(this.YeastsFilterState.Value.Filters));
    }

    private async Task DeleteYeast(Yeast yeast)
    {
        bool? result = await this.DialogService.ShowMessageBox(
            "Warning",
            "Deleting can not be undone!",
            yesText: "Delete!",
            cancelText: "Cancel");

        if (result == true)
        {
            this.Dispatcher.Dispatch(new DeleteYeastAction(yeast));
        }

        return;
    }

    private void DuplicateYeast(Yeast yeast)
    {
        this.Dispatcher.Dispatch(new CreateYeastVersionAction(yeast));
    }

    private async Task<TableData<Yeast>> TableData(TableState state)
    {
        var yeasts = this.YeastsState.Value.Yeasts;

        if (yeasts == null)
        {
            return await Task.FromResult(new TableData<Yeast>
            {
                TotalItems = 0,
                Items = System.Array.Empty<Yeast>(),
            });
        }

        yeasts = state.SortLabel switch
        {
            nameof(Yeast.Name) =>
                yeasts.OrderByDirection(state.SortDirection, i => i.Name),
            nameof(Yeast.Version) =>
                yeasts.OrderByDirection(state.SortDirection, i => i.Version),
            nameof(Yeast.StockAmount) =>
                yeasts.OrderByDirection(state.SortDirection, i => i.StockAmount),
            _ =>
                yeasts.OrderBy(x => x.Name),
        };

        var skip = state.Page * state.PageSize;
        var take = state.PageSize;
        var items = yeasts.Skip(skip).Take(take).ToArray();

        return await Task.FromResult(new TableData<Yeast>
        {
            TotalItems = yeasts.Count(),
            Items = items,
        });
    }
}