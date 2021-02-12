using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BrewHelper.Models;

namespace BrewHelper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        private readonly RecipeModel recipeModel;

        public RecipesController(RecipeModel recipeModel)
        {
            this.recipeModel = recipeModel;
        }

        // GET: api/Recipes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recipe>>> GetAllRecipes()
        {
            return await recipeModel.GetAll();
        }

        // GET: api/Recipes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Recipe>> GetRecipe(long id)
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
        public async Task<IActionResult> PutRecipe(long id, Recipe recipe)
        {
            if (id != recipe.Id)
            {
                return BadRequest();
            }

            if (await recipeModel.UpdateRecipe(id, recipe) == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Recipes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Recipe>> PostRecipe(Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                if (await recipeModel.AddRecipe(recipe) == null)
                {
                    return Conflict();
                }

                return CreatedAtAction("GetRecipe", new { id = recipe.Id }, recipe);
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

        
    }
}
