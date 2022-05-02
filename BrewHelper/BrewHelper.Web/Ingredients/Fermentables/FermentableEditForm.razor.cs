using BrewHelper.Data.Entities;
using BrewHelper.Web.Ingredients.Fermentables.Stores.Actions;
using Fluxor;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BrewHelper.Web.Ingredients.Fermentables;
public partial class FermentableEditForm
{
    public FermentableEditForm()
    {
        if (this.Fermentable == null)
        {
            this.Fermentable = new Fermentable();
        }
    }

    [Parameter]
    public Fermentable Fermentable { get; set; } = default!;

    public MudForm Form { get; set; } = default!;

    [Inject]
    private IDispatcher Dispatcher { get; set; } = default!;

    public void Save()
    {
        // If Id is 0 this is a newly created entity
        if (this.Fermentable.Id == 0)
        {
            this.Dispatcher.Dispatch(new CreateFermentableAction(this.Fermentable));
            return;
        }
    }
}