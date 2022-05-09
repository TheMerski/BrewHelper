namespace BrewHelper.Business.Exceptions
{
    using System;

    public class EntityInUseException<T> : Exception
    {
        public override string Message => $"The {typeof(T)} is currently linked to another entity";
    }
}