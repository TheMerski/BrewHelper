namespace BrewHelper.Web.Ingredients.Fermentables;
using System.Threading.Tasks;
using BrewHelper.Data.Entities;
using BrewHelper.Web.Ingredients.Fermentables.Stores.Fermentables;
using BrewHelper.Web.Ingredients.Fermentables.Stores.Fermentables.Actions;
using Fluxor;
using Microsoft.AspNetCore.Components;
using MudBlazor;

public partial class Fermentables
{
    [Inject]
    private IState<FermentablesState> FermentablesState { get; set; } = default!;

    private FermentablesTable FermentablesTable { get; set; } = default!;

    private Fermentable? SelectedFermentable { get; set; } = null;

    [Inject]
    private IDispatcher Dispatcher { get; set; } = default!;

    [Inject]
    private IDialogService DialogService { get; set; } = default!;

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

    private void TableItemSelected(Fermentable fermentable)
    {
        this.SelectedFermentable = fermentable;
    }
}
