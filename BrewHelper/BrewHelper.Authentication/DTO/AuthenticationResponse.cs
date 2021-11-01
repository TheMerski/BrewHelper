using System;

namespace BrewHelper.Authentication.DTO
{
    public class AuthenticationResponse
    {
        public string Status { get; set; } = null!;
        public string Message { get; set; } = null!;
    }

    public class LoginResponse
    {
        public string token { get; set; } = null!;
        public DateTime expiration { get; set; }
    }
}
