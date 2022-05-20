namespace BrewHelper.Web.Ingredients.Fermentables.Stores.Filters;

using System;
using System.Collections.Generic;
using System.Linq;
using BrewHelper.Data.Entities;

public class FermentablesFilters
{
    public FermentablesFilters(string? query = null, IEnumerable<FermentableType>? types = null)
    {
        this.Query = query;
        this.Types = types ?? Enum.GetValues(typeof(FermentableType)).Cast<FermentableType>();
    }

    public string? Query { get; set; }

    public IEnumerable<FermentableType> Types { get; set; }
}
