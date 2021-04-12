using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrewHelper.Authentication
{
    public class AuthorizeRolesAttribute : AuthorizeAttribute
    {
        private ApplicationRoles roleEnum;
        public ApplicationRoles RoleEnum
        {
            get { return roleEnum; }
            set { roleEnum = value; base.Roles = value.ToString(); }
        }
    }
}
