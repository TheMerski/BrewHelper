namespace BrewHelper.Web.Admin.Users
{
    using System.Collections.Generic;
    using System.Linq;
    using BrewHelper.Authentication.Extensions;
    using BrewHelper.Web.Users;
    using Microsoft.AspNetCore.Components;
    using MudBlazor;

    public partial class UserRolesDialog
    {
        [Parameter]
        public TableUser User { get; set; } = default!;

        [CascadingParameter]
        private MudDialogInstance MudDialog { get; set; } = default!;

        private IEnumerable<string> SelectedRoles { get; set; } = new HashSet<string>();

        protected override void OnInitialized()
        {
            base.OnInitialized();

            this.SelectedRoles = this.User.Roles.Select(r => r.ToString());
        }

        private void Submit()
        {
            this.MudDialog.Close(DialogResult.Ok(this.SelectedRoles.GetApplicationRoles()));
        }

        private void Cancel() => this.MudDialog.Cancel();
    }
}