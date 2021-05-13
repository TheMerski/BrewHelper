using BrewHelper.Authentication;
using BrewHelper.DTO;
using BrewHelper.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
                Items = users.Items.Select(u => ToDTO(u).Result).ToList()
            };
        }

        /// <summary>
        /// Get a user by id
        /// </summary>
        /// <param name="id">Id of the user</param>
        /// <returns>The UserDTO or null</returns>
        public async Task<UserDTO> GetById(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                return await ToDTO(user);
            }
            return null;
        }

        /// <summary>
        /// Delete a user by id
        /// </summary>
        /// <param name="id">Id of the user to delete</param>
        /// <returns>true if deleted, false if not found</returns>
        public async Task<bool> DeleteById(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                await userManager.DeleteAsync(user);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Update a user
        /// </summary>
        /// <param name="dto">UserDTO of the user to update</param>
        /// <returns>Updated UserDTO or null</returns>
        public async Task<UserDTO> UpdateUser(UserDTO dto)
        {
            var user = await userManager.FindByIdAsync(dto.Id);
            user.UserName = dto.Username;
            user.Email = dto.Email;
            var result = await userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return await UpdateUserRoles(dto);
            }
            return null;
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
                return await ToDTO(user);
            }

            return null;
        }

        /// <summary>
        /// Get the Id of the current user
        /// </summary>
        /// <param name="principal">Current user principal</param>
        /// <returns>Id of current user</returns>
        public async Task<string> GetCurrentUserId(ClaimsPrincipal principal)
        {
            ApplicationUser user = await userManager.FindByNameAsync(principal.Identity.Name);
            return user.Id;
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

        /// <summary>
        /// Check if user exists
        /// </summary>
        /// <param name="username">Username of the user</param>
        /// <returns>true if exists</returns>
        public async Task<bool> UserExists(string username)
        {
            var userExists = await userManager.FindByNameAsync(username);
            return userExists != null;
        }

        /// <summary>
        /// Transform ApplicationUser to UserDTO
        /// </summary>
        /// <param name="user">ApplicationUser to transform</param>
        /// <returns>UserDTO for user</returns>
        private async Task<UserDTO> ToDTO(ApplicationUser user)
        {
            List<ApplicationRoles> roles = await GetUserRoles(user);
            return new UserDTO { Id = user.Id, Email = user.Email, Username = user.UserName, Roles = roles };
        }

        /// <summary>
        /// Get the ApplicationRoles for a user
        /// </summary>
        /// <param name="user">ApplicationUser to get roles for</param>
        /// <returns>List of ApplicationRoles of user</returns>
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
