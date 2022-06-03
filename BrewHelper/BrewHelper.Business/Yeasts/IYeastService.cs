namespace BrewHelper.Business.Yeasts;

using System.Linq;
using System.Threading.Tasks;
using BrewHelper.Data.Entities;

public interface IYeastService
{
    /// <summary>
    /// Get a list of yeasts.
    /// </summary>
    /// <returns>An IQueryable with yeasts.</returns>
    public IQueryable<Yeast> GetYeasts();

    /// <summary>
    /// Get a single Yeast by Id.
    /// </summary>
    /// <returns>A Yeast or notFound.</returns>
    public Task<Yeast> GetYeast(long id);

    /// <summary>
    /// Create a hop.
    /// </summary>
    /// <param name="hop">The hop to create.</param>
    /// <returns>The created hop.</returns>
    public Task<Yeast> CreateYeast(Yeast hop);

    /// <summary>
    /// Create a new version of a hop.
    /// </summary>
    /// <param name="hop">The hop to create a new version of.</param>
    /// <returns>The newly created hop version.</returns>
    public Task<Yeast> CreateYeastVersion(Yeast hop);

    /// <summary>
    /// Update a hop.
    /// </summary>
    /// <param name="hop">Updated hop.</param>
    /// <returns>The updated hop.</returns>
    public Task<Yeast> UpdateYeast(Yeast hop);

    /// <summary>
    /// Delete a hop.
    /// </summary>
    /// <param name="id">The id of the hop to delete.</param>
    public Task DeleteYeast(long id);

    /// <summary>
    /// Check whether a Yeast is used in a recipe.
    /// </summary>
    /// <param name="hop">The hop to check.</param>
    /// <returns>True if the hop is used in a recipe.</returns>
    public Task<bool> YeastInUse(Yeast hop);
}