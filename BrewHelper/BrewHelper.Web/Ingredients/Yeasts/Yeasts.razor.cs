namespace BrewHelper.Web.Ingredients.Yeasts;

using System.Threading.Tasks;
using BrewHelper.Data.Entities;
using BrewHelper.Web.Ingredients.Yeasts.Stores.Filters;
using BrewHelper.Web.Ingredients.Yeasts.Stores.Filters.Actions;
using BrewHelper.Web.Ingredients.Yeasts.Stores.Yeasts;
using BrewHelper.Web.Ingredients.Yeasts.Stores.Yeasts.Actions;
using Fluxor;
using Microsoft.AspNetCore.Components;
using MudBlazor;

public partial class Yeasts
{
    [Inject]
    private IState<YeastsState> YeastsState { get; set; } = default!;

    [Inject]
    private IState<YeastsFilterState> YeastsFilterState { get; set; } = default!;

    private YeastsTable YeastsTable { get; set; } = default!;

    [Inject]
    private IDispatcher Dispatcher { get; set; } = default!;

    [Inject]
    private IDialogService DialogService { get; set; } = default!;

    private MudTextField<string> FilterQueryField { get; set; } = default!;

    protected async override Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();

        this.Dispatcher.Dispatch(new GetYeastsAction());
    }

    protected Task CreateYeast()
    {
        var options = new DialogOptions { CloseOnEscapeKey = true };
        this.DialogService.Show<YeastCreationDialog>("Create Yeast", options);
        return Task.CompletedTask;
    }

    private void TableItemSelected(TableRowClickEventArgs<Yeast> yeastRowClick)
    {
        var options = new DialogOptions { CloseOnEscapeKey = true, CloseButton = true };
        var parameters = new DialogParameters { { nameof(YeastEditDialog.YeastId), yeastRowClick.Item.Id } };
        this.DialogService.Show<YeastEditDialog>("Edit Yeast", parameters, options);
    }

    private void UpdateFilters()
    {
        this.DispatchUpdateFilters();
    }

    private void DispatchUpdateFilters()
    {
        this.Dispatcher.Dispatch(new UpdateYeastsFilterAction(new YeastsFilters
        {
            Query = this.FilterQueryField.Value,
        }));
    }
}
