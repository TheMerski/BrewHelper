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

public class Yeast : BrewHelperEntityBase
{
    public YeastType Type { get; set; }

    public YeastForm Form { get; set; }

    /// <summary>
    /// Amount of the yeast in stock.
    /// </summary>
    public long StockAmount { get; set; } = 0;

    public Yeast Clone() => (Yeast)this.MemberwiseClone();
}
