using BrewHelper.Authentication;
using BrewHelper.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrewHelper.Models
{
    public class UserModel
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IConfiguration _configuration;

        public UserModel(UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            _configuration = configuration;
        }


        /// <summary>
        /// Create a user with Roles
        /// </summary>
        /// <param name="register">Registered user model</param>
        /// <returns></returns>
        public async Task<UserDTO> CreateUser(RegisterDTO register)
        {
            if (await UserExists(register.Username)) return null;

            ApplicationUser user = new ApplicationUser()
            {
                Email = register.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = register.Username
            };
            var result = await userManager.CreateAsync(user, register.Password);

            if (result.Succeeded)
            {
                if (!register.Roles.Contains(ApplicationRoles.User)) 
                    register.Roles.Add(ApplicationRoles.User);
                await userManager.AddToRolesAsync(user, register.Roles.Select(r => r.ToString()).ToArray());
                return new UserDTO { Username = user.UserName, Email = user.Email, Roles = register.Roles };
            }

            return null;
        }

        public async Task<bool> UserExists(string username)
        {
            var userExists = await userManager.FindByNameAsync(username);
            return userExists != null;
        }
    }
}
