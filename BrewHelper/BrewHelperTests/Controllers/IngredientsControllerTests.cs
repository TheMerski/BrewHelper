using BrewHelper.Controllers;
using BrewHelper.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BrewHelperTests.Controllers
{
    public class IngredientsControllerTests : IDisposable
    {
        private Mock<IngredientModel> IngredientModelMock;

        public IngredientsControllerTests()
        {
            IngredientModelMock = new Mock<IngredientModel>();
        }

        public void Dispose()
        {
            IngredientModelMock.Reset();
        }

        [Fact]
        public async Task GetAll_Ingredients_Test()
        {
            List<Ingredient> Ingredients = new List<Ingredient>
            {
                new Ingredient { Id = 2, Name = "TestName" },
                new Ingredient { Id = 3, Name = "TestName2" },
            };
            IngredientModelMock.Setup(m => m.GetAll()).Returns(Task.FromResult<List<Ingredient>>(Ingredients));
            IngredientsController controller = new IngredientsController(IngredientModelMock.Object);

            var result = await controller.GetIngredients();
            Assert.NotEmpty(result.Value);
        }

        [Fact]
        public async Task GetAll_Empty_Test()
        {
            List<Ingredient> Ingredients = new List<Ingredient>();
            IngredientModelMock.Setup(m => m.GetAll()).Returns(Task.FromResult<List<Ingredient>>(Ingredients));
            IngredientsController controller = new IngredientsController(IngredientModelMock.Object);

            var result = await controller.GetIngredients();
            Assert.Empty(result.Value);
        }


        [Fact]
        public async Task GetById_Ingredient_Test()
        {
            int id = 4;
            Ingredient Ingredient = new Ingredient { Id = id, Name = "TestName" };
            IngredientModelMock.Setup(m => m.GetIngredientById(id)).Returns(Task.FromResult<Ingredient>(Ingredient));
            IngredientsController controller = new IngredientsController(IngredientModelMock.Object);

            var result = await controller.GetIngredient(id);
            Assert.Same(Ingredient, result.Value);
        }

        [Fact]
        public async Task GetById_Null_Test()
        {
            int id = 4;
            Ingredient Ingredient = null;
            IngredientModelMock.Setup(m => m.GetIngredientById(id)).Returns(Task.FromResult<Ingredient>(Ingredient));
            IngredientsController controller = new IngredientsController(IngredientModelMock.Object);

            var result = await controller.GetIngredient(id);
            Assert.IsType<NotFoundResult>(result.Result);
        }


        [Fact]
        public async Task CreateAsync_BadModelState_Test()
        {
            IngredientsController controller = new IngredientsController(IngredientModelMock.Object);
            controller.ModelState.AddModelError("test", "test");

            ActionResult<Ingredient> result = await controller.PostIngredient(new Ingredient());

            Assert.IsType<BadRequestResult>(result.Result);
        }

        [Fact]
        public async Task CreateAsync_NameExists_Test()
        {
            string testname = "Testname";

            IngredientsController controller = new IngredientsController(IngredientModelMock.Object);

            ActionResult<Ingredient> result = await controller.PostIngredient(new Ingredient { Id = 0, Name = testname });

            Assert.IsType<ConflictResult>(result.Result);
        }

        [Fact]
        public async Task CreateAsync_Created_Test()
        {
            Ingredient createdIngredient = new Ingredient
            { Id = 2, Name = "Name" };
            IngredientModelMock.Setup(m => m.AddIngredient(createdIngredient))
                .Returns(Task.FromResult<Ingredient>(createdIngredient));

            IngredientsController controller = new IngredientsController(IngredientModelMock.Object);

            ActionResult<Ingredient> result = await controller.PostIngredient(createdIngredient);

            Assert.IsType<CreatedAtActionResult>(result.Result);
        }

        [Fact]
        public async Task UpdateIngredient_BadRequest_Test()
        {
            IngredientsController controller = new IngredientsController(IngredientModelMock.Object);
            Ingredient Ingredient = new Ingredient { Id = 5, Name = "Test" };
            long id = Ingredient.Id + 1;

            IActionResult result = await controller.PutIngredient(id, Ingredient);

            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task UpdateIngredient_NotFound_Test()
        {
            Ingredient Ingredient = new Ingredient { Id = 5, Name = "Test" };
            IngredientModelMock.Setup(m => m.UpdateIngredient(Ingredient.Id, Ingredient))
                .Returns(Task.FromResult<Ingredient>(null));

            IngredientsController controller = new IngredientsController(IngredientModelMock.Object);

            IActionResult result = await controller.PutIngredient(Ingredient.Id, Ingredient);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task UpdateIngredient_Updated_Test()
        {
            Ingredient Ingredient = new Ingredient { Id = 5, Name = "Test" };
            IngredientModelMock.Setup(m => m.UpdateIngredient(Ingredient.Id, Ingredient))
                .Returns(Task.FromResult<Ingredient>(Ingredient));

            IngredientsController controller = new IngredientsController(IngredientModelMock.Object);

            IActionResult result = await controller.PutIngredient(Ingredient.Id, Ingredient);

            Assert.IsType<NoContentResult>(result);
        }
    }
}
