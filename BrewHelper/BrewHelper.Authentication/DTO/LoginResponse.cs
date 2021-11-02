namespace BrewHelper.Authentication.DTO
{
    using System;

    public class LoginResponse
    {
        public string Token { get; set; } = null!;

        public DateTime Expiration { get; set; }
    }
}