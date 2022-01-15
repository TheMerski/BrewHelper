namespace BrewHelper.Authentication.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    internal class UsernameExistsException : Exception
    {
        public override string Message => "A user with this username allready exists";
    }
}
