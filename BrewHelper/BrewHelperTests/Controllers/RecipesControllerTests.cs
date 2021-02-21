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
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BrewHelperTests.Controllers
{
    public class RecipesControllerTests : IntegrationTest
    {
        public RecipesControllerTests(BrewHelperWebApplicationFactory fixture)
      : base(fixture) { }

        [Fact]
        public async Task Get_Should_Retrieve_Recipes()
        {
            var response = await _client.GetAsync("/api/Recipes");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var recipes = JsonConvert.DeserializeObject<RecipeDTO[]>(await response.Content.ReadAsStringAsync());
            recipes.Should().NotBeEmpty();
            //Related values should be null on multiple
            recipes[0].Mashing.Should().BeNull();
            recipes[0].Boiling.Should().BeNull();
            recipes[0].Yeasting.Should().BeNull();
        }

        [Fact]
        public async Task Get_Should_Retrieve_Recipe()
        {
            var response = await _client.GetAsync("/api/Recipes/1");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var recipe = JsonConvert.DeserializeObject<RecipeDTO>(await response.Content.ReadAsStringAsync());
            recipe.Should().BeOfType<RecipeDTO>();
            //Related values should not be null on single
            recipe.Mashing.Should().NotBeNull();
            recipe.Boiling.Should().NotBeNull();
            recipe.Yeasting.Should().NotBeNull();

            //Related value ingredients should be filled
            recipe.Mashing.Ingredients.Should().NotBeEmpty();
            recipe.Boiling.Ingredients.Should().NotBeEmpty();
            recipe.Yeasting.Ingredients.Should().NotBeEmpty();
        }

        [Fact]
        public async Task Get_Should_Retrieve_NotFound()
        {
            var response = await _client.GetAsync("/api/Recipes/99999999");
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task Get_Should_Retrieve_BadRequest()
        {
            var response = await _client.GetAsync("/api/Recipes/Test");
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Put_Should_Update_Recipe()
        {
            var recipeResponse = await _client.GetAsync("/api/Recipes/1");
            RecipeDTO recipe = JsonConvert.DeserializeObject<RecipeDTO>(await recipeResponse.Content.ReadAsStringAsync());

            string newStepDescString = "This is a new description";
            double newAlcholPercentage = 85.5;
            int newStepIngWeight = int.MaxValue;

            recipe.AlcoholPercentage = newAlcholPercentage;
            recipe.Mashing.Description = newStepDescString;
            recipe.Boiling.Description = newStepDescString;
            recipe.Yeasting.Description = newStepDescString;
            recipe.Mashing.Ingredients[0].Weight = newStepIngWeight;
            recipe.Boiling.Ingredients[0].Weight = newStepIngWeight;
            recipe.Yeasting.Ingredients[0].Weight = newStepIngWeight;

            var json = JsonConvert.SerializeObject(recipe);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, MediaTypeNames.Application.Json);

            var response = await _client.PutAsync("/api/Recipes/1", stringContent);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            RecipeDTO returnedRecipe = JsonConvert.DeserializeObject<RecipeDTO>(await response.Content.ReadAsStringAsync());

            returnedRecipe.Should().BeOfType<RecipeDTO>();

            returnedRecipe.AlcoholPercentage.Should().Be(newAlcholPercentage);
            returnedRecipe.Mashing.Description.Should().Be(newStepDescString);
            returnedRecipe.Boiling.Description.Should().Be(newStepDescString);
            returnedRecipe.Yeasting.Description.Should().Be(newStepDescString);
            returnedRecipe.Mashing.Ingredients[0].Weight.Should().Be(newStepIngWeight);
            returnedRecipe.Boiling.Ingredients[0].Weight.Should().Be(newStepIngWeight);
            returnedRecipe.Yeasting.Ingredients[0].Weight.Should().Be(newStepIngWeight);
        }

        [Fact]
        public async Task Put_Should_Return_BadRequest()
        {
            var recipeResponse = await _client.GetAsync("/api/Recipes/1");
            RecipeDTO recipe = JsonConvert.DeserializeObject<RecipeDTO>(await recipeResponse.Content.ReadAsStringAsync());

            recipe.Description = "new";

            var json = JsonConvert.SerializeObject(recipe);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, MediaTypeNames.Application.Json);

            var response = await _client.PutAsync("/api/Recipes/2", stringContent);
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Put_Should_Return_NotFound()
        {
            var recipeResponse = await _client.GetAsync("/api/Recipes/1");
            RecipeDTO recipe = JsonConvert.DeserializeObject<RecipeDTO>(await recipeResponse.Content.ReadAsStringAsync());

            recipe.Id = long.MaxValue;

            var json = JsonConvert.SerializeObject(recipe);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, MediaTypeNames.Application.Json);

            var response = await _client.PutAsync($"/api/Recipes/{long.MaxValue}", stringContent);
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task Post_Should_Return_Created()
        {
            RecipeDTO newRecipe = new RecipeDTO
            {
                Name = "new Test recipe",
                AlcoholPercentage = 2,
                Mashing = new RecipeStepDTO { Ingredients = null },
                Boiling = new RecipeStepDTO { Ingredients = null },
                Yeasting = new RecipeStepDTO { Ingredients =null },
                Description = "new test recipe 2",
                EBC = 10,
                IBU = 10,
                EndSG = 1050,
                StartSG = 1080,
                ReadyAfter = 20,
                MashWater = 20,
                RinseWater = 27,
                Yield = 20,
            };

            var json = JsonConvert.SerializeObject(newRecipe);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, MediaTypeNames.Application.Json);

            var response = await _client.PostAsync($"/api/Recipes", stringContent);
            response.StatusCode.Should().Be(HttpStatusCode.Created);
            RecipeDTO recipe = JsonConvert.DeserializeObject<RecipeDTO>(await response.Content.ReadAsStringAsync());
            recipe.Name.Should().Be(newRecipe.Name);
            recipe.Id.Should().NotBe(0);
            recipe.Mashing.Should().NotBeNull();
            recipe.Boiling.Should().NotBeNull();
            recipe.Yeasting.Should().NotBeNull();
        }

        [Fact]
        public async Task Post_Should_Return_Conflict()
        {
            RecipeDTO newRecipe = new RecipeDTO
            {
                Name = "Test recipe",
                AlcoholPercentage = 2,
                Mashing = new RecipeStepDTO { Ingredients = null },
                Boiling = new RecipeStepDTO { Ingredients = null },
                Yeasting = new RecipeStepDTO { Ingredients = null },
                Description = "new test recipe 2",
                EBC = 10,
                IBU = 10,
                EndSG = 1050,
                StartSG = 1080,
                ReadyAfter = 20,
                MashWater = 20,
                RinseWater = 27,
                Yield = 20,
            };

            var json = JsonConvert.SerializeObject(newRecipe);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, MediaTypeNames.Application.Json);

            var response = await _client.PostAsync($"/api/Recipes", stringContent);
            response.StatusCode.Should().Be(HttpStatusCode.Conflict);
        }

        [Fact]
        public async Task Post_Should_Return_BadRequest()
        {
            RecipeDTO newRecipe = new RecipeDTO
            {
                AlcoholPercentage = 2,
                Mashing = new RecipeStepDTO { Ingredients = null },
                Boiling = new RecipeStepDTO { Ingredients = null },
                Yeasting = new RecipeStepDTO { Ingredients = null },
                Description = "new test recipe 2",
                EBC = 10,
                IBU = 10,
                EndSG = 1050,
                StartSG = 1080,
                ReadyAfter = 20,
                MashWater = 20,
                RinseWater = 27,
                Yield = 20,
            };

            var json = JsonConvert.SerializeObject(newRecipe);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, MediaTypeNames.Application.Json);

            var response = await _client.PostAsync($"/api/Recipes", stringContent);
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }


        [Fact]
        public async Task Delete_Should_Return_Delete()
        {
            RecipeDTO newRecipe = new RecipeDTO
            {
                Name = "delete Test recipe",
                AlcoholPercentage = 2,
                Mashing = new RecipeStepDTO { Ingredients = null },
                Boiling = new RecipeStepDTO { Ingredients = null },
                Yeasting = new RecipeStepDTO { Ingredients = null },
                Description = "new test recipe 2",
                EBC = 10,
                IBU = 10,
                EndSG = 1050,
                StartSG = 1080,
                ReadyAfter = 20,
                MashWater = 20,
                RinseWater = 27,
                Yield = 20,
            };

            var json = JsonConvert.SerializeObject(newRecipe);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, MediaTypeNames.Application.Json);

            var response = await _client.PostAsync("/api/Recipes", stringContent);
            RecipeDTO recipe = JsonConvert.DeserializeObject<RecipeDTO>(await response.Content.ReadAsStringAsync());

            var deleteResponse = await _client.DeleteAsync($"/api/Recipes/{recipe.Id}");
            deleteResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var doubleDeleteResponse = await _client.DeleteAsync($"/api/Recipes/{recipe.Id}");
            doubleDeleteResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}
