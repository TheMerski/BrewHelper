﻿namespace BrewHelper.Authentication.DTO
{
    using System.ComponentModel.DataAnnotations;

    public class LoginDTO
    {
        [Required(ErrorMessage = "User Name is required")]
        public string Username { get; set; } = null!;

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; } = null!;
    }
}
