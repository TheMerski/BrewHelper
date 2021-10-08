using BrewHelper.Authentication;
using BrewHelper.DTO;
using BrewHelper.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        public UsersController(UserModel userModel)
        {
            this.userModel = userModel;
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
        public async Task<ActionResult<UserDTO>> PutUser(string id, UserDTO user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            var updated = await userModel.UpdateUser(user);
            if (updated == null)
            {
                return NotFound();
            }

            return Ok(updated);
        }

        [HttpPost]
        public async Task<ActionResult<UserDTO>> Create([FromBody] RegisterDTO model)
        {
            if (await userModel.UserExists(model.Username))
                return Conflict();

            if (ModelState.IsValid)
            {
                var created = await userModel.CreateUser(model);
                if (created != null)
                {
                    return Created("GetUser", created);
                }
            }
            return BadRequest();
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
