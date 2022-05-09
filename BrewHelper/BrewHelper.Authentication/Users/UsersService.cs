namespace BrewHelper.Authentication.Users
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using BrewHelper.Authentication.Exceptions;
    using BrewHelper.Authentication.Extensions;
    using BrewHelper.Authentication.Users.Interfaces;
    using Microsoft.AspNetCore.Identity;

    public class UsersService : IUsersService
    {
        private readonly UserManager<ApplicationUser> userManager;

        public UsersService(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public IQueryable<ApplicationUser> GetUsers()
        {
            return this.userManager.Users;
        }

        public async Task<List<ApplicationRoles>> GetUserRoles(ApplicationUser user)
        {
            IList<string> userRoles = await this.userManager.GetRolesAsync(user);
            return userRoles.GetApplicationRoles().ToList();
        }

        public async Task UpdateUserRoles(ApplicationUser user, List<ApplicationRoles> userRoles)
        {
            List<ApplicationRoles> currentRoles = await this.GetUserRoles(user);
            if (!userRoles.All(currentRoles.Contains))
            {
                List<ApplicationRoles> newRoles = userRoles.Where(r => !currentRoles.Contains(r)).ToList();
                List<ApplicationRoles> removedRoles = currentRoles.Where(r => !userRoles.Contains(r)).ToList();
                if (newRoles.Count > 0)
                {
                    await this.userManager.AddToRolesAsync(user, newRoles.Select(r => r.ToString()).ToArray());
                }

                if (removedRoles.Count > 0)
                {
                    await this.userManager.RemoveFromRolesAsync(user, removedRoles.Select(r => r.ToString()).ToArray());
                }
            }
        }

        /// <summary>
        /// Create a new user without password.
        /// </summary>
        /// <param name="username">The username for the user to create.</param>
        /// <returns>The password reset token for the generated user.</returns>
        /// <exception cref="Exception">Exception if something went wrong creating the user.</exception>
        /// <exception cref="UsernameExistsException">Exception if there allready is a user with the username.</exception>
        public async Task<string> CreateUser(string username)
        {
            // Check if nu user with the username exists.
            if (await this.userManager.FindByNameAsync(username) == null)
            {
                ApplicationUser user = new ApplicationUser { UserName = username };
                var res = await this.userManager.CreateAsync(user);
                if (res.Succeeded)
                {
                    // If the user is successfully created return a passwordResetToken to allow the user to create a password.
                    var createdUser = await this.userManager.FindByNameAsync(username);
                    return await this.userManager.GeneratePasswordResetTokenAsync(createdUser);
                }

                throw new Exception($"Something went wrong creating user {username}: {res.Errors}");
            }

            throw new UsernameExistsException();
        }

        /// <summary>
        /// Generate a password reset token for a user.
        /// </summary>
        /// <param name="username">Username of the user to generate a password reset token for.</param>
        /// <returns>The password reset token.</returns>
        /// <exception cref="UserNotFoundException">User with username was not found.</exception>
        public async Task<string> GetPasswordResetToken(string username)
        {
            var user = await this.userManager.FindByNameAsync(username);
            if (user != null)
            {
                return await this.userManager.GeneratePasswordResetTokenAsync(user);
            }

            throw new UserNotFoundException();
        }
    }
}