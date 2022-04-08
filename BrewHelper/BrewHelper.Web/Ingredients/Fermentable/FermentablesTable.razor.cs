namespace BrewHelper.Web.Ingredients.Fermentable;

using System;
using System.Linq;
using System.Threading.Tasks;
using BrewHelper.Data.Entities;
using BrewHelper.Web.Ingredients.Fermentable.Stores.Actions;
using BrewHelper.Web.Ingredients.Fermentable.Stores.States;
using Fluxor;
using Microsoft.AspNetCore.Components;
using MudBlazor;

public partial class FermentablesTable
{
    [Inject]
    private IState<FermentablesState> FermentablesState { get; set; } = default!;

    [Inject]
    private IDispatcher Dispatcher { get; set; } = default!;

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
            _ =>
                fermentables.OrderBy(x => x.Name),
        };

        var skip = state.Page * state.PageSize;
        var take = state.PageSize;

        return await Task.FromResult(new TableData<Fermentable>
        {
            TotalItems = fermentables.Count(),
            Items = fermentables.Skip(skip).Take(take).ToArray(),
        });
    }
}