namespace BrewHelper.Web.Ingredients.Fermentables;

using System;
using System.Linq;
using System.Threading.Tasks;
using BrewHelper.Data.Entities;
using BrewHelper.Web.Ingredients.Fermentables.Stores.Fermentable.Actions;
using BrewHelper.Web.Ingredients.Fermentables.Stores.Fermentables;
using BrewHelper.Web.Ingredients.Fermentables.Stores.Fermentables.Actions;
using Fluxor;
using Microsoft.AspNetCore.Components;
using MudBlazor;

public partial class FermentablesTable
{
    [Inject]
    private IState<FermentablesState> FermentablesState { get; set; } = default!;

    [Inject]
    private IDispatcher Dispatcher { get; set; } = default!;

    [Inject]
    private IDialogService DialogService { get; set; } = default!;

    private MudTable<Fermentable> Table { get; set; } = default!;

    protected override void OnInitialized()
    {
        base.OnInitialized();

        if (!this.FermentablesState.Value.IsLoading && this.FermentablesState.Value == null)
        {
            this.ReloadData();
        }

        this.FermentablesState.StateChanged += this.StateChanged;
    }

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);

        this.FermentablesState.StateChanged -= this.StateChanged;
    }

    private void StateChanged(object? sender, EventArgs e)
    {
        if (!this.FermentablesState.Value.IsLoading)
        {
            this.Table.ReloadServerData();
        }
    }

    private void ReloadData()
    {
        this.Dispatcher.Dispatch(new GetFermentablesAction());
    }

    private async Task DeleteFermentable(Fermentable fermentable)
    {
        bool? result = await this.DialogService.ShowMessageBox(
            "Warning",
            "Deleting can not be undone!",
            yesText: "Delete!",
            cancelText: "Cancel");

        if (result == true)
        {
            this.Dispatcher.Dispatch(new DeleteFermentableAction(fermentable));
        }

        return;
    }

    private Task EditFermentable(long id)
    {
        var parameters = new DialogParameters();
        parameters.Add(nameof(FermentableEditDialog.FermentableId), id);

        var options = new DialogOptions { CloseOnEscapeKey = true };
        this.DialogService.Show<FermentableEditDialog>("Edit Fermentable", parameters, options);
        return Task.CompletedTask;
    }

    private async Task<TableData<Fermentable>> TableData(TableState state)
    {
        var fermentables = this.FermentablesState.Value.Fermentables;

        if (fermentables == null)
        {
            return await Task.FromResult(new TableData<Fermentable>
            {
                TotalItems = 0,
                Items = System.Array.Empty<Fermentable>(),
            });
        }

        fermentables = state.SortLabel switch
        {
            nameof(Fermentable.Name) =>
                fermentables.OrderByDirection(state.SortDirection, i => i.Name),
            nameof(Fermentable.Version) =>
                fermentables.OrderByDirection(state.SortDirection, i => i.Version),
            nameof(Fermentable.StockAmount) =>
                fermentables.OrderByDirection(state.SortDirection, i => i.StockAmount),
            _ =>
                fermentables.OrderBy(x => x.Name),
        };

        var skip = state.Page * state.PageSize;
        var take = state.PageSize;
        var items = fermentables.Skip(skip).Take(take).ToArray();

        return await Task.FromResult(new TableData<Fermentable>
        {
            TotalItems = fermentables.Count(),
            Items = items,
        });
    }
}