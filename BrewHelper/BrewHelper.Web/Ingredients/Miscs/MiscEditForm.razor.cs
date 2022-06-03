namespace BrewHelper.Web.Ingredients.Miscs;

using System;
using System.Threading.Tasks;
using BrewHelper.Data.Entities;
using BrewHelper.Web.Ingredients.Miscs.Stores.Misc;
using BrewHelper.Web.Ingredients.Miscs.Stores.Misc.Actions;
using Fluxor;
using Microsoft.AspNetCore.Components;
using MudBlazor;

public partial class MiscEditForm
{
    [Parameter]
    public long MiscId { get; set; } = default!;

    public MudForm Form { get; set; } = default!;

    private Misc? Misc { get; set; } = null;

    private bool IsValid { get; set; } = false;

    [Inject]
    private IState<MiscState> MiscState { get; set; } = default!;

    [Inject]
    private IDispatcher Dispatcher { get; set; } = default!;

    public void Save()
    {
        if (!this.Form.IsValid || this.Misc == null)
        {
            return;
        }

        this.Dispatcher.Dispatch(new UpdateMiscAction(this.Misc));
    }

    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        if (!this.MiscState.Value.IsLoading && this.MiscId != this.MiscState.Value?.Misc?.Id)
        {
            this.Misc = null;
            this.Dispatcher.Dispatch(new GetMiscAction(this.MiscId));
        }
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        this.MiscState.StateChanged += this.OnStateChanged;
        this.Dispatcher.Dispatch(new GetMiscAction(this.MiscId));
    }

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);

        this.MiscState.StateChanged -= this.OnStateChanged;
    }

    private void OnStateChanged(object? sender, EventArgs e)
    {
        if (!this.MiscState.Value.IsLoading)
        {
            this.Misc = this.MiscState.Value.Misc!;
            this.StateHasChanged();
        }
    }

    private async Task SaveMisc(Misc callback)
    {
        await this.Form.Validate();
        if (this.Misc != null && this.Form.IsValid)
        {
            this.Dispatcher.Dispatch(new UpdateMiscAction(this.Misc));
        }
    }
}