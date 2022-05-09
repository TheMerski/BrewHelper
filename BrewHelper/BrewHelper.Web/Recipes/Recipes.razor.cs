using System;
using System.Linq;
using System.Threading.Tasks;
using BrewHelper.Business.Recipes;
using BrewHelper.Data.Mappers;
using BrewHelper.Web.Recipes.Stores.Actions;
using BrewHelper.Web.Recipes.Stores.States;
using Fluxor;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BrewHelper.Web.Recipes;

public partial class Recipes
{
    [Inject]
    private IState<RecipesState> RecipesState { get; set; } = default!;

    [Inject]
    private IDispatcher Dispatcher { get; set; } = default!;

    [Inject]
    private IRecipeService RecipeService { get; set; } = default!;

    [Inject]
    private IBeerXMLMapper BeerXMLMapper { get; set; } = default!;

    protected override void OnInitialized()
    {
        base.OnInitialized();

        this.Dispatcher.Dispatch(new GetRecipesAction());
    }

    private Task AddRecipe()
    {
        // TODO: xml File uploading & creating Recipes from it
        throw new NotImplementedException();
    }
}
