namespace BrewHelper.Business.Fermentables;

using System.Linq;
using System.Threading.Tasks;
using BrewHelper.Data.Entities;

public interface IFermentableService
{
    /// <summary>
    /// Get a list of fermentables.
    /// </summary>
    /// <returns>An IQueryable with fermentables.</returns>
    public IQueryable<Fermentable> GetFermentables();

    /// <summary>
    /// Get a single fermentable by Id.
    /// </summary>
    /// <returns>A Fermentable or notFound.</returns>
    public Task<Fermentable> GetFermentable(long id);

    /// <summary>
    /// Create a fermentable.
    /// </summary>
    /// <param name="fermentable">The fermentable to create.</param>
    /// <returns>The created fermentable.</returns>
    public Task<Fermentable> CreateFermentable(Fermentable fermentable);

    /// <summary>
    /// Create a new version of a fermentable.
    /// </summary>
    /// <param name="fermentable">The fermentable to create a new version of.</param>
    /// <returns>The newly created fermentable version.</returns>
    public Task<Fermentable> CreateFermentableVersion(Fermentable fermentable);

    /// <summary>
    /// Update a fermentable.
    /// </summary>
    /// <param name="fermentable">Updated fermentable.</param>
    /// <returns>The updated fermentable.</returns>
    public Task<Fermentable> UpdateFermentable(Fermentable fermentable);

    /// <summary>
    /// Delete a fermentable.
    /// </summary>
    /// <param name="fermentable">The fermentable to delete.</param>
    public Task DeleteFermentable(Fermentable fermentable);

    /// <summary>
    /// Check wether a fermentable is used in a recipe.
    /// </summary>
    /// <param name="fermentable">The fermentable to check.</param>
    /// <returns>True if the fermentable is used in a recipe.</returns>
    public Task<bool> FermentableInUse(Fermentable fermentable);
}