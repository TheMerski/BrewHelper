using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BrewHelper.DTO;
using BrewHelper.Entities;
using BrewHelper.Exceptions;
using BrewHelper.Extensions;
using BrewHelper.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BrewHelper.Models
{
    public class BrewLogModel : IBrewLogModel
    {
        private readonly BrewhelperContext _context;

        public BrewLogModel(BrewhelperContext injectedContext)
        {
            _context = injectedContext;
        }

        public async Task<GenericListResponseDTO<BrewLog>> GetByPageAsync(int limit, int page, long[] ids, CancellationToken cancellationToken)
        {
            var query = _context.BrewLogs.AsNoTracking();

            if (ids != null && ids.Length > 0)
            {
                query = query.Where(l => ids.Contains(l.Id));
            }

            var logs = await query.OrderBy(l => l.StartDate).PaginateAsync(page, limit, cancellationToken);

            return new GenericListResponseDTO<BrewLog>
            {
                CurrentPage = logs.CurrentPage,
                TotalItems = logs.TotalItems,
                TotalPages = logs.TotalPages,
                Items = logs.Items
            };
        }

        public async Task<BrewLog> GetById(long id)
        {
            return await _context.BrewLogs
                .Include(l => l.MashingLog).ThenInclude(sl => sl.PhMeasurements)
                .Include(l => l.MashingLog).ThenInclude(sl => sl.SgMeasurements)
                .Include(l => l.MashingLog).ThenInclude(sl => sl.TemperatureMeasurements)
                .Include(l => l.BoilingLog).ThenInclude(sl => sl.PhMeasurements)
                .Include(l => l.BoilingLog).ThenInclude(sl => sl.SgMeasurements)
                .Include(l => l.BoilingLog).ThenInclude(sl => sl.TemperatureMeasurements)
                .Include(l => l.YeastingLog).ThenInclude(sl => sl.PhMeasurements)
                .Include(l => l.YeastingLog).ThenInclude(sl => sl.SgMeasurements)
                .Include(l => l.YeastingLog).ThenInclude(sl => sl.TemperatureMeasurements)
                .Where(l => l.Id == id)
                .FirstOrDefaultAsync();
        }
        
        /// <exception cref="RecipeNotFoundException">Thrown when Recipe is not found</exception>
        public async Task<BrewLog> StartLog(long recipeId)
        {
            Recipe logRecipe = await _context.Recipes.Where(r => r.Id == recipeId).FirstOrDefaultAsync();
            if (logRecipe == null)
                throw new RecipeNotFoundException();

            BrewLog log = new()
            {
                Recipe = logRecipe,
                StartDate = DateTime.UtcNow,
                Notes = string.Empty
            };

            await _context.BrewLogs.AddAsync(log);
            await _context.SaveChangesAsync();
            return log;
        }

        public async Task<BrewLog> StartNextStep(long id)
        {
            if (!await BrewLogExists(id))
            {
                throw new BrewLogNotFoundException();
            }
            
            BrewLog log = await GetById(id);
            if (log.MashingLog != null && log.BoilingLog != null && log.YeastingLog != null)
                return log;

            log.InitializeNextStep();
            await _context.SaveChangesAsync();
            return log;
        }

        public async Task<BrewLog> Update(long id, BrewLog log)
        {
            if (log.MashingLog?.Id <= 0) log.MashingLog = null;
            if (log.BoilingLog?.Id <= 0) log.BoilingLog = null;
            if (log.YeastingLog?.Id <= 0) log.YeastingLog = null;
            if (log.MashingLog != null) await _context.Entry(log.MashingLog).ReloadAsync();
            if (log.BoilingLog != null) await _context.Entry(log.BoilingLog).ReloadAsync();
            if (log.YeastingLog != null) await _context.Entry(log.YeastingLog).ReloadAsync();
            
            _context.Entry(log).State = EntityState.Modified;


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await BrewLogExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            await _context.Entry(log).ReloadAsync();
            return log;
        }

        public async Task<bool> Delete(long id)
        {
            BrewLog log = await _context.BrewLogs.FindAsync(id);
            if (log == null)
            {
                return false;
            }

            _context.BrewLogs.Remove(log);
            await _context.SaveChangesAsync();

            return true;
        }

        private async Task<bool> BrewLogExists(long id)
        {
            return await _context.BrewLogs.AnyAsync(l => l.Id == id);
        }
    }
}