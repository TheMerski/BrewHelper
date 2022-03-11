namespace BrewHelper.Data.Entities;

using Microsoft.EntityFrameworkCore;

public enum StyleType
{
    Lager,
    Ale,
    Mead,
    Wheat,
    Mixed,
    Cider
}

[Owned]
public class Style : BrewHelperEntityBase
{
    public string Category { get; set; } = default!;

    public string CategoryNumber { get; set; } = default!;

    public string StyleLetter { get; set; } = default!;

    public string StyleGuide { get; set; } = default!;

    public StyleType Type { get; set; }

    public double OG_Max { get; set; }

    public double OG_Min { get; set; }

    public double IBU_Min { get; set; }

    public double IBU_Max { get; set; }

    public double ColorMin { get; set; }

    public double ColorMax { get; set; }
}