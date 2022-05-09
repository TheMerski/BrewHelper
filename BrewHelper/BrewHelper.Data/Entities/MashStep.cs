namespace BrewHelper.Data.Entities;

using Microsoft.EntityFrameworkCore;

public enum MashStepType
{
    Infusion,
    Temperature,
    Decoction
}

[Owned]
public class MashStep : BrewHelperEntityBase
{
    public MashStepType Type { get; set; }

    public double StepTemp { get; set; }

    public int StepTime { get; set; }

    public double? InfuseAmount { get; set; }
}