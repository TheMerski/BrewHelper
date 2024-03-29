namespace BrewHelper.Data.Entities;

using Microsoft.EntityFrameworkCore;

public class Water : BrewHelperEntityBase
{
    public double Calcium { get; set; }

    public double Bicarbonate { get; set; }

    public double Sulfate { get; set; }

    public double Chloride { get; set; }

    public double Sodium { get; set; }

    public double Magnesium { get; set; }
}