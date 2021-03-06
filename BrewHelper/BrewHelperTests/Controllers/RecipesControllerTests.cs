using BrewHelper;
using BrewHelper.Controllers;
using BrewHelper.DTO;
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

            var recipes = JsonConvert.DeserializeObject<GetRecipeListResponseDTO>(await response.Content.ReadAsStringAsync());
            recipes.Items.Should().NotBeEmpty();
            //Related values should be null on multiple
            recipes.Items[0].Mashing.Should().BeNull();
            recipes.Items[0].Boiling.Should().BeNull();
            recipes.Items[0].Yeasting.Should().BeNull();
        }

        [Fact]
        public async Task Get_Should_Retrieve_Limit_Recipes()
        {
            var response = await _client.GetAsync("/api/Recipes?limit=1");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var Recipes = JsonConvert.DeserializeObject<GetRecipeListResponseDTO>(await response.Content.ReadAsStringAsync());
            Recipes.Items.Count.Should().Be(1);
            Recipes.TotalPages.Should().BeGreaterThan(1);
            Recipes.TotalItems.Should().BeGreaterThan(1);
        }

        [Fact]
        public async Task Get_Should_Retrieve_Name_Recipes()
        {
            string name = TestDataSeeder.Recipes.First().Name;
            var response = await _client.GetAsync($"/api/Recipes?Name={name}");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var Recipes = JsonConvert.DeserializeObject<GetRecipeListResponseDTO>(await response.Content.ReadAsStringAsync());
            Recipes.Items.Count.Should().BeGreaterOrEqualTo(1);
            Recipes.Items.First().Name.Should().Contain(name);
        }

        [Fact]
        public async Task Get_Should_Retrieve_Id_Recipes()
        {
            var response = await _client.GetAsync("/api/Recipes?Id=1");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var Recipes = JsonConvert.DeserializeObject<GetRecipeListResponseDTO>(await response.Content.ReadAsStringAsync());
            Recipes.Items.Should().NotBeEmpty();
            Recipes.Items.Count.Should().Be(1);
            Recipes.TotalItems.Should().Be(1);
            Recipes.Items.First().Id.Should().Be(1);
        }

        [Fact]
        public async Task Get_Should_Retrieve_Ids_Recipes()
        {
            var response = await _client.GetAsync("/api/Recipes?Id=1&Id=2");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var Recipes = JsonConvert.DeserializeObject<GetRecipeListResponseDTO>(await response.Content.ReadAsStringAsync());
            Recipes.Items.Should().NotBeEmpty();
            Recipes.Items.Count.Should().Be(2);
            Recipes.TotalItems.Should().Be(2);
        }

        [Fact]
        public async Task Get_Should_Retrieve_Id_BadRequest_Recipes()
        {
            var response = await _client.GetAsync("/api/Recipes?Id=Blabla");
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Get_Should_Retrieve_Pages_Recipes()
        {
            var response1 = await _client.GetAsync("/api/Recipes?limit=1&Page=1");
            response1.StatusCode.Should().Be(HttpStatusCode.OK);

            var RecipesPage1 = JsonConvert.DeserializeObject<GetRecipeListResponseDTO>(await response1.Content.ReadAsStringAsync());
            RecipesPage1.Items.Count.Should().Be(1);
            RecipesPage1.CurrentPage.Should().Be(1);
            RecipeDTO r1 = RecipesPage1.Items.First();

            var response2 = await _client.GetAsync("/api/Recipes?limit=1&Page=2");
            response2.StatusCode.Should().Be(HttpStatusCode.OK);

            var RecipesPage2 = JsonConvert.DeserializeObject<GetRecipeListResponseDTO>(await response2.Content.ReadAsStringAsync());
            RecipesPage2.Items.Count.Should().Be(1);
            RecipesPage2.CurrentPage.Should().Be(2);
            RecipeDTO r2 = RecipesPage2.Items.First();

            Assert.NotEqual<RecipeDTO>(r1, r2);
        }

        [Fact]
        public async Task Get_Should_Retrieve_BadRequest_Pages_Recipes()
        {
            var response1 = await _client.GetAsync("/api/Recipes?Page=dsa");
            response1.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Get_Should_Retrieve_BadRequest_Limit_Recipes()
        {
            var response1 = await _client.GetAsync("/api/Recipes?limit=dsa");
            response1.StatusCode.Should().Be(HttpStatusCode.BadRequest);
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
