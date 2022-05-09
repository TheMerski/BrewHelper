using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using BrewHelper.Data.Entities;

namespace BrewHelper.Data.Mappers;
public interface IBeerXMLMapper
{
    public Task<IEnumerable<Recipe>> MapRecipes(string xml);

    public Task<IEnumerable<Recipe>> MapRecipes(Stream xml);
}
