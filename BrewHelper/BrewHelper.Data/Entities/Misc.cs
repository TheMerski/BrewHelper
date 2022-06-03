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

    /// <summary>
    /// Amount of the misc in stock.
    /// </summary>
    public long StockAmount { get; set; } = 0;

    public Misc Clone() => (Misc)this.MemberwiseClone();
}
