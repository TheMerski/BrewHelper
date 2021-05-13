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
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace BrewHelper.Controllers
{
    [Route("api/[controller]")]
    [AuthorizeRoles(RoleEnum = ApplicationRoles.Admin)]
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
        public async Task<IActionResult> GetAllUsers(
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

        // GET: api/Users/1
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUser(string id)
        {
            var user = await userModel.GetById(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // PUT: api/Users/1
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<RecipeDTO>> PutUser(string id, UserDTO user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            UserDTO updated = await userModel.UpdateUser(user);
            if (updated == null)
            {
                return NotFound();
            }

            return Ok(updated);
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

        // DELETE: api/Users/1
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(string id)
        {
            string currentUserId = await userModel.GetCurrentUserId(User) ;
            if (currentUserId != id)
            {
                bool deleted = await userModel.DeleteById(id);

                if (deleted)
                {
                    return Ok();
                }

                return NotFound();
            }

            return BadRequest();
        }

        public record UrlQueryParameters(int Limit = 50, int Page = 1);
    }
}
