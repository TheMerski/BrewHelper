namespace BrewHelper.Authentication.Extensions
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using BrewHelper.Authentication.Users;

    public static class ApplicationRolesExtension
    {
        public static IEnumerable<ApplicationRoles> GetApplicationRoles(this IEnumerable<string> roles)
        {
            return roles
                .Select(s =>
                {
                    ApplicationRoles role;
                    bool success = Enum.TryParse(s, out role);
                    return new { role, success };
                })
                .Where(pair => pair.success)
                .Select(pair => pair.role).ToList();
        }
    }
}