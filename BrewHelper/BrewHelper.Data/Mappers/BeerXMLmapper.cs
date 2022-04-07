using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using BrewHelper.Data.Entities;
using BrewHelper.Data.Exceptions;
using Microsoft.Extensions.Logging;

namespace BrewHelper.Data.Mappers;
public class BeerXMLmapper : IBeerXMLMapper
{
    private ILogger<BeerXMLmapper> logger;

    public BeerXMLmapper(ILogger<BeerXMLmapper> logger)
    {
        this.logger = logger;
    }

    /// <summary>
    /// Maps A BeerXML formatted string to a Recipe list.
    /// </summary>
    /// <param name="xml">BeerXML formatted string.</param>
    /// <returns>A Enumerable of Recipes from the string.</returns>
    /// <exception cref="IncorrectXMLTypeException">XML is not of BeerXML type and could not be parsed.</exception>
    /// <exception cref="Exception">Something went wrong during parsing.</exception>
    public Task<IEnumerable<Recipe>> MapRecipes(string xml)
    {
        byte[] byteArray = Encoding.ASCII.GetBytes(xml);
        MemoryStream stream = new MemoryStream(byteArray);
        return this.MapRecipes(stream);
    }

    /// <summary>
    /// Maps A BeerXML formatted stream to a Recipe list.
    /// </summary>
    /// <param name="xml">BeerXML formatted stream.</param>
    /// <returns>A Enumerable of Recipes from the stream.</returns>
    /// <exception cref="IncorrectXMLTypeException">XML is not of BeerXML type and could not be parsed.</exception>
    /// <exception cref="Exception">Something went wrong during parsing.</exception>
    public Task<IEnumerable<Recipe>> MapRecipes(Stream xml)
    {
        RECIPES? recipes;

        try
        {
            XmlSerializer serializer = new XmlSerializer(typeof(RECIPES));
            recipes = (RECIPES?)serializer.Deserialize(xml);
        }
        catch (Exception ex)
        {
            this.logger.LogInformation($"Something went wrong deserializing beerXML: {ex.Message}", ex);
            throw new IncorrectXMLTypeException("Something went wrong deserializing");
        }

        if (recipes == null)
        {
            this.logger.LogWarning("Something went wrong deserializing beerXML, recipes is null");
            throw new Exception("Something went wrong deserializing");
        }
        else
        {
            try
            {
                IEnumerable<Recipe> enumerator = recipes.ToRecipeEnumerator();
                return Task.FromResult(enumerator);
            }
            catch (Exception ex)
            {
                this.logger.LogWarning($"Something went wrong mapping to Recipes: {ex.Message}", ex);
                throw new Exception("Something went wrong deserializing");
            }
        }
    }
}
