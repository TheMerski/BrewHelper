using System;
using BrewHelper.Data.Entities;
using BrewHelper.Web.Ingredients.Fermentables.Stores.Fermentable;
using BrewHelper.Web.Ingredients.Fermentables.Stores.Fermentable.Actions;
using Fluxor;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BrewHelper.Web.Ingredients.Fermentables;
public partial class FermentableEditForm
{
    [Parameter]
    public long? FermentableId { get; set; } = null;

    public MudForm Form { get; set; } = default!;

    private Fermentable? Fermentable { get; set; } = null;

    [Inject]
    private IState<FermentableState> FermentableState { get; set; } = default!;

    [Inject]
    private IDispatcher Dispatcher { get; set; } = default!;

    public void Save()
    {
        if (!this.Form.IsValid || this.Fermentable == null)
        {
            return;
        }

        // If FermentableId is null this is a newly created entity
        if (this.FermentableId == null)
        {
            this.Dispatcher.Dispatch(new CreateFermentableAction(this.Fermentable));
            return;
        }
        else
        {
            this.Dispatcher.Dispatch(new UpdateFermentableAction(this.Fermentable));
        }
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        if (this.FermentableId == null)
        {
            this.Fermentable = new Fermentable();
        }
        else
        {
            this.FermentableState.StateChanged += this.OnStateChanged;
            this.Dispatcher.Dispatch(new GetFermentableAction((long)this.FermentableId));
        }
    }

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);

        if (this.FermentableId == null)
        {
            this.FermentableState.StateChanged -= this.OnStateChanged;
        }
    }

    private void OnStateChanged(object? sender, EventArgs e)
    {
        if (!this.FermentableState.Value.IsLoading)
        {
            this.Fermentable = this.FermentableState.Value.Fermentable!;
            this.StateHasChanged();
        }
    }
}