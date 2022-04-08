namespace BrewHelper.Data.Entities;

using Microsoft.EntityFrameworkCore;

public enum HopUse
{
    Boil,
    Dry_Hop,
    Mash,
    First_Wort,
    Aroma
}

public class Hop : BrewHelperEntityBase
{
    public double Alpha { get; set; }

    public double Amount { get; set; }

    public HopUse Use { get; set; }

    public double Time { get; set; }
}