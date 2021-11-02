namespace BrewHelper.Data.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.Text.Json.Serialization;

    public class Ingredient
    {
        /// <summary>
        /// Types of ingredients.
        /// </summary>
        public enum IngredientType
        {
            Malt = 0,
            Sugar = 1,
            Hop = 2,
            Yeast = 3,
            Herb = 4
        }

        public long Id { get; set; }

        /// <summary>
        /// Ingredient name.
        /// </summary>
        [Required]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Ingredient description.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Ammount in stock (g).
        /// </summary>
        public long InStock { get; set; }

        /// <summary>
        /// The type of ingredient.
        /// </summary>
        [JsonConverter(typeof(JsonStringEnumConverter))]
        [Required]
        public IngredientType Type { get; set; }
    }
}
