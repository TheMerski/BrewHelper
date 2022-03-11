namespace BrewHelper.Data.Entities;

using System.Collections.Generic;

public class Mash : BrewHelperEntityBase
{
    public Mash()
    {
        this.MashSteps = new List<MashStep>();
    }

    public double GrainTemp { get; set; }

    public List<MashStep> MashSteps { get; set; }
}