namespace BrewHelper.Web.Areas.Identity.Pages.Account
{
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;
    using BrewHelper.Authentication.Users;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.Extensions.Logging;

#pragma warning disable SA1649
    public class ResetPasswordModel : PageModel
#pragma warning restore SA1649
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly ILogger<ResetPasswordModel> logger;

        public ResetPasswordModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<ResetPasswordModel> logger)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.logger = logger;
        }

        [BindProperty]
        public InputModel? Input { get; set; }

        [TempData]
        public string? StatusMessage { get; set; }

        public class InputModel
        {
            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "New password")]
#pragma warning disable 8618
            public string NewPassword { get; set; }
#pragma warning restore 8618

            [DataType(DataType.Password)]
            [Display(Name = "Confirm new password")]
            [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
#pragma warning disable 8618
            public string ConfirmPassword { get; set; }
#pragma warning restore 8618

#pragma warning disable 8618
            [Required]
            public string Username { get; set; }

            [Required]
            public string Token { get; set; }
#pragma warning restore 8618

        }

        // ReSharper disable once UnusedMember.Global
#pragma warning disable SA1201
        public IActionResult OnGetAsync()
#pragma warning restore SA1201
        {
            //TODO: Set username & password from query.
            return this.Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!this.ModelState.IsValid)
            {
                return this.Page();
            }

            var user = await this.userManager.FindByNameAsync(this.Input?.Username ?? string.Empty);
            if (user == null)
            {
                return this.NotFound($"Unable to load user.");
            }

#pragma warning disable 8602
            var changePasswordResult = await this.userManager.ResetPasswordAsync(user, this.Input.Token, this.Input.NewPassword);
#pragma warning restore 8602
            if (!changePasswordResult.Succeeded)
            {
                foreach (var error in changePasswordResult.Errors)
                {
                    this.ModelState.AddModelError(string.Empty, error.Description);
                }

                return this.Page();
            }

            await this.signInManager.RefreshSignInAsync(user);
            this.logger.LogInformation("User reset their password successfully.");
            this.StatusMessage = "Your password has been reset.";

            return this.RedirectToPage("~/Login");
        }
    }
}
