﻿using Microsoft.AspNetCore.Authorization;

namespace BrewHelper.Authentication
{
    public class AuthorizeRolesAttribute : AuthorizeAttribute
    {
        private ApplicationRoles roleEnum;
        public ApplicationRoles RoleEnum
        {
            get { return roleEnum; }
            set { roleEnum = value; Roles = value.ToString(); }
        }
    }
}
