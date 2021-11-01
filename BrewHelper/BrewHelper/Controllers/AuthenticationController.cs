using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BrewHelper.Authentication;
using BrewHelper.Authentication.DTO;
using BrewHelper.Authentication.Exceptions;
using BrewHelper.Authentication.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BrewHelper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationModel _authenticationModel;

        public AuthenticationController(IAuthenticationModel authenticationModel)
        {
            _authenticationModel = authenticationModel;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO model)
        {
            try
            {
                return Ok(await _authenticationModel.LoginAsync(model));
            }
            catch (UnauthorizedException)
            {
                return Unauthorized();
            }
        }


    }
}
