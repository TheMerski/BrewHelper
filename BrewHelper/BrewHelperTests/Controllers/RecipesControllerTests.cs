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
    public class RecipesControllerTests : IDisposable
    {
        private Mock<RecipeModel> recipeModelMock;

        public RecipesControllerTests()
        {
            recipeModelMock = new Mock<RecipeModel>();
        }

        public void Dispose()
        {
            recipeModelMock.Reset();
        }

        [Fact]
        public async Task GetAll_Recipes_Test()
        {
            List<Recipe> recipes = new List<Recipe>
            {
                new Recipe { Id = 2, Name = "TestName" },
                new Recipe { Id = 3, Name = "TestName2" },
            };
            recipeModelMock.Setup(m => m.GetAll()).Returns(Task.FromResult<List<Recipe>>(recipes));
            RecipesController controller = new RecipesController(recipeModelMock.Object);

            var result = await controller.GetAllRecipes();
            Assert.NotEmpty(result.Value);
        }

        [Fact]
        public async Task GetAll_Empty_Test()
        {
            List<Recipe> recipes = new List<Recipe>();
            recipeModelMock.Setup(m => m.GetAll()).Returns(Task.FromResult<List<Recipe>>(recipes));
            RecipesController controller = new RecipesController(recipeModelMock.Object);

            var result = await controller.GetAllRecipes();
            Assert.Empty(result.Value);
        }


        [Fact]
        public async Task GetById_Recipe_Test()
        {
            int id = 4;
            Recipe Recipe = new Recipe { Id = id, Name = "TestName" };
            recipeModelMock.Setup(m => m.GetRecipeById(id)).Returns(Task.FromResult<Recipe>(Recipe));
            RecipesController controller = new RecipesController(recipeModelMock.Object);

            var result = await controller.GetRecipe(id);
            Assert.Same(Recipe, result.Value);
        }

        [Fact]
        public async Task GetById_Null_Test()
        {
            int id = 4;
            Recipe Recipe = null;
            recipeModelMock.Setup(m => m.GetRecipeById(id)).Returns(Task.FromResult<Recipe>(Recipe));
            RecipesController controller = new RecipesController(recipeModelMock.Object);

            var result = await controller.GetRecipe(id);
            Assert.IsType<NotFoundResult>(result.Result);
        }


        [Fact]
        public async Task CreateAsync_BadModelState_Test()
        {
            RecipesController controller = new RecipesController(recipeModelMock.Object);
            controller.ModelState.AddModelError("test", "test");

            ActionResult<Recipe> result = await controller.PostRecipe(new Recipe());

            Assert.IsType<BadRequestResult>(result.Result);
        }

        [Fact]
        public async Task CreateAsync_NameExists_Test()
        {
            string testname = "Testname";

            RecipesController controller = new RecipesController(recipeModelMock.Object);

            ActionResult<Recipe> result = await controller.PostRecipe(new Recipe { Id = 0, Name = testname });

            Assert.IsType<ConflictResult>(result.Result);
        }

        [Fact]
        public async Task CreateAsync_Created_Test()
        {
            Recipe createdRecipe = new Recipe
            { Id = 2, Name = "Name"};
            recipeModelMock.Setup(m => m.AddRecipe(createdRecipe))
                .Returns(Task.FromResult<Recipe>(createdRecipe));

            RecipesController controller = new RecipesController(recipeModelMock.Object);

            ActionResult<Recipe> result = await controller.PostRecipe(createdRecipe);

            Assert.IsType<CreatedAtActionResult>(result.Result);
        }

        [Fact]
        public async Task UpdateRecipe_BadRequest_Test()
        {
            RecipesController controller = new RecipesController(recipeModelMock.Object);
            Recipe Recipe = new Recipe { Id = 5, Name = "Test" };
            long id = Recipe.Id + 1;

            IActionResult result = await controller.PutRecipe(id, Recipe);

            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task UpdateRecipe_NotFound_Test()
        {
            Recipe Recipe = new Recipe { Id = 5, Name = "Test" };
            recipeModelMock.Setup(m => m.UpdateRecipe(Recipe.Id, Recipe))
                .Returns(Task.FromResult<Recipe>(null));

            RecipesController controller = new RecipesController(recipeModelMock.Object);

           IActionResult result = await controller.PutRecipe(Recipe.Id, Recipe);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task UpdateRecipe_Updated_Test()
        {
            Recipe Recipe = new Recipe { Id = 5, Name = "Test" };
            recipeModelMock.Setup(m => m.UpdateRecipe(Recipe.Id, Recipe))
                .Returns(Task.FromResult<Recipe>(Recipe));

            RecipesController controller = new RecipesController(recipeModelMock.Object);

            IActionResult result = await controller.PutRecipe(Recipe.Id, Recipe);

            Assert.IsType<NoContentResult>(result);
        }
    }
}
