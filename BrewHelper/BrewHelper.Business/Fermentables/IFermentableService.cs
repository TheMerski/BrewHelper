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
    /// Create a fermentable.
    /// </summary>
    /// <param name="fermentable">The fermentable to create.</param>
    /// <returns>The created fermentable.</returns>
    public Task<Fermentable> CreateFermentable(Fermentable fermentable);

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
}