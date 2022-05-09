namespace BrewHelper.Authentication.DTO
{
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// Class to update user passwords.
    /// </summary>
    public class UpdatePasswordDTO
    {
        [Required(ErrorMessage = "Current Password is required")]
        public string CurrentPassword { get; set; } = null!;

        [Required(ErrorMessage = "New Password is required")]
        public string NewPassword { get; set; } = null!;
    }
}
