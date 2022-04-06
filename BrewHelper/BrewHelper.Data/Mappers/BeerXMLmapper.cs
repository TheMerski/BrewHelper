using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using BrewHelper.Data.Entities;
using BrewHelper.Data.Exceptions;

namespace BrewHelper.Data.Mappers;
internal class BeerXMLmapper : IBeerXMLMapper
{
    public BeerXMLmapper()
    {
    }

    public Task<IEnumerable<Recipe>> MapRecipes(string xml)
    {
        byte[] byteArray = Encoding.ASCII.GetBytes(xml);
        MemoryStream stream = new MemoryStream(byteArray);
        return this.MapRecipes(stream);
    }

    public Task<IEnumerable<Recipe>> MapRecipes(Stream xml)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(RECIPES));
        RECIPES? recipes;
        recipes = (RECIPES?)serializer.Deserialize(xml);
        if (recipes == null)
        {
            throw new Exception("Something went wrong deserializing");
        }
        else
        {
            IEnumerable<Recipe> enumerator = recipes.ToRecipeEnumerator();
            return Task.FromResult(enumerator);
        }
    }
}
