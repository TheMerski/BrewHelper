using BrewHelper.Authentication;
using BrewHelper.DTO;
using BrewHelper.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BrewHelper.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly UserModel userModel;
        private readonly IConfiguration _configuration;

        public UsersController(UserModel userModel, IConfiguration configuration)
        {
            this.userModel = userModel;
            _configuration = configuration;
        }

        // GET: api/Users
        [HttpGet]
        [ProducesResponseType(typeof(GenericListResponseDTO<UserDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllRecipes(
            [FromQuery] UrlQueryParameters urlQueryParameters,
            CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var users = await userModel.GetByPageAsync(urlQueryParameters.Limit, urlQueryParameters.Page, cancellationToken);

            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RegisterDTO model)
        {
            if (await userModel.UserExists(model.Username))
                return Conflict();

            if (ModelState.IsValid)
            {
                return Ok(await userModel.CreateUser(model));
            }
            else
            {
                return BadRequest();
            }
        }

        public record UrlQueryParameters(int Limit = 50, int Page = 1);
    }
}
