using BrewHelper.Authentication;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BrewHelper.DTO
{
    public class UserDTO
    {
        public string Id { get; set; } = null!;

        [Required(ErrorMessage = "User Name is required")]
        public string Username { get; set; } = null!;

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; } = null!;

        public List<ApplicationRoles>? Roles { get; set; }
    }
}
