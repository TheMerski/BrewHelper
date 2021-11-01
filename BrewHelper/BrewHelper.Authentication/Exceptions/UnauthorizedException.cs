using System;

namespace BrewHelper.Authentication.Exceptions
{
    public class UnauthorizedException : Exception
    {
        public override string Message => "Unauthorized";
    }
}