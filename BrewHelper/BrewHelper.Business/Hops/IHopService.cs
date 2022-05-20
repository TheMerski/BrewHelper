namespace BrewHelper.Business.Hops;

using System.Linq;
using System.Threading.Tasks;
using BrewHelper.Data.Entities;

public interface IHopService
{
    /// <summary>
    /// Get a list of hops.
    /// </summary>
    /// <returns>An IQueryable with hops.</returns>
    public IQueryable<Hop> GetHops();

    /// <summary>
    /// Get a single Hop by Id.
    /// </summary>
    /// <returns>A Hop or notFound.</returns>
    public Task<Hop> GetHop(long id);

    /// <summary>
    /// Create a hop.
    /// </summary>
    /// <param name="hop">The hop to create.</param>
    /// <returns>The created hop.</returns>
    public Task<Hop> CreateHop(Hop hop);

    /// <summary>
    /// Create a new version of a hop.
    /// </summary>
    /// <param name="hop">The hop to create a new version of.</param>
    /// <returns>The newly created hop version.</returns>
    public Task<Hop> CreateHopVersion(Hop hop);

    /// <summary>
    /// Update a hop.
    /// </summary>
    /// <param name="hop">Updated hop.</param>
    /// <returns>The updated hop.</returns>
    public Task<Hop> UpdateHop(Hop hop);

    /// <summary>
    /// Delete a hop.
    /// </summary>
    /// <param name="id">The id of the hop to delete.</param>
    public Task DeleteHop(long id);

    /// <summary>
    /// Check wether a Hop is used in a recipe.
    /// </summary>
    /// <param name="hop">The hop to check.</param>
    /// <returns>True if the hop is used in a recipe.</returns>
    public Task<bool> HopInUse(Hop hop);
}