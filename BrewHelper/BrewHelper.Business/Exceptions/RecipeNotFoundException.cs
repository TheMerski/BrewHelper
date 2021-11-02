namespace BrewHelper.Business.Exceptions
{
    using System;

    public class RecipeNotFoundException : Exception
    {
        public override string Message => "Recipe was not found";
    }
}