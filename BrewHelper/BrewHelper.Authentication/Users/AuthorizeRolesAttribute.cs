namespace BrewHelper.Authentication.Users
{
    using Microsoft.AspNetCore.Authorization;

    public class AuthorizeRolesAttribute : AuthorizeAttribute
    {
        private ApplicationRoles roleEnum;

        public ApplicationRoles RoleEnum
        {
            get
            {
                return this.roleEnum;
            }

            set
            {
                this.roleEnum = value;
                this.Roles = value.ToString();
            }
        }
    }
}