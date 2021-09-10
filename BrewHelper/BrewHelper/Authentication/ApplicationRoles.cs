using System.Text.Json.Serialization;

namespace BrewHelper.Authentication
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ApplicationRoles
    {
        Admin,
        User
    }
}
