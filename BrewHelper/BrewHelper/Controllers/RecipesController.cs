using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BrewHelper.Models;
using BrewHelper.DTO;
using System.Threading;

namespace BrewHelper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly RecipeModel recipeModel;
        private readonly IngredientModel ingredientModel;

        public RecipesController(RecipeModel recipeModel, IngredientModel ingredientModel)
        {
            this.recipeModel = recipeModel;
            this.ingredientModel = ingredientModel;
        }

        // GET: api/Recipes
        [HttpGet]
        [ProducesResponseType(typeof(GetRecipeListResponseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllRecipes(
            [FromQuery] UrlQueryParameters urlQueryParameters,
            CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var recipes = await recipeModel.GetByPageAsync(urlQueryParameters.Limit, urlQueryParameters.Page, urlQueryParameters.Name, urlQueryParameters.Id, cancellationToken);

            return Ok(recipes);
        }

        // GET: api/Recipes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RecipeDTO>> GetRecipe(long id)
        {
            var recipe = await recipeModel.GetRecipeById(id);

            if (recipe == null)
            {
                return NotFound();
            }

            return recipe;
        }

        // PUT: api/Recipes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<RecipeDTO>> PutRecipe(long id, RecipeDTO recipe)
        {
            if (id != recipe.Id)
            {
                return BadRequest();
            }

            if (await recipeModel.UpdateRecipe(id, recipe) == null)
            {
                return NotFound();
            }

            return recipe;
        }

        // POST: api/Recipes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<RecipeDTO>> PostRecipe(RecipeDTO recipe)
        {

            if (ModelState.IsValid)
            {
                Recipe addedRecipe = await recipeModel.AddRecipe(recipe);
                if (addedRecipe == null)
                {
                    return Conflict();
                }

                return CreatedAtAction("GetRecipe", new { id = addedRecipe.Id }, addedRecipe);
            } else
            {
                return BadRequest();
            }

        }

        // DELETE: api/Recipes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRecipe(long id)
        {
            bool removed = await recipeModel.DeleteRecipeById(id);
            if (removed)
            {
                return Ok();
            }

            return NotFound();
        }

        public record UrlQueryParameters(int Limit = 50, int Page = 1, string Name = null, long[] Id = null);

    }
}
