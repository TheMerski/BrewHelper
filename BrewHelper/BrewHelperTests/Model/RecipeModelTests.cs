using BrewHelper.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BrewHelperTests.Model
{
    public class RecipeModelTests : IDisposable
    {
        private RecipeContext context;

        public RecipeModelTests()
        {
            var options = new DbContextOptionsBuilder<RecipeContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .EnableSensitiveDataLogging()
                .Options;
            context = new RecipeContext(options);
        }

        public void Dispose()
        {
            context.Dispose();
        }

        private void AddRecipe(Recipe recipe)
        {
            context.Recipes.Add(recipe);
            context.SaveChanges();
        }

        [Fact]
        public async Task GetAll_Recipes_Test()
        {
            AddRecipe(new Recipe { Name = "Test1" });
            AddRecipe(new Recipe { Name = "Test2" });

            RecipeModel model = new RecipeModel(context);
            List<Recipe> result = await model.GetAll();
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async Task GetAll_Empty_Test()
        {
            RecipeModel model = new RecipeModel(context);
            List<Recipe> result = await model.GetAll();
            Assert.Empty(result);
        }


        [Fact]
        public async Task GetById_Recipe_Test()
        {
            AddRecipe(new Recipe { Name = "Test1" });
            Recipe recipe = new Recipe { Name = "it"};
            AddRecipe(recipe);
            AddRecipe(new Recipe { Name = "Test2" });

            RecipeModel model = new RecipeModel(context);
            Recipe result = await model.GetRecipeById(recipe.Id);
            Assert.Same(recipe, result);
        }

        [Fact]
        public async Task GetById_Null_Test()
        {
            AddRecipe(new Recipe { Name = "Test1" });
            Recipe recipe = new Recipe { Name = "it" };
            AddRecipe(recipe);
            AddRecipe(new Recipe { Name = "Test2" });

            RecipeModel model = new RecipeModel(context);
            Recipe result = await model.GetRecipeById(int.MaxValue);
            Assert.Null(result);
        }

        [Fact]
        public async Task AddRecipe_RecipeAdded_Test()
        {
            RecipeModel model = new RecipeModel(context);

            Recipe recipe = new Recipe { Name = "it" };
            Recipe result = await model.AddRecipe(recipe);
            Assert.Equal(recipe, result);
            Assert.Equal(recipe, context.Recipes.First());
        }

        [Fact]
        public async Task AddRecipe_NameExists_Test()
        {
            AddRecipe(new Recipe { Name = "it" });
            RecipeModel model = new RecipeModel(context);

            Recipe recipe = new Recipe { Name = "it" };
            Recipe result = await model.AddRecipe(recipe);
            Assert.Null(result);
        }

        [Fact]
        public async Task AddRecipe_null_Test()
        {
            RecipeModel model = new RecipeModel(context);
            Recipe result = await model.AddRecipe(null);
            Assert.Null(result);
        }

        [Fact]
        public async Task UpdateRecipe_Recipe_Test()
        {
            Recipe recipe = new Recipe { Name = "it" };
            AddRecipe(recipe);
            RecipeModel model = new RecipeModel(context);

            recipe.Description = "Test";
            Recipe result = await model.UpdateRecipe(recipe.Id ,recipe);
            Assert.Same(recipe, result);
        }

        [Fact]
        public async Task UpdateRecipe_DoesntExist_Test()
        {
            Recipe recipe = new Recipe { Name = "it" };
            RecipeModel model = new RecipeModel(context);

            Recipe result = await model.UpdateRecipe(1, recipe);
            Assert.Null(result);
        }


        [Fact]
        public async Task UpdateRecipe_null_Test()
        {
            Recipe recipe = new Recipe { Name = "it" };
            AddRecipe(recipe);
            RecipeModel model = new RecipeModel(context);
            await Assert.ThrowsAsync<ArgumentNullException>(() => model.UpdateRecipe(recipe.Id, null));
        }
    }
}
