namespace BrewHelper.Data.Entities;

using Microsoft.EntityFrameworkCore;

public enum YeastType
{
    Ale,
    Lager,
    Wheat,
    Wine,
    Champagne
}

public enum YeastForm
{
    Liquid,
    Dry,
    Slant,
    Culture
}

[Owned]
public class Yeast : BrewHelperEntityBase
{
    public YeastType Type { get; set; }

    public YeastForm Form { get; set; }

    public double Amount { get; set; }
}
