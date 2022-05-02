namespace BrewHelper.Data.Entities;

using Microsoft.EntityFrameworkCore;

public enum FermentableType
{
    Grain,
    Sugar,
    Extract,
    Dry_Extract,
    Adjunct
}

public class Fermentable : BrewHelperEntityBase
{
    public FermentableType Type { get; set; }

    /// <summary>
    /// Amount of the fermentable in stock (in g).
    /// </summary>
    public long StockAmount { get; set; } = 0;

    /// <summary>
    /// Percent dry yield (fine grain) for the grain, or the raw yield by weight if this is an extract adjunct or sugar.
    /// </summary>
    public double Yield { get; set; }

    /// <summary>
    /// The color of the item in Lovibond Units (SRM for liquid extracts).
    /// </summary>
    public double Color { get; set; }
}