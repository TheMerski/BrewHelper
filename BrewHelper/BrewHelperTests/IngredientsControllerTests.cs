using BrewHelper.Models;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace BrewHelperTests
{
    public class IngredientsControllerTests : IClassFixture<WebApplicationFactory<BrewHelper.Startup>>
    {
        public HttpClient Client { get; }

        public IngredientsControllerTests(WebApplicationFactory<BrewHelper.Startup> fixture)
        {
            Client = fixture.CreateClient();
        }

        [Fact]
        public async Task Get_Should_Retrieve_Ingredients()
        {
            var response = await Client.GetAsync("/api/Ingredients");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var ingredients = JsonConvert.DeserializeObject<Ingredient[]>(await response.Content.ReadAsStringAsync());
            ingredients.Should().HaveCount(0);
        }
    }
}
