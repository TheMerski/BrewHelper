namespace BrewHelper.Authentication.Exceptions
{
    using System;

    public class UnauthorizedException : Exception
    {
        public override string Message => "Unauthorized";
    }
}