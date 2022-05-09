namespace BrewHelper.Web.Admin.Users
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using BrewHelper.Authentication.Extensions;
    using BrewHelper.Authentication.Users.Interfaces;
    using BrewHelper.Web.Admin.Users.Stores;
    using Microsoft.AspNetCore.Components;
    using MudBlazor;

    public partial class UserRolesDialog
    {
        [Parameter]
        public TableUser User { get; set; } = default!;

        [CascadingParameter]
        private MudDialogInstance MudDialog { get; set; } = default!;

        private IEnumerable<string> SelectedRoles { get; set; } = new HashSet<string>();

        [Inject]
        private IUsersService UsersService { get; set; } = default!;

        protected override void OnInitialized()
        {
            base.OnInitialized();

            this.SelectedRoles = this.User.Roles.Select(r => r.ToString());
        }

        private async Task SubmitAsync()
        {
            await this.UsersService.UpdateUserRoles(this.User.User, this.SelectedRoles.GetApplicationRoles().ToList());
            this.MudDialog.Close(DialogResult.Ok(this.SelectedRoles.GetApplicationRoles()));
        }

        private void Cancel() => this.MudDialog.Cancel();
    }
}