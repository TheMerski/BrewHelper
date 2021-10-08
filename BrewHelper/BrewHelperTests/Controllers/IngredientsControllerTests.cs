using BrewHelper.DTO;
using BrewHelper.Entities;
using FluentAssertions;
using Newtonsoft.Json;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BrewHelperTests.Controllers
{
    public class IngredientsControllerTests : IntegrationTest
    {
        public IngredientsControllerTests(BrewHelperWebApplicationFactory fixture)
      : base(fixture) { }

        [Fact]
        public async Task Unauthorized_Get_Should_Be_Unauthorized()
        {
            var response = await _unauthorizedClient.GetAsync("/api/Ingredients");
            response.StatusCode.Should().Be(HttpStatusCode.Unauthorized);
        }

        [Fact]
        public async Task Get_Admin_Should_Retrieve_Ingredients()
        {
            var response = await _adminClient.GetAsync("/api/Ingredients");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var Ingredients = JsonConvert.DeserializeObject<GenericListResponseDTO<Ingredient>>(await response.Content.ReadAsStringAsync());
            Ingredients.Items.Should().NotBeEmpty();
        }

        [Fact]
        public async Task Get_Should_Retrieve_Ingredients()
        {
            var response = await _userClient.GetAsync("/api/Ingredients");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var Ingredients = JsonConvert.DeserializeObject<GenericListResponseDTO<Ingredient>>(await response.Content.ReadAsStringAsync());
            Ingredients.Items.Should().NotBeEmpty();
        }

        [Fact]
        public async Task Get_Should_Retrieve_Limit_Ingredients()
        {
            var response = await _userClient.GetAsync("/api/Ingredients?limit=2");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var Ingredients = JsonConvert.DeserializeObject<GenericListResponseDTO<Ingredient>>(await response.Content.ReadAsStringAsync());
            Ingredients.Items.Count.Should().Be(2);
            Ingredients.TotalPages.Should().BeGreaterThan(1);
            Ingredients.TotalItems.Should().BeGreaterThan(2);
        }


        [Fact]
        public async Task Get_Should_Retrieve_Pages_Ingredients()
        {
            var response1 = await _userClient.GetAsync("/api/Ingredients?limit=1&Page=1");
            response1.StatusCode.Should().Be(HttpStatusCode.OK);

            var IngredientsPage1 = JsonConvert.DeserializeObject<GenericListResponseDTO<Ingredient>>(await response1.Content.ReadAsStringAsync());
            IngredientsPage1.Items.Count.Should().Be(1);
            IngredientsPage1.CurrentPage.Should().Be(1);
            Ingredient ing1 = IngredientsPage1.Items.First();

            var response2 = await _userClient.GetAsync("/api/Ingredients?limit=1&Page=2");
            response2.StatusCode.Should().Be(HttpStatusCode.OK);

            var IngredientsPage2 = JsonConvert.DeserializeObject<GenericListResponseDTO<Ingredient>>(await response2.Content.ReadAsStringAsync());
            IngredientsPage2.Items.Count.Should().Be(1);
            IngredientsPage2.CurrentPage.Should().Be(2);
            Ingredient ing2 = IngredientsPage2.Items.First();

            Assert.NotEqual<Ingredient>(ing1, ing2);
        }

        [Fact]
        public async Task Get_Should_Retrieve_BadRequest_Pages_Ingredients()
        {
            var response1 = await _userClient.GetAsync("/api/Ingredients?Page=dsa");
            response1.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Get_Should_Retrieve_BadRequest_Limit_Ingredients()
        {
            var response1 = await _userClient.GetAsync("/api/Ingredients?limit=dsa");
            response1.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Get_Should_Retrieve_Name_Ingredients()
        {
            var response = await _userClient.GetAsync("/api/Ingredients?Name=Hop");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var Ingredients = JsonConvert.DeserializeObject<GenericListResponseDTO<Ingredient>>(await response.Content.ReadAsStringAsync());
            Ingredients.Items.Should().NotBeEmpty();
            Ingredients.Items.First().Name.Should().Be("Hop");
        }

        [Fact]
        public async Task Get_Should_Retrieve_Type_Ingredients()
        {
            var response = await _userClient.GetAsync("/api/Ingredients?Types=Hop");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var Ingredients = JsonConvert.DeserializeObject<GenericListResponseDTO<Ingredient>>(await response.Content.ReadAsStringAsync());
            Ingredients.Items.Should().NotBeEmpty();
            Ingredients.Items.First().Type.Should().Be(Ingredient.IngredientType.Hop);
        }

        [Fact]
        public async Task Get_Should_Retrieve_Types_Ingredients()
        {
            var response = await _userClient.GetAsync("/api/Ingredients?Types=Hop&Types=Herb");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var Ingredients = JsonConvert.DeserializeObject<GenericListResponseDTO<Ingredient>>(await response.Content.ReadAsStringAsync());
            Ingredients.Items.Should().NotBeEmpty();
            Ingredients.Items.Count.Should().BeGreaterOrEqualTo(2);
        }

        [Fact]
        public async Task Get_Should_Retrieve_Type_BadRequest_Ingredients()
        {
            var response = await _userClient.GetAsync("/api/Ingredients?Types=Blabla");
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Get_Should_Retrieve_Id_Ingredients()
        {
            var response = await _userClient.GetAsync("/api/Ingredients?Id=1");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var Ingredients = JsonConvert.DeserializeObject<GenericListResponseDTO<Ingredient>>(await response.Content.ReadAsStringAsync());
            Ingredients.Items.Should().NotBeEmpty();
            Ingredients.Items.Count.Should().Be(1);
            Ingredients.TotalItems.Should().Be(1);
            Ingredients.Items.First().Id.Should().Be(1);
        }

        [Fact]
        public async Task Get_Should_Retrieve_Ids_Ingredients()
        {
            var response = await _userClient.GetAsync("/api/Ingredients?Id=1&Id=2");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var Ingredients = JsonConvert.DeserializeObject<GenericListResponseDTO<Ingredient>>(await response.Content.ReadAsStringAsync());
            Ingredients.Items.Should().NotBeEmpty();
            Ingredients.Items.Count.Should().Be(2);
            Ingredients.TotalItems.Should().Be(2);
        }

        [Fact]
        public async Task Get_Should_Retrieve_Id_BadRequest_Ingredients()
        {
            var response = await _userClient.GetAsync("/api/Ingredients?Id=Blabla");
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Get_Should_Retrieve_InStock_Ingredients()
        {
            var response = await _userClient.GetAsync("/api/Ingredients?InStock=true");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var Ingredients = JsonConvert.DeserializeObject<GenericListResponseDTO<Ingredient>>(await response.Content.ReadAsStringAsync());
            Ingredients.Items.Should().NotBeEmpty();
            Ingredients.Items.Count.Should().BeGreaterThan(1);
            Ingredients.Items.ForEach(i => i.InStock.Should().BeGreaterOrEqualTo(1));
        }

        [Fact]
        public async Task Get_Should_Retrieve_Instock_Ingredients()
        {
            var response = await _userClient.GetAsync("/api/Ingredients?InStock=false");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var Ingredients = JsonConvert.DeserializeObject<GenericListResponseDTO<Ingredient>>(await response.Content.ReadAsStringAsync());
            Ingredients.Items.Should().NotBeEmpty();
            Ingredients.Items.Count.Should().BeGreaterThan(1);
            Ingredients.Items.ForEach(i => i.InStock.Should().Be(0));
        }

        [Fact]
        public async Task Get_Should_Retrieve_InStock_BadRequest_Ingredients()
        {
            var response = await _userClient.GetAsync("/api/Ingredients?InStock=Blabla");
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Get_Should_Retrieve_Ingredient()
        {
            var response = await _userClient.GetAsync("/api/Ingredients/1");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var Ingredient = JsonConvert.DeserializeObject<Ingredient>(await response.Content.ReadAsStringAsync());
            Ingredient.Should().BeOfType<Ingredient>();
        }

        [Fact]
        public async Task Get_Should_Retrieve_NotFound()
        {
            var response = await _userClient.GetAsync("/api/Ingredients/99999999");
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task Get_Should_Retrieve_BadRequest()
        {
            var response = await _userClient.GetAsync("/api/Ingredients/Test");
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Put_Should_Update_Ingredient()
        {
            var IngredientResponse = await _userClient.GetAsync("/api/Ingredients/1");
            Ingredient Ingredient = JsonConvert.DeserializeObject<Ingredient>(await IngredientResponse.Content.ReadAsStringAsync());

            string newDesc = "This is a new description";
            string newName = "This is a new name";

            Ingredient.Description = newDesc;
            Ingredient.Name = newName;
            Ingredient.Type = Ingredient.IngredientType.Sugar;

            var json = JsonConvert.SerializeObject(Ingredient);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, MediaTypeNames.Application.Json);

            var response = await _userClient.PutAsync("/api/Ingredients/1", stringContent);
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            Ingredient returnedIngredient = JsonConvert.DeserializeObject<Ingredient>(await response.Content.ReadAsStringAsync());

            returnedIngredient.Should().BeOfType<Ingredient>();

            returnedIngredient.Description.Should().Be(newDesc);
            returnedIngredient.Name.Should().Be(newName);
            returnedIngredient.Type.Should().Be(Ingredient.IngredientType.Sugar);
        }

        [Fact]
        public async Task Put_Should_Return_BadRequest()
        {
            var IngredientResponse = await _userClient.GetAsync("/api/Ingredients/1");
            Ingredient Ingredient = JsonConvert.DeserializeObject<Ingredient>(await IngredientResponse.Content.ReadAsStringAsync());

            Ingredient.Description = "new";

            var json = JsonConvert.SerializeObject(Ingredient);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, MediaTypeNames.Application.Json);

            var response = await _userClient.PutAsync("/api/Ingredients/2", stringContent);
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Put_Should_Return_NotFound()
        {
            var IngredientResponse = await _userClient.GetAsync("/api/Ingredients/1");
            Ingredient Ingredient = JsonConvert.DeserializeObject<Ingredient>(await IngredientResponse.Content.ReadAsStringAsync());

            Ingredient.Id = long.MaxValue;

            var json = JsonConvert.SerializeObject(Ingredient);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, MediaTypeNames.Application.Json);

            var response = await _userClient.PutAsync($"/api/Ingredients/{long.MaxValue}", stringContent);
            response.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task Post_Should_Return_Created()
        {
            Ingredient newIngredient = new Ingredient
            {
                Name = "new Test Ingredient",
                Description = "new test Ingredient 2",
                Type = Ingredient.IngredientType.Malt
            };

            var json = JsonConvert.SerializeObject(newIngredient);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, MediaTypeNames.Application.Json);

            var response = await _userClient.PostAsync($"/api/Ingredients", stringContent);
            response.StatusCode.Should().Be(HttpStatusCode.Created);
            Ingredient ing = JsonConvert.DeserializeObject<Ingredient>(await response.Content.ReadAsStringAsync());
            ing.Name.Should().Be(newIngredient.Name);
            ing.Type.Should().Be(newIngredient.Type);
            ing.Id.Should().NotBe(0);
        }

        [Fact]
        public async Task Post_Should_Return_Conflict()
        {
            var res = await _userClient.GetAsync("/api/Ingredients/1");
            Ingredient ing = JsonConvert.DeserializeObject<Ingredient>(await res.Content.ReadAsStringAsync());

            Ingredient newIngredient = new Ingredient
            {
                Name = ing.Name,
                Description = "new test Ingredient 2",
                Type = Ingredient.IngredientType.Malt
            };

            var json = JsonConvert.SerializeObject(newIngredient);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, MediaTypeNames.Application.Json);

            var response = await _userClient.PostAsync($"/api/Ingredients", stringContent);
            response.StatusCode.Should().Be(HttpStatusCode.Conflict);
        }

        [Fact]
        public async Task Post_NoName_Should_Return_BadRequest()
        {
            Ingredient newIngredient = new Ingredient
            {
                Description = "new test Ingredient 2",
                Type = Ingredient.IngredientType.Malt
            };

            var json = JsonConvert.SerializeObject(newIngredient);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, MediaTypeNames.Application.Json);

            var response = await _userClient.PostAsync($"/api/Ingredients", stringContent);
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Fact]
        public async Task Delete_Should_Return_Delete()
        {
            Ingredient newIngredient = new Ingredient
            {
                Name = "delete Test Ingredient",
                Description = "delete test Ingredient 2",
                Type = Ingredient.IngredientType.Malt
            };

            var json = JsonConvert.SerializeObject(newIngredient);
            var stringContent = new StringContent(json, UnicodeEncoding.UTF8, MediaTypeNames.Application.Json);

            var response = await _userClient.PostAsync("/api/Ingredients", stringContent);
            Ingredient ing = JsonConvert.DeserializeObject<Ingredient>(await response.Content.ReadAsStringAsync());

            var deleteResponse = await _userClient.DeleteAsync($"/api/Ingredients/{ing.Id}");
            deleteResponse.StatusCode.Should().Be(HttpStatusCode.OK);

            var doubleDeleteResponse = await _userClient.DeleteAsync($"/api/Ingredients/{ing.Id}");
            doubleDeleteResponse.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }
    }
}
