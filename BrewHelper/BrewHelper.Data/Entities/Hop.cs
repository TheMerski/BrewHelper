namespace BrewHelper.Data.Entities;

using Microsoft.EntityFrameworkCore;

public class Hop : BrewHelperEntityBase
{
    public double Alpha { get; set; }

    /// <summary>
    /// Amount of the hop in stock (in g).
    /// </summary>
    public long StockAmount { get; set; } = 0;

    public Hop Clone() => (Hop)this.MemberwiseClone();
}