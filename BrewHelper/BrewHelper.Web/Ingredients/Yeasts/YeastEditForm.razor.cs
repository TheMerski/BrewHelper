namespace BrewHelper.Web.Ingredients.Yeasts;

using System;
using System.Threading.Tasks;
using BrewHelper.Data.Entities;
using BrewHelper.Web.Ingredients.Yeasts.Stores.Yeast;
using BrewHelper.Web.Ingredients.Yeasts.Stores.Yeast.Actions;
using Fluxor;
using Microsoft.AspNetCore.Components;
using MudBlazor;

public partial class YeastEditForm
{
    [Parameter]
    public long YeastId { get; set; } = default!;

    public MudForm Form { get; set; } = default!;

    private Yeast? Yeast { get; set; } = null;

    private bool IsValid { get; set; } = false;

    [Inject]
    private IState<YeastState> YeastState { get; set; } = default!;

    [Inject]
    private IDispatcher Dispatcher { get; set; } = default!;

    public void Save()
    {
        if (!this.Form.IsValid || this.Yeast == null)
        {
            return;
        }

        this.Dispatcher.Dispatch(new UpdateYeastAction(this.Yeast));
    }

    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        if (!this.YeastState.Value.IsLoading && this.YeastId != this.YeastState.Value?.Yeast?.Id)
        {
            this.Yeast = null;
            this.Dispatcher.Dispatch(new GetYeastAction(this.YeastId));
        }
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        this.YeastState.StateChanged += this.OnStateChanged;
        this.Dispatcher.Dispatch(new GetYeastAction(this.YeastId));
    }

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);

        this.YeastState.StateChanged -= this.OnStateChanged;
    }

    private void OnStateChanged(object? sender, EventArgs e)
    {
        if (!this.YeastState.Value.IsLoading)
        {
            this.Yeast = this.YeastState.Value.Yeast!;
            this.StateHasChanged();
        }
    }

    private async Task SaveYeast(Yeast callback)
    {
        await this.Form.Validate();
        if (this.Yeast != null && this.Form.IsValid)
        {
            this.Dispatcher.Dispatch(new UpdateYeastAction(this.Yeast));
        }
    }
}