namespace BrewHelper.Web.Ingredients.Fermentables;
using System.Threading.Tasks;
using BrewHelper.Data.Entities;
using BrewHelper.Web.Ingredients.Fermentables.Stores.Fermentables;
using BrewHelper.Web.Ingredients.Fermentables.Stores.Fermentables.Actions;
using BrewHelper.Web.Ingredients.Fermentables.Stores.Filters;
using Fluxor;
using Microsoft.AspNetCore.Components;
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

    protected override void OnInitialized()
    {
        base.OnInitialized();

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

    private void UpdateFilters()
    {
        this.Dispatcher.Dispatch(new UpdateFermentablesFilterAction(new FermentablesFilters
        {
            Query = this.FilterQueryField.Value
        }));
    }
}
