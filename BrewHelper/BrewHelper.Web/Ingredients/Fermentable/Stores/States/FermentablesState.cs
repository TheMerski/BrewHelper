namespace BrewHelper.Web.Ingredients.Fermentable.Stores.States;

using System.Linq;
using BrewHelper.Data.Entities;

public record FermentablesState(bool IsLoading, IQueryable<Fermentable>? Fermentables);