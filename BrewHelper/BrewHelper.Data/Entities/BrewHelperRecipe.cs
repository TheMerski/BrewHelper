namespace BrewHelper.Data.Entities;

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Text;
using BeerXMLSharp;
using BeerXMLSharp.OM.Records;

public class BrewHelperRecipe
{
    public BrewHelperRecipe()
    {
    }

    public long Id { get; set; }

    [Required]
    public string Name { get; set; } = default!;

    [Column(TypeName = "xml")]
    public string RecipeXml { get; private set; } = default!;

    [NotMapped]
    public Recipe Recipe => this.DeserializeRecipe();

    public void SerializeRecipe()
    {
        MemoryStream ms = new MemoryStream();
        this.Recipe.GetBeerXML(ms);
        this.RecipeXml = ms.ToString() ?? string.Empty;
    }

    private Recipe DeserializeRecipe()
    {
        byte[] byteArray = Encoding.UTF8.GetBytes(this.RecipeXml);
        MemoryStream ms = new MemoryStream(byteArray);
        var entity = BeerXML.Deserialize(ms);
        return (Recipe)entity;
    }
}
