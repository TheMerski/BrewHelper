﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BrewHelper.Authentication
{
    public class RegisterDTO
    {
        [Required(ErrorMessage = "User Name is required")]
        public string Username { get; set; } = null!;

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; } = null!;

        public List<ApplicationRoles>? Roles { get; set; }
    }
}
