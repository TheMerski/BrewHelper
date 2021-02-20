using BrewHelper.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrewHelper
{
    public class TestDataSeeder
    {
        public static void Seed(IServiceProvider serviceProvider)
        {
            using var context = new BrewhelperContext(
                      serviceProvider
                      .GetRequiredService<DbContextOptions<BrewhelperContext>>());

            SeedIngredients(context);
            SeedRecipes(context);
        }

        private static void SeedIngredients(BrewhelperContext context)
        {
            if (context.Ingredients.Any()) { return; }

            var ingredients = new List<Ingredient>
            {
                new Ingredient {Name= "Hop", Description = "Hopping", Type = Ingredient.IngredientType.Hop},
                new Ingredient {Name= "Herb", Description = "Herb description", Type = Ingredient.IngredientType.Herb},
                new Ingredient {Name= "white malt", Description = "Malt description", Type = Ingredient.IngredientType.Malt},
                new Ingredient {Name= "white sugar", Description = "Sugar description", Type = Ingredient.IngredientType.Sugar},
                new Ingredient {Name= "Yeast", Description = "Yeast description", Type = Ingredient.IngredientType.Yeast}
            };

            context.Ingredients.AddRange(ingredients);

            context.SaveChanges();
        }

        private static void SeedRecipes(BrewhelperContext context)
        {
            if (context.Recipes.Any()) { return; }
            Ingredient testIngredient = new Ingredient { Name = "Test", Description = "test", Type = Ingredient.IngredientType.Hop };
            context.Ingredients.Add(testIngredient);

            var recipes = new List<Recipe>
            {
                new Recipe { Name = "Test recipe", AlcoholPercentage = 2, 
                    Mashing = new RecipeStep {  Ingredients = new List<RecipeIngredient> { new RecipeIngredient { Ingredient = testIngredient, Weight = 10000 } } },
                    Boiling = new RecipeStep {  Ingredients = new List<RecipeIngredient> { new RecipeIngredient { Ingredient = testIngredient, Weight = 200 } } },
                    Yeasting = new RecipeStep { Ingredients = new List<RecipeIngredient> { new RecipeIngredient { Ingredient = testIngredient, Weight = 10000 } } },
                    Description = "Test recipe",
                    EBC = 10, IBU = 10, EndSG = 1050, StartSG = 1080, ReadyAfter =20, MashWater = 20, RinseWater = 27, Yield = 20,
                }
            };

            context.Recipes.AddRange(recipes);

            context.SaveChanges();
        }
    }
}
