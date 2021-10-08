using System;

namespace BrewHelper.Exceptions
{
    public class RecipeNotFoundException : Exception
    {
        public override string Message => "Recipe was not found";
    }
}