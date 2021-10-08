using BrewHelper.Entities;
using BrewHelper.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BrewHelper
{
    public class InitialDataSeeder
    {
        public static void Seed(IServiceProvider serviceProvider)
        {
            using var context = new BrewhelperContext(
                      serviceProvider
                      .GetRequiredService<DbContextOptions<BrewhelperContext>>());

            SeedIngredients(context);
            SeedRecipes(context);
            SeedBrewLogs(context);
        }

        private static void SeedIngredients(BrewhelperContext context)
        {
            if (context.Ingredients.Any()) { return; }

            var ingredients = new List<Ingredient>
            {
                new Ingredient {Name= "Hop", Description = "Hopping", Type = Ingredient.IngredientType.Hop, InStock = 50},
                new Ingredient {Name= "Herb", Description = "Herb description", Type = Ingredient.IngredientType.Herb},
                new Ingredient {Name= "white malt", Description = "Malt description", Type = Ingredient.IngredientType.Malt, InStock = 2000},
                new Ingredient {Name= "white sugar", Description = "Sugar description", Type = Ingredient.IngredientType.Sugar},
                new Ingredient {Name= "Yeast", Description = "Yeast description", Type = Ingredient.IngredientType.Yeast}
            };

            context.Ingredients.AddRange(ingredients);

            context.SaveChanges();
        }

        private static void SeedRecipes(BrewhelperContext context)
        {
            if (context.Recipes.Any()) { return; }

            var ingredient = context.Ingredients.OrderBy(i => i.Id).First();

            var recipes = new List<Recipe>
            {
                new Recipe { Name = "Test recipe", AlcoholPercentage = 2, 
                    Mashing = new RecipeStep {  Ingredients = new List<RecipeIngredient> { new RecipeIngredient { Ingredient = ingredient, Weight = 10000 } } },
                    Boiling = new RecipeStep {  Ingredients = new List<RecipeIngredient> { new RecipeIngredient { Ingredient = ingredient, Weight = 200 } } },
                    Yeasting = new RecipeStep { Ingredients = new List<RecipeIngredient> { new RecipeIngredient { Ingredient = ingredient, Weight = 10000 } } },
                    Description = "Test recipe",
                    EBC = 10, IBU = 10, EndSG = 1050, StartSG = 1080, ReadyAfter =20, MashWater = 20, RinseWater = 27, Yield = 20,
                }
            };

            context.Recipes.AddRange(recipes);

            context.SaveChanges();
        }

        private static void SeedBrewLogs(BrewhelperContext context)
        {
            if (context.BrewLogs.Any()) {return;}

            var recipe = context.Recipes.OrderBy(r => r.Id).First();

            var logs = new List<BrewLog>()
            {
                new BrewLog
                {
                    Notes = "Completed log", Yield = 20, AlcoholPercentage = 10.2,
                    StartDate = DateTime.UtcNow.Subtract(new TimeSpan(20, 0, 0, 0)),
                    EndDate = DateTime.UtcNow.Subtract(new TimeSpan(1, 0, 0, 0)), RecipeId = recipe.Id, EBC = 10,
                    IBU = 15, StartSG = 1040, EndSG = 1050,
                    MashingLog = new StepLog
                    {
                        Notes = "Mashing it up", Start = DateTime.UtcNow.Subtract(new TimeSpan(20, 0, 0, 0)),
                        End = DateTime.UtcNow.Subtract(new TimeSpan(19, 22, 30, 0)),
                        PhMeasurements = new List<Measurement>
                        {
                            new Measurement
                            {
                                Notes = "Ph value", Value = 6.5,
                                Time = DateTime.UtcNow.Subtract(new TimeSpan(19, 23, 0, 0))
                            }
                        },
                        SgMeasurements = new List<Measurement>(),
                        TemperatureMeasurements = new List<Measurement>
                        {
                            new Measurement
                            {
                                Notes = "Temp", Value = 78, Time = DateTime.UtcNow.Subtract(new TimeSpan(19, 23, 0, 0))
                            }
                        }
                    },
                    BoilingLog = new StepLog
                    {
                        Start = DateTime.UtcNow.Subtract(new TimeSpan(19, 22, 30, 0)),
                        End = DateTime.UtcNow.Subtract(new TimeSpan(19, 21, 30, 0)),
                        Notes = "It was cooking",
                        PhMeasurements = new List<Measurement>
                        {
                            new Measurement
                            {
                                Notes = "correct", Value = 7.0,
                                Time = DateTime.UtcNow.Subtract(new TimeSpan(19, 22, 15, 0))
                            }
                        },
                        SgMeasurements = new List<Measurement>(),
                        TemperatureMeasurements = new List<Measurement>()
                    },
                    YeastingLog = new StepLog
                    {
                        Start = DateTime.UtcNow.Subtract(new TimeSpan(19, 21, 30, 0)),
                        End = DateTime.UtcNow.Subtract(new TimeSpan(1, 1, 0, 0)),
                        Notes = "yeastie",
                        PhMeasurements = new List<Measurement>(),
                        SgMeasurements = new List<Measurement>
                        {
                            new Measurement
                            {
                                Notes = "start", Value = 1040,
                                Time = DateTime.UtcNow.Subtract(new TimeSpan(19, 21, 30, 0))
                            },
                            new Measurement
                            {
                                Notes = "End", Value = 1050,
                                Time = DateTime.UtcNow.Subtract(new TimeSpan(1, 1, 0, 0))
                            }
                        },
                        TemperatureMeasurements = new List<Measurement>
                        {
                            new Measurement
                            {
                                Notes = "start", Value = 20,
                                Time = DateTime.UtcNow.Subtract(new TimeSpan(19, 21, 30, 0))
                            },
                            new Measurement
                            {
                                Notes = "middle", Value = 21,
                                Time = DateTime.UtcNow.Subtract(new TimeSpan(10, 21, 30, 0))
                            },
                            new Measurement
                            {
                                Notes = "End", Value = 22,
                                Time = DateTime.UtcNow.Subtract(new TimeSpan(1, 1, 0, 0))
                            }
                        }
                    }
                }
            };
            
            context.BrewLogs.AddRange(logs);
            context.SaveChanges();
        }
    }
}
