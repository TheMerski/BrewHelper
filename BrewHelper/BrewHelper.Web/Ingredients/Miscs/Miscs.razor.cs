namespace BrewHelper.Web.Ingredients.Miscs;

using System.Threading.Tasks;
using BrewHelper.Data.Entities;
using BrewHelper.Web.Ingredients.Miscs.Stores.Filters;
using BrewHelper.Web.Ingredients.Miscs.Stores.Filters.Actions;
using BrewHelper.Web.Ingredients.Miscs.Stores.Miscs;
using BrewHelper.Web.Ingredients.Miscs.Stores.Miscs.Actions;
using Fluxor;
using Microsoft.AspNetCore.Components;
using MudBlazor;

public partial class Miscs
{
    [Inject]
    private IState<MiscsState> MiscsState { get; set; } = default!;

    [Inject]
    private IState<MiscsFilterState> MiscsFilterState { get; set; } = default!;

    private MiscsTable MiscsTable { get; set; } = default!;

    [Inject]
    private IDispatcher Dispatcher { get; set; } = default!;

    [Inject]
    private IDialogService DialogService { get; set; } = default!;

    private MudTextField<string> FilterQueryField { get; set; } = default!;

    protected async override Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();

        this.Dispatcher.Dispatch(new GetMiscsAction());
    }

    protected Task CreateMisc()
    {
        var options = new DialogOptions { CloseOnEscapeKey = true };
        this.DialogService.Show<MiscCreationDialog>("Create Misc", options);
        return Task.CompletedTask;
    }

    private void TableItemSelected(TableRowClickEventArgs<Misc> miscRowClick)
    {
        var options = new DialogOptions { CloseOnEscapeKey = true, CloseButton = true };
        var parameters = new DialogParameters { { nameof(MiscEditDialog.MiscId), miscRowClick.Item.Id } };
        this.DialogService.Show<MiscEditDialog>("Edit Misc", parameters, options);
    }

    private void UpdateFilters()
    {
        this.DispatchUpdateFilters();
    }

    private void DispatchUpdateFilters()
    {
        this.Dispatcher.Dispatch(new UpdateMiscsFilterAction(new MiscsFilters
        {
            Query = this.FilterQueryField.Value,
        }));
    }
}
