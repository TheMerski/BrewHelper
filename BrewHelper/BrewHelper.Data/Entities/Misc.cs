namespace BrewHelper.Data.Entities;

using Microsoft.EntityFrameworkCore;

public enum MiscType
{
    Spice,
    Fining,
    Water_Agent,
    Herb,
    Flavor,
    Other
}

public enum MiscUse
{
    Boil,
    Mash,
    Primary,
    Secondary,
    Bottling
}

public class Misc : BrewHelperEntityBase
{
    public MiscType Type { get; set; }

    public MiscUse Use { get; set; }

    public double Time { get; set; }

    public double Amount { get; set; }
}