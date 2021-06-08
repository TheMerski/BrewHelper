using BrewHelper.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrewHelper
{
    public static class TestDataSeeder
    {
        public static List<Ingredient> Ingredients = new List<Ingredient>
            {
                new Ingredient {Name= "Hop", Description = "Hopping", Type = Ingredient.IngredientType.Hop, InStock = 200},
                new Ingredient {Name= "Herb", Description = "Herb description", Type = Ingredient.IngredientType.Herb, InStock = 200},
                new Ingredient {Name= "white malt", Description = "Malt description", Type = Ingredient.IngredientType.Malt, InStock = 5000},
                new Ingredient {Name= "white sugar", Description = "Sugar description", Type = Ingredient.IngredientType.Sugar, InStock = 200},
                new Ingredient {Name= "Yeast", Description = "Yeast description", Type = Ingredient.IngredientType.Yeast, InStock = 2},
                new Ingredient { Name = "Test", Description = "test", Type = Ingredient.IngredientType.Hop },
                new Ingredient { Name = "Test 2", Description = "test", Type = Ingredient.IngredientType.Hop }
            };

        public static List<Recipe> Recipes = new List<Recipe>
            {
                new Recipe { Name = "Test recipe", AlcoholPercentage = 2,
                    Mashing = new RecipeStep {  Ingredients = new List<RecipeIngredient> { new RecipeIngredient { Ingredient = Ingredients.Last(), Weight = 10000 } } },
                    Boiling = new RecipeStep {  Ingredients = new List<RecipeIngredient> { new RecipeIngredient { Ingredient = Ingredients.Last(), Weight = 200 } } },
                    Yeasting = new RecipeStep { Ingredients = new List<RecipeIngredient> { new RecipeIngredient { Ingredient = Ingredients.Last(), Weight = 10000 } } },
                    Description = "None instock",
                    EBC = 10, IBU = 10, EndSG = 1050, StartSG = 1080, ReadyAfter =20, MashWater = 20, RinseWater = 27, Yield = 20,
                },
                new Recipe { Name = "Test recipe 2", AlcoholPercentage = 2,
                    Mashing = new RecipeStep {  Ingredients = new List<RecipeIngredient> { new RecipeIngredient { Ingredient = Ingredients[0], Weight = 10 }, new RecipeIngredient { Ingredient = Ingredients[2], Weight = 20 } } },
                    Boiling = new RecipeStep {  Ingredients = new List<RecipeIngredient> { new RecipeIngredient { Ingredient = Ingredients[1], Weight = 200 }, new RecipeIngredient { Ingredient = Ingredients[2], Weight = 20 } } },
                    Yeasting = new RecipeStep { Ingredients = new List<RecipeIngredient> { new RecipeIngredient { Ingredient = Ingredients[2], Weight = 1000 }, new RecipeIngredient { Ingredient = Ingredients[3], Weight = 20 } } },
                    Description = "All instock",
                    EBC = 10, IBU = 10, EndSG = 1050, StartSG = 1080, ReadyAfter =20, MashWater = 20, RinseWater = 27, Yield = 20,
                },
                new Recipe { Name = "Recipe 3", AlcoholPercentage = 2,
                    Mashing = new RecipeStep {  Ingredients = new List<RecipeIngredient> { new RecipeIngredient { Ingredient = Ingredients[0], Weight = 10 }, new RecipeIngredient { Ingredient = Ingredients[3], Weight = 20 } } },
                    Boiling = new RecipeStep {  Ingredients = new List<RecipeIngredient> { new RecipeIngredient { Ingredient = Ingredients[1], Weight = 200 } } },
                    Yeasting = new RecipeStep { Ingredients = new List<RecipeIngredient> { new RecipeIngredient { Ingredient = Ingredients[2], Weight = 1000 } } },
                    Description = "Mash not instock",
                    EBC = 10, IBU = 10, EndSG = 1050, StartSG = 1080, ReadyAfter =20, MashWater = 20, RinseWater = 27, Yield = 20,
                },
                new Recipe { Name = "Recipe 4", AlcoholPercentage = 2,
                    Mashing = new RecipeStep {  Ingredients = new List<RecipeIngredient> { new RecipeIngredient { Ingredient = Ingredients[0], Weight = 10 }, new RecipeIngredient { Ingredient = Ingredients[3], Weight = 20 } } },
                    Boiling = new RecipeStep {  Ingredients = new List<RecipeIngredient> { new RecipeIngredient { Ingredient = Ingredients[1], Weight = 200000 } } },
                    Yeasting = new RecipeStep { Ingredients = new List<RecipeIngredient> { new RecipeIngredient { Ingredient = Ingredients[2], Weight = 10 } } },
                    Description = "Boil not instock",
                    EBC = 10, IBU = 10, EndSG = 1050, StartSG = 1080, ReadyAfter =20, MashWater = 20, RinseWater = 27, Yield = 20,
                },
                new Recipe { Name = "Recipe 5", AlcoholPercentage = 2,
                    Mashing = new RecipeStep {  Ingredients = new List<RecipeIngredient> { new RecipeIngredient { Ingredient = Ingredients[0], Weight = 10 }, new RecipeIngredient { Ingredient = Ingredients[3], Weight = 20 } } },
                    Boiling = new RecipeStep {  Ingredients = new List<RecipeIngredient> { new RecipeIngredient { Ingredient = Ingredients[1], Weight = 200 } } },
                    Yeasting = new RecipeStep { Ingredients = new List<RecipeIngredient> { new RecipeIngredient { Ingredient = Ingredients[2], Weight = 1000000 } } },
                    Description = "Yeast not instock",
                    EBC = 10, IBU = 10, EndSG = 1050, StartSG = 1080, ReadyAfter =20, MashWater = 20, RinseWater = 27, Yield = 20,
                }
            };

        public static void Seed(BrewhelperContext context)
        {
            SeedIngredients(context);
            SeedRecipes(context);
        }

        private static void SeedIngredients(BrewhelperContext context)
        {
            if (context.Ingredients.Any()) { return; }
            context.Ingredients.AddRange(Ingredients);
            context.SaveChanges();
        }

        private static void SeedRecipes(BrewhelperContext context)
        {
            if (context.Recipes.Any()) { return; }
            context.Recipes.AddRange(Recipes);
            context.SaveChanges();
        }
    }
}
