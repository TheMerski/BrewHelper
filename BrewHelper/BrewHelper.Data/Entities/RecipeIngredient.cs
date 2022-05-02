using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BrewHelper.Data.Entities;

public class RecipeIngredient<T>
    where T : BrewHelperEntityBase
{
    public RecipeIngredient()
    {
    }

    public RecipeIngredient(T ingredient, double amount, double? time = null)
    {
        this.Ingredient = ingredient;
        this.Amount = amount;
        this.Time = time;
    }

    public T Ingredient { get; set; } = default(T)!;

    /// <summary>
    /// The amount of the ingredient to add (in g).
    /// </summary>
    public double Amount { get; set; } = default!;

    /// <summary>
    /// Optional time to use the ingredient.
    /// </summary>
    public double? Time { get; set; } = default!;
}
