namespace BrewHelper.Authentication.Users
{
    using System.Text.Json.Serialization;

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ApplicationRoles
    {
        /// <summary>
        /// Admin user.
        /// </summary>
        Admin,

        /// <summary>
        /// Basic user.
        /// </summary>
        User,
    }
}
