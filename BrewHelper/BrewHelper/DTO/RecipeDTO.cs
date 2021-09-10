using BrewHelper.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BrewHelper.Models
{
    public class RecipeDTO
    {
        public RecipeDTO()
        {

        }

        public RecipeDTO(Recipe recipe)
        {
            Id = recipe.Id;
            Name = recipe.Name;
            Description = recipe.Description;
            StartSG = recipe.StartSG;
            EndSG = recipe.EndSG;
            Yield = recipe.Yield;
            ReadyAfter = recipe.ReadyAfter;
            AlcoholPercentage = recipe.AlcoholPercentage;
            IBU = recipe.IBU;
            EBC = recipe.EBC;
            MashWater = recipe.MashWater;
            RinseWater = recipe.RinseWater;
            if (recipe.Mashing != null) Mashing = new RecipeStepDTO(recipe.Mashing);
            if (recipe.Boiling != null) Boiling = new RecipeStepDTO(recipe.Boiling);
            if (recipe.Yeasting != null) Yeasting = new RecipeStepDTO(recipe.Yeasting);
        }

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
        public RecipeStepDTO Mashing { get; set; } = null!;

        /// <summary>
        /// Boiling Step for recipe
        /// </summary>
        [Required]
        public RecipeStepDTO Boiling { get; set; } = null!;

        /// <summary>
        /// Yeasting Step for recipe
        /// </summary>
        [Required]
        public RecipeStepDTO Yeasting { get; set; } = null!;
    }

    public class RecipeStepDTO
    {
        public RecipeStepDTO()
        {
            Ingredients = new List<RecipeIngredientDTO>();
        }
        public RecipeStepDTO(RecipeStep step)
        {
            Id = step.Id;
            Description = step.Description;
            Time = step.Time;
            Ingredients = new List<RecipeIngredientDTO>();
            if (step.Ingredients != null)
                step.Ingredients.ForEach(i => { Ingredients.Add(new RecipeIngredientDTO(i)); });
        }
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
        public List<RecipeIngredientDTO> Ingredients { get; set; }
        ///// <summary>
        ///// The recipe the step belongs to
        ///// </summary>
        //[JsonIgnore]
        //public Recipe Recipe { get; set; }
    }

    [Owned]
    public class RecipeIngredientDTO
    {
        public RecipeIngredientDTO()
        {

        }
        public RecipeIngredientDTO(RecipeIngredient rIngredient)
        {
            Id = rIngredient.Id;
            IngredientId = rIngredient.Ingredient.Id;
            InStock = rIngredient.Ingredient.InStock;
            Weight = rIngredient.Weight;
            AddAfter = rIngredient.AddAfter;
        }
        public long Id { get; set; }
        /// <summary>
        /// The ingredient
        /// </summary>
        [Required]
        public long IngredientId { get; set; }
        /// <summary>
        /// Ammount of ingredient in stock (in grams)
        /// </summary>
        public long InStock { get; set; }
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
