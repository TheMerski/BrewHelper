namespace BrewHelper.Data.Entities;

public abstract class BrewHelperEntityBase
{
    public string Name { get; set; } = default!;

    public int Version { get; set; }

    public string Notes { get; set; } = string.Empty;
}