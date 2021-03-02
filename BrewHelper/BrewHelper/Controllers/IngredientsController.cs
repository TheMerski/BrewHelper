using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BrewHelper.Models;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using BrewHelper.DTO;
using System.Threading;

namespace BrewHelper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientsController : ControllerBase
    {
        private readonly IngredientModel ingredientModel;

        public IngredientsController(IngredientModel ingredientModel)
        {
            this.ingredientModel = ingredientModel;
        }

        // GET: api/Ingredients
        [HttpGet]
        [ProducesResponseType(typeof(GetIngredientListResponseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetIngredients(
            [FromQuery] UrlQueryParameters urlQueryParameters,
            CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var ingredients = await ingredientModel.GetByPageAsync(urlQueryParameters.Limit, urlQueryParameters.Page, cancellationToken);

            return Ok(ingredients);
        }

        // GET: api/Ingredients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ingredient>> GetIngredient(long id)
        {
            var ingredient = await ingredientModel.GetIngredientById(id);

            if (ingredient == null)
            {
                return NotFound();
            }

            return ingredient;
        }

        // PUT: api/Ingredients/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<Ingredient>> PutIngredient(long id, Ingredient ingredient)
        {
            if (id != ingredient.Id)
            {
                return BadRequest();
            }

            if (await ingredientModel.UpdateIngredient(id, ingredient) == null)
            {
                return NotFound();
            }

            return ingredient;
        }

        // POST: api/Ingredients
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Ingredient>> PostIngredient(Ingredient ingredient)
        {
            if (ModelState.IsValid)
            {
                if (await ingredientModel.AddIngredient(ingredient) == null)
                {
                    return Conflict();
                }

                return CreatedAtAction("GetIngredient", new { id = ingredient.Id }, ingredient);
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE: api/Ingredients/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Ingredient>> DeleteIngredient(long id)
        {
            bool removed = await ingredientModel.DeleteIngredientById(id);
            if (removed)
            {
                return Ok();
            }

            return NotFound();
        }

    }

    public record UrlQueryParameters(int Limit = 50, int Page = 1);
}
