namespace BrewHelper.Business.Exceptions
{
    using System;

    public class BrewLogNotFoundException : Exception
    {
        public override string Message => "BrewLog was not found";
    }
}