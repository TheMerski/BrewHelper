using System.Threading;
using System.Threading.Tasks;
using BrewHelper.DTO;
using BrewHelper.Entities;

namespace BrewHelper.Interfaces
{
    public interface IBrewLogModel
    {
        /// <summary>
        /// Get BrewLogs by page
        /// </summary>
        /// <param name="limit">Limit per page</param>
        /// <param name="page">The page to get</param>
        /// <param name="ids">Id's of logs to get</param>
        /// <param name="cancellationToken">CancellationToken</param>
        /// <returns>A page with BrewLogs</returns>
        public Task<GenericListResponseDTO<BrewLog>> GetByPageAsync(int limit, int page, long[]? ids,
            CancellationToken cancellationToken);

        /// <summary>
        /// Get a single BrewLog by id
        /// </summary>
        /// <param name="id">Id of the BrewLog to get</param>
        /// <returns>The BrewLog or default</returns>
        public Task<BrewLog?> GetById(long id);

        /// <summary>
        /// Start a new BrewLog from a recipe
        /// </summary>
        /// <param name="recipeId">Id of the Recipe to start brewing</param>
        /// <returns>The Id of the created BrewLog</returns>
        public Task<BrewLog> StartLog(long recipeId);
        
        /// <summary>
        /// Initialize the next step for the log
        /// </summary>
        /// <param name="id">Id of the BrewLog to start next step for</param>
        /// <returns>BrewLog with next step</returns>
        public Task<BrewLog> StartNextStep(long id);

        /// <summary>
        /// Update a BrewLog
        /// </summary>
        /// <param name="id">Id of the BrewLog to update</param>
        /// <param name="log">The updated BrewLog</param>
        /// <returns>The updated BrewLog from the db</returns>
        public Task<BrewLog?> Update(long id, BrewLog log);

        /// <summary>
        /// Delete a BrewLog by id
        /// </summary>
        /// <param name="id">The Id of the BrewLog to delete</param>
        /// <returns>A boolean indicating success</returns>
        public Task<bool> Delete(long id);
    }
}