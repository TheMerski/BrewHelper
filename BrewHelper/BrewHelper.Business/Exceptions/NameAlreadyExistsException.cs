namespace BrewHelper.Business.Exceptions
{
    using System;

    public class NameAlreadyExistsException<T> : Exception
    {
        public override string Message => $"A {typeof(T)} with that name already exists";
    }
}