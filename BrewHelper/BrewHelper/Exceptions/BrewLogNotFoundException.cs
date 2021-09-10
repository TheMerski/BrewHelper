using System;

namespace BrewHelper.Exceptions
{
    public class BrewLogNotFoundException : Exception
    {
        public override string Message => "BrewLog was not found";
    }
}