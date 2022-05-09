namespace BrewHelper.Authentication.Exceptions
{
    using System;

    public class UsernameExistsException : Exception
    {
        public override string Message => "A user with this username allready exists";
    }
}
