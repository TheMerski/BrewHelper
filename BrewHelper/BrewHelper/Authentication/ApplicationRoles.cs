using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BrewHelper.Authentication
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ApplicationRoles
    {
        Admin,
        User
    }
}
