namespace BrewHelper.Data.Entities;

using System.Collections.Generic;

public enum RecipeType
{
    Extract = 0,
    Partial_Mash = 1,
    All_Grain = 2,
}

public class Recipe : BrewHelperEntityBase
{
    public RecipeType Type { get; set; }

    public Style Style { get; set; } = default!;

    public string Brewer { get; set; } = default!;

    public double BatchSize { get; set; }

    public double BoilSize { get; set; }

    public double BoilTime { get; set; }

    public List<HopIngredient> Hops { get; set; } = default!;

    public List<RecipeIngredient<Fermentable>> Fermentables { get; set; } = default!;

    public List<RecipeIngredient<Misc>> Miscs { get; set; } = default!;

    public List<RecipeIngredient<Yeast>> Yeasts { get; set; } = default!;

    public List<RecipeIngredient<Water>> Waters { get; set; } = default!;

    public Mash Mash { get; set; } = default!;
}