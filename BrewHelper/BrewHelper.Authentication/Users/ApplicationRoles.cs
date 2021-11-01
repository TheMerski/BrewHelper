using System.Text.Json.Serialization;

namespace BrewHelper.Authentication.Users
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ApplicationRoles
    {
        Admin,
        User
    }
}
