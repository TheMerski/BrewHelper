namespace BrewHelper.Web.Ingredients.Hops.Stores.Filters;

using System;
using System.Collections.Generic;
using System.Linq;
using BrewHelper.Data.Entities;

public class HopsFilters
{
    public HopsFilters(string? query = null)
    {
        this.Query = query;
    }

    public string? Query { get; set; }
}
