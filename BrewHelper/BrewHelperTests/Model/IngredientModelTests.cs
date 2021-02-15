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
    public class IngredientModelTests : IDisposable
    {
        private BrewhelperContext context;

        public IngredientModelTests()
        {
            var options = new DbContextOptionsBuilder<BrewhelperContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .EnableSensitiveDataLogging()
                .Options;
            context = new BrewhelperContext(options);
        }

        public void Dispose()
        {
            context.Dispose();
        }

        private void AddIngredient(Ingredient Ingredient)
        {
            context.Ingredients.Add(Ingredient);
            context.SaveChanges();
        }

        [Fact]
        public async Task GetAll_Ingredients_Test()
        {
            AddIngredient(new Ingredient { Name = "Test1" });
            AddIngredient(new Ingredient { Name = "Test2" });

            IngredientModel model = new IngredientModel(context);
            List<Ingredient> result = await model.GetAll();
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async Task GetAll_Empty_Test()
        {
            IngredientModel model = new IngredientModel(context);
            List<Ingredient> result = await model.GetAll();
            Assert.Empty(result);
        }


        [Fact]
        public async Task GetById_Ingredient_Test()
        {
            AddIngredient(new Ingredient { Name = "Test1" });
            Ingredient Ingredient = new Ingredient { Name = "it" };
            AddIngredient(Ingredient);
            AddIngredient(new Ingredient { Name = "Test2" });

            IngredientModel model = new IngredientModel(context);
            Ingredient result = await model.GetIngredientById(Ingredient.Id);
            Assert.Same(Ingredient, result);
        }

        [Fact]
        public async Task GetById_Null_Test()
        {
            AddIngredient(new Ingredient { Name = "Test1" });
            Ingredient Ingredient = new Ingredient { Name = "it" };
            AddIngredient(Ingredient);
            AddIngredient(new Ingredient { Name = "Test2" });

            IngredientModel model = new IngredientModel(context);
            Ingredient result = await model.GetIngredientById(int.MaxValue);
            Assert.Null(result);
        }

        [Fact]
        public async Task AddIngredient_IngredientAdded_Test()
        {
            IngredientModel model = new IngredientModel(context);

            Ingredient Ingredient = new Ingredient { Name = "it" };
            Ingredient result = await model.AddIngredient(Ingredient);
            Assert.Equal(Ingredient, result);
            Assert.Equal(Ingredient, context.Ingredients.First());
        }

        [Fact]
        public async Task AddIngredient_NameExists_Test()
        {
            AddIngredient(new Ingredient { Name = "it" });
            IngredientModel model = new IngredientModel(context);

            Ingredient Ingredient = new Ingredient { Name = "it" };
            Ingredient result = await model.AddIngredient(Ingredient);
            Assert.Null(result);
        }

        [Fact]
        public async Task AddIngredient_null_Test()
        {
            IngredientModel model = new IngredientModel(context);
            Ingredient result = await model.AddIngredient(null);
            Assert.Null(result);
        }

        [Fact]
        public async Task UpdateIngredient_Ingredient_Test()
        {
            Ingredient Ingredient = new Ingredient { Name = "it" };
            AddIngredient(Ingredient);
            IngredientModel model = new IngredientModel(context);

            Ingredient.Description = "Test";
            Ingredient result = await model.UpdateIngredient(Ingredient.Id, Ingredient);
            Assert.Same(Ingredient, result);
        }

        [Fact]
        public async Task UpdateIngredient_DoesntExist_Test()
        {
            Ingredient Ingredient = new Ingredient { Name = "it" };
            IngredientModel model = new IngredientModel(context);

            Ingredient result = await model.UpdateIngredient(1, Ingredient);
            Assert.Null(result);
        }


        [Fact]
        public async Task UpdateIngredient_null_Test()
        {
            Ingredient Ingredient = new Ingredient { Name = "it" };
            AddIngredient(Ingredient);
            IngredientModel model = new IngredientModel(context);
            await Assert.ThrowsAsync<ArgumentNullException>(() => model.UpdateIngredient(Ingredient.Id, null));
        }
    }
}
