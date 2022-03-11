namespace BrewHelper.Data.Entities;

public abstract class BrewHelperEntityBase
{
    public long Id { get; set; }

    public string Name { get; set; } = default!;

    public int Version { get; set; }

    public string Notes { get; set; } = string.Empty;
}