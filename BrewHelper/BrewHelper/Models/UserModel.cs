using BrewHelper.Authentication;
using BrewHelper.DTO;
using BrewHelper.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
        /// Get users by page
        /// </summary>
        /// <returns>A page with users</returns>
        public async Task<GenericListResponseDTO<UserDTO>> GetByPageAsync(int limit, int page, CancellationToken cancellationToken)
        {
            var query = userManager.Users.AsQueryable();

            var users = await query.OrderBy(u => u.UserName).PaginateAsync(page, limit, cancellationToken);

            return new GenericListResponseDTO<UserDTO>
            {
                CurrentPage = users.CurrentPage,
                TotalItems = users.TotalItems,
                TotalPages = users.TotalPages,
                Items = users.Items.Select(u => new UserDTO { Username = u.UserName, Email = u.Email, Roles = GetUserRoles(u).Result}).ToList()
            };
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

        /// <summary>
        /// Update a user
        /// </summary>
        /// <param name="user">The user to update</param>
        /// <returns>The updated user</returns>
        public async Task<UserDTO> UpdateUserRoles(UserDTO user)
        {
            if (!await UserExists(user.Username)) return null;

            var appUser = await userManager.FindByNameAsync(user.Username);
            await userManager.AddToRolesAsync(appUser, user.Roles.Select(r => r.ToString()).ToArray());
            List<ApplicationRoles> roles = await GetUserRoles(appUser);
            return new UserDTO { Username = user.Username, Email = user.Email, Roles = roles };
        }


        public async Task<bool> UserExists(string username)
        {
            var userExists = await userManager.FindByNameAsync(username);
            return userExists != null;
        }

        private async Task<List<ApplicationRoles>> GetUserRoles(ApplicationUser user)
        {
            IList<string> userRoles = await userManager.GetRolesAsync(user);
            return  userRoles
                .Select(s =>
                {
                    ApplicationRoles role;
                    bool success = Enum.TryParse(s, out role);
                    return new { role, success };
                })
                .Where(pair => pair.success)
                .Select(pair => pair.role).ToList();
        }
    }
}
