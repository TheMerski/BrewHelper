using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrewHelper.Data.Entities;

using Microsoft.EntityFrameworkCore;

public enum HopUse
{
    Boil,
    Dry_Hop,
    Mash,
    First_Wort,
    Aroma
}

[Owned]
public class HopIngredient : RecipeIngredient<Hop>
{
    public HopIngredient()
    {
    }

    public HopIngredient(Hop ingredient, HopUse use, double amount, double? time = null)
        : base(ingredient, amount, time)
    {
        this.Use = use;
    }

    public HopUse Use { get; set; }
}
