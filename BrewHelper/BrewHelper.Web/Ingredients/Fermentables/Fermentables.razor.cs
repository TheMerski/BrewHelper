namespace BrewHelper.Web.Ingredients.Fermentables;

using System;
using System.Linq;
using System.Threading.Tasks;
using BrewHelper.Business.Recipes;
using BrewHelper.Data.Mappers;
using BrewHelper.Web.Ingredients.Fermentables.Stores.Actions;
using BrewHelper.Web.Ingredients.Fermentables.Stores.States;
using Fluxor;
using Microsoft.AspNetCore.Components;
using MudBlazor;

public partial class Fermentables
{
    [Inject]
    private IState<FermentablesState> FermentablesState { get; set; } = default!;

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
        this.DialogService.Show<FermentableEditDialog>("Create Fermentable", options);
        return Task.CompletedTask;
    }
}
