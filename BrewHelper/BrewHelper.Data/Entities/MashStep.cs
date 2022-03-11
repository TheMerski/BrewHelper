namespace BrewHelper.Data.Entities;

public enum MashStepType
{
    Infusion,
    Temperature,
    Decoction
}

public class MashStep : BrewHelperEntityBase
{
    public MashStepType Type { get; set; }

    public double StepTemp { get; set; }

    public double StepTime { get; set; }

    public double? InfuseAmount { get; set; }
}