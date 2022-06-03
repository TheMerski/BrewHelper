namespace BrewHelper.Web.Ingredients.Miscs.Stores.Filters;

public class MiscsFilters
{
    public MiscsFilters(string? query = null)
    {
        this.Query = query;
    }

    public string? Query { get; set; }
}
