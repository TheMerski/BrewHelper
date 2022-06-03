namespace BrewHelper.Web.Ingredients.Yeasts.Stores.Filters;

using System;
using System.Collections.Generic;
using System.Linq;
using BrewHelper.Data.Entities;

public class YeastsFilters
{
    public YeastsFilters(string? query = null)
    {
        this.Query = query;
    }

    public string? Query { get; set; }
}
