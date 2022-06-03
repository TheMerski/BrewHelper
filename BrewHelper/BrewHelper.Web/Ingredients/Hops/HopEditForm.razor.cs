namespace BrewHelper.Web.Ingredients.Hops;

using System;
using System.Threading.Tasks;
using BrewHelper.Data.Entities;
using BrewHelper.Web.Ingredients.Hops.Stores.Hop;
using BrewHelper.Web.Ingredients.Hops.Stores.Hop.Actions;
using Fluxor;
using Microsoft.AspNetCore.Components;
using MudBlazor;

public partial class HopEditForm
{
    [Parameter]
    public long HopId { get; set; } = default!;

    public MudForm Form { get; set; } = default!;

    private Hop? Hop { get; set; } = null;

    private bool IsValid { get; set; } = false;

    [Inject]
    private IState<HopState> HopState { get; set; } = default!;

    [Inject]
    private IDispatcher Dispatcher { get; set; } = default!;

    public void Save()
    {
        if (!this.Form.IsValid || this.Hop == null)
        {
            return;
        }

        this.Dispatcher.Dispatch(new UpdateHopAction(this.Hop));
    }

    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        if (!this.HopState.Value.IsLoading && this.HopId != this.HopState.Value?.Hop?.Id)
        {
            this.Hop = null;
            this.Dispatcher.Dispatch(new GetHopAction(this.HopId));
        }
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        this.HopState.StateChanged += this.OnStateChanged;
        this.Dispatcher.Dispatch(new GetHopAction(this.HopId));
    }

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);

        this.HopState.StateChanged -= this.OnStateChanged;
    }

    private void OnStateChanged(object? sender, EventArgs e)
    {
        if (!this.HopState.Value.IsLoading)
        {
            this.Hop = this.HopState.Value.Hop!;
            this.StateHasChanged();
        }
    }

    private async Task SaveHop(Hop callback)
    {
        await this.Form.Validate();
        if (this.Hop != null && this.Form.IsValid)
        {
            this.Dispatcher.Dispatch(new UpdateHopAction(this.Hop));
        }
    }
}