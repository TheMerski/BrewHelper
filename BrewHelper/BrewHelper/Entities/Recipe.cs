using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BrewHelper.Models
{
    public class Recipe
    {
        public long Id { get; set; }
        /// <summary>
        /// Recipe name
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Recipe Description
        /// </summary>
        public string Description { get; set; }
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
        public RecipeStep Mashing { get; set; }
        /// <summary>
        /// Boiling Step for recipe
        /// </summary>
        [Required]
        public RecipeStep Boiling { get; set; }        
        /// <summary>
        /// Yeasting Step for recipe
        /// </summary>
        [Required]
        public RecipeStep Yeasting { get; set; }
    }

    public class RecipeStep
    {
        public long Id { get; set; }
        /// <summary>
        /// Step Description
        /// </summary>
        public string Description { get; set; }
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
        public List<RecipeIngredient> Ingredients { get; set; }
        ///// <summary>
        ///// The recipe the step belongs to
        ///// </summary>
        //[JsonIgnore]
        //public Recipe Recipe { get; set; }
    }

    [Owned]
    public class RecipeIngredient
    {
        public long Id { get; set; }
        /// <summary>
        /// The ingredient
        /// </summary>
        [Required]
        public Ingredient Ingredient { get; set; }
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
