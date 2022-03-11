namespace BrewHelper.Data.Entities;

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

    public double Color { get; set; }
}