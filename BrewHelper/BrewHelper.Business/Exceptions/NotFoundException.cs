namespace BrewHelper.Business.Exceptions
{
    using System;

    public class NotFoundException<T> : Exception
    {
        public override string Message => $"{typeof(T)} was not found";
    }
}