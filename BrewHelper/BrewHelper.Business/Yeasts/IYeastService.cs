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
    /// Create a yeast.
    /// </summary>
    /// <param name="yeast">The yeast to create.</param>
    /// <returns>The created yeast.</returns>
    public Task<Yeast> CreateYeast(Yeast yeast);

    /// <summary>
    /// Create a new version of a yeast.
    /// </summary>
    /// <param name="yeast">The yeast to create a new version of.</param>
    /// <returns>The newly created yeast version.</returns>
    public Task<Yeast> CreateYeastVersion(Yeast yeast);

    /// <summary>
    /// Update a yeast.
    /// </summary>
    /// <param name="yeast">Updated yeast.</param>
    /// <returns>The updated yeast.</returns>
    public Task<Yeast> UpdateYeast(Yeast yeast);

    /// <summary>
    /// Delete a yeast.
    /// </summary>
    /// <param name="id">The id of the yeast to delete.</param>
    public Task DeleteYeast(long id);

    /// <summary>
    /// Check whether a Yeast is used in a recipe.
    /// </summary>
    /// <param name="yeast">The yeast to check.</param>
    /// <returns>True if the yeast is used in a recipe.</returns>
    public Task<bool> YeastInUse(Yeast yeast);
}