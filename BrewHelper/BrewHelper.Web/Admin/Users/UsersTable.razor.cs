namespace BrewHelper.Web.Admin.Users
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using BrewHelper.Authentication.Users;
    using BrewHelper.Authentication.Users.Interfaces;
    using BrewHelper.Web.Admin.Users.Stores.Actions;
    using BrewHelper.Web.Admin.Users.Stores.States;
    using BrewHelper.Web.Users;
    using Fluxor;
    using Microsoft.AspNetCore.Components;
    using MudBlazor;

    public partial class UsersTable
    {
        [Inject]
        private IState<UsersState> UsersState { get; set; } = default!;

        [Inject]
        private IDispatcher Dispatcher { get; set; } = default!;

        [Inject]
        private IDialogService DialogService { get; set; } = default!;

        private MudTable<TableUser> Table { get; set; } = default!;

        [Inject]
        private IUsersService UsersService { get; set; } = default!;

        protected override void OnInitialized()
        {
            base.OnInitialized();

            this.UsersState.StateChanged += this.StateChanged;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            this.UsersState.StateChanged -= this.StateChanged;
        }

        private void StateChanged(object? sender, EventArgs e)
        {
            if (!this.UsersState.Value.IsLoading)
            {
                this.Table.ReloadServerData();
            }
        }

        private void ReloadData()
        {
            this.Dispatcher.Dispatch(new GetUsersAction());
        }

        private async Task<TableData<TableUser>> TableData(TableState state)
        {
            var users = this.UsersState.Value.Users;

            if (users == null)
            {
                return await Task.FromResult(new TableData<TableUser>
                {
                    TotalItems = 0,
                    Items = Array.Empty<TableUser>(),
                });
            }

            users = state.SortLabel switch
            {
                nameof(ApplicationUser.UserName) =>
                    users.OrderByDirection(state.SortDirection, i => i.UserName),
                _ =>
                    users.OrderBy(i => i.UserName),
            };

            var skip = state.Page * state.PageSize;
            var take = state.PageSize;
            var selectedUsers = users.Skip(skip).Take(take).ToList();

            List<TableUser> tableUsers = new();
            foreach (ApplicationUser user in selectedUsers)
            {
                var roles = await this.UsersService.GetUserRoles(user);
                tableUsers.Add(new TableUser(user, roles));
            }

            return await Task.FromResult(new TableData<TableUser>
            {
                TotalItems = users.Count(),
                Items = tableUsers,
            });
        }

        private async Task OpenDialog(TableUser tableUser)
        {
            var parameters = new DialogParameters()
            {
                { "User", tableUser },
            };
            var dialog = this.DialogService.Show<UserRolesDialog>("User Roles", parameters);
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                this.Dispatcher.Dispatch(new GetUsersAction());
            }
        }
    }
}