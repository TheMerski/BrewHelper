using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BrewHelper.Models
{
    public class Ingredient
    {
        public long Id { get; set; }

        /// <summary>
        /// Ingredient name
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Ingredient description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The type of ingredient
        /// </summary>
        [JsonConverter(typeof(JsonStringEnumConverter))]
        [Required]
        public IngredientType Type { get; set; }


        /// <summary>
        /// Types of ingredients
        /// </summary>
        public enum IngredientType
        {
            Malt = 0,
            Sugar = 1,
            Hop = 2,
            Yeast = 3,
            Herb = 4
        }
    }
}
