using System;
using BrewHelper.Data.Entities;
using BrewHelper.Web.Ingredients.Fermentables.Stores.Fermentable;
using BrewHelper.Web.Ingredients.Fermentables.Stores.Fermentable.Actions;
using Fluxor;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BrewHelper.Web.Ingredients.Fermentables;

using System.Threading.Tasks;

public partial class FermentableEditForm
{
    [Parameter]
    public long FermentableId { get; set; } = default!;

    public MudForm Form { get; set; } = default!;

    private Fermentable? Fermentable { get; set; } = null;

    private bool IsValid { get; set; } = false;

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

        this.Dispatcher.Dispatch(new UpdateFermentableAction(this.Fermentable));
    }

    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        if (!this.FermentableState.Value.IsLoading && this.FermentableId != this.FermentableState.Value?.Fermentable?.Id)
        {
            this.Fermentable = null;
            this.Dispatcher.Dispatch(new GetFermentableAction(this.FermentableId));
        }
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        this.FermentableState.StateChanged += this.OnStateChanged;
        this.Dispatcher.Dispatch(new GetFermentableAction(this.FermentableId));
    }

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);

        this.FermentableState.StateChanged -= this.OnStateChanged;
    }

    private void OnStateChanged(object? sender, EventArgs e)
    {
        if (!this.FermentableState.Value.IsLoading)
        {
            this.Fermentable = this.FermentableState.Value.Fermentable!;
            this.StateHasChanged();
        }
    }

    private async Task SaveFermentable(Fermentable callback)
    {
        await this.Form.Validate();
        if (this.Fermentable != null && this.Form.IsValid)
        {
            this.Dispatcher.Dispatch(new UpdateFermentableAction(this.Fermentable));
        }
    }
}