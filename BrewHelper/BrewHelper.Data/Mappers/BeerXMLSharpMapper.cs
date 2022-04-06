using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrewHelper.Data.Entities;

namespace BrewHelper.Data.Mappers;
public static class BeerXMLSharpMapper
{
    public static IEnumerable<Recipe> ToRecipeEnumerator(this RECIPES recipes)
    {
        return recipes.RECIPE.Select(r => r.ToRecipe()).AsEnumerable();
    }

    public static Recipe ToRecipe(this RECIPESRECIPE recipe)
    {
        throw new NotImplementedException();
    }
}
