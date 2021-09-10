using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BrewHelper.Entities
{
    public class Recipe
    {
        public long Id { get; set; }
        /// <summary>
        /// Recipe name
        /// </summary>
        [Required]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Recipe Description
        /// </summary>
        public string Description { get; set; } = null!;

        /// <summary>
        /// Expected start SG
        /// </summary>
        public int StartSG { get; set; }
        /// <summary>
        /// Expected end SG
        /// </summary>
        public int EndSG { get; set; }
        /// <summary>
        /// Expected yield (in L)
        /// </summary>
        public int Yield { get; set; }
        /// <summary>
        /// Expected days before beer is ready
        /// </summary>
        public long ReadyAfter { get; set; }
        /// <summary>
        /// Expected alcohol percentage
        /// </summary>
        public double AlcoholPercentage { get; set; }
        /// <summary>
        /// Expected IBU (bitterness)
        /// </summary>
        public double IBU { get; set; }
        /// <summary>
        /// Expected EBC
        /// </summary>
        public double EBC { get; set; }
        /// <summary>
        /// Mashwater to use (in L)
        /// </summary>
        public double MashWater { get; set; }
        /// <summary>
        /// Rinse water before boiling
        /// </summary>
        public double RinseWater { get; set; }
        /// <summary>
        /// Mashing Step for recipe
        /// </summary>
        [Required]
        public RecipeStep Mashing { get; set; } = null!;

        /// <summary>
        /// Boiling Step for recipe
        /// </summary>
        [Required]
        public RecipeStep Boiling { get; set; } = null!;

        /// <summary>
        /// Yeasting Step for recipe
        /// </summary>
        [Required]
        public RecipeStep Yeasting { get; set; } = null!;
    }

    public class RecipeStep
    {
        public long Id { get; set; }
        /// <summary>
        /// Step Description
        /// </summary>
        public string? Description { get; set; }
        /// <summary>
        /// Amount of time for step
        /// </summary>
        public long Time { get; set; }
        /// <summary>
        /// Temperature for step (if applicable)
        /// </summary>
        public double? Temperature { get; set; }
        /// <summary>
        /// Ingredients needed for step (weight in grams)
        /// </summary>
        public List<RecipeIngredient>? Ingredients { get; set; }
        ///// <summary>
        ///// The recipe the step belongs to
        ///// </summary>
    }

    [Owned]
    public class RecipeIngredient
    {
        public long Id { get; set; }
        /// <summary>
        /// The ingredient
        /// </summary>
        [Required]
        public Ingredient Ingredient { get; set; } = null!;

        /// <summary>
        /// The ammount needed (in grams)
        /// </summary>
        [Required]
        public int Weight { get; set; }
        /// <summary>
        /// The amount of time after which the ingredient is to be added
        /// </summary>
        public long AddAfter { get; set; }
    }
}
