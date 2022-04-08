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

    public double Amount { get; set; }

    public double Yield { get; set; }

    /// <summary>
    /// The color of the item in Lovibond Units (SRM for liquid extracts).
    /// </summary>
    public double Color { get; set; }
}