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
    public class RecipesControllerTests : IntegrationTest
    {
        public RecipesControllerTests(BrewHelperWebApplicationFactory fixture)
      : base(fixture) { }

        [Fact]
        public async Task Get_Should_Retrieve_Recipes()
        {
            var response = await _client.GetAsync("/Recipes");
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            var recipes = JsonConvert.DeserializeObject<RecipeDTO[]>(await response.Content.ReadAsStringAsync());
            recipes.Should().HaveCount(1);
        }
    }
}
