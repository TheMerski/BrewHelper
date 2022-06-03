namespace BrewHelper.Business.Miscs;

using System.Linq;
using System.Threading.Tasks;
using BrewHelper.Data.Entities;

public interface IMiscService
{
    /// <summary>
    /// Get a list of miscs.
    /// </summary>
    /// <returns>An IQueryable with miscs.</returns>
    public IQueryable<Misc> GetMiscs();

    /// <summary>
    /// Get a single Misc by Id.
    /// </summary>
    /// <returns>A Misc or notFound.</returns>
    public Task<Misc> GetMisc(long id);

    /// <summary>
    /// Create a hop.
    /// </summary>
    /// <param name="misc">The misc to create.</param>
    /// <returns>The created misc.</returns>
    public Task<Misc> CreateMisc(Misc misc);

    /// <summary>
    /// Create a new version of a misc.
    /// </summary>
    /// <param name="misc">The misc to create a new version of.</param>
    /// <returns>The newly created misc version.</returns>
    public Task<Misc> CreateMiscVersion(Misc misc);

    /// <summary>
    /// Update a hop.
    /// </summary>
    /// <param name="misc">Updated misc.</param>
    /// <returns>The updated misc.</returns>
    public Task<Misc> UpdateMisc(Misc misc);

    /// <summary>
    /// Delete a hop.
    /// </summary>
    /// <param name="id">The id of the hop to delete.</param>
    public Task DeleteMisc(long id);

    /// <summary>
    /// Check whether a Misc is used in a recipe.
    /// </summary>
    /// <param name="misc">The misc to check.</param>
    /// <returns>True if the misc is used in a recipe.</returns>
    public Task<bool> MiscInUse(Misc misc);
}