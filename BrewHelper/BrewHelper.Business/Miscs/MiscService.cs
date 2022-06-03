namespace BrewHelper.Business.Miscs;

using System;
using System.Linq;
using System.Threading.Tasks;
using BrewHelper.Business.Exceptions;
using BrewHelper.Business.Fermentables;
using BrewHelper.Business.Miscs;
using BrewHelper.Data.Context;
using BrewHelper.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

public class MiscService : IMiscService
{
    private readonly ILogger<MiscService> logger;
    private readonly BrewhelperContext context;

    public MiscService(ILogger<MiscService> logger, BrewhelperContext context)
    {
        this.logger = logger;
        this.context = context;
    }

    public IQueryable<Misc> GetMiscs()
    {
        try
        {
            return this.context.Miscs.AsSplitQuery().AsNoTracking().AsQueryable();
        }
        catch (Exception e)
        {
            this.logger.LogError(e, "Something went wrong getting miscs");
            throw new Exception("Something went wrong when getting miscs");
        }
    }

    public async Task<Misc> GetMisc(long id)
    {
        var misc = await this.context.Miscs.FirstOrDefaultAsync(f => f.Id == id);
        if (misc == null)
        {
            this.logger.LogWarning("Misc could not be found");
            throw new NotFoundException<Misc>();
        }

        return misc;
    }

    public async Task<Misc> CreateMisc(Misc misc)
    {
        if (await this.context.Miscs.AnyAsync((f) => f.Name == misc.Name))
        {
            throw new NameAlreadyExistsException<Misc>();
        }

        try
        {
            this.context.Miscs.Add(misc);
            await this.context.SaveChangesAsync();
            return misc;
        }
        catch (Exception e)
        {
            this.logger.LogError(e, "Something went wrong when creating misc");
            throw new Exception("Something went wrong during creation");
        }
    }

    public async Task<Misc> CreateMiscVersion(Misc misc)
    {
        await this.MiscExists(misc);

        try
        {
            // Get the latest version for this.
            int latestVersion = await this.context.Miscs.AsNoTracking().Where((f) => f.Name == misc.Name).MaxAsync(f => f.Version);

            Misc newMisc = misc.Clone();
            newMisc.Id = default;                      // Set id to 0, this will be set by EF
            newMisc.Version = latestVersion + 1; // New version is latest version + 1

            this.context.Miscs.Add(newMisc);
            await this.context.SaveChangesAsync();
            return newMisc;
        }
        catch (Exception e)
        {
            this.logger.LogError(e, "Something went wrong when creating Misc version");
            throw new Exception("Something went wrong during version creation");
        }
    }

    public async Task<Misc> UpdateMisc(Misc misc)
    {
        try
        {
            await this.MiscExists(misc);

            if (await this.MiscInUse(misc))
            {
                // If it is in use verify only update the Notes & StockAmount.
                Misc dbMisc = await this.context.Miscs.Where((f) => f.Id == misc.Id).FirstAsync();
                dbMisc.Notes = misc.Notes;
                dbMisc.StockAmount = misc.StockAmount;
                await this.context.SaveChangesAsync();

                return dbMisc;
            }
            else
            {
                // If it is not in use update the entry.
                this.context.Miscs.Update(misc);
                await this.context.SaveChangesAsync();

                return misc;
            }
        }
        catch (Exception e)
        {
            this.logger.LogError(e, "Something went wrong when updating misc");
            throw new Exception("Something went wrong during updating");
        }
    }

    public async Task DeleteMisc(long id)
    {
        var misc = await this.GetMisc(id);

        try
        {
            this.context.Miscs.Remove(misc);
            await this.context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            this.logger.LogError(e, "Something went wrong when deleting Misc");
            throw new Exception("Something went wrong during deletion");
        }
    }

    /// <summary>
    /// Check wether the misc is in use.
    /// </summary>
    /// <returns>True if the misc is used in a recipe.</returns>
    public async Task<bool> MiscInUse(Misc misc)
    {
        return await this.context.Recipes.AsNoTracking().Where((r) => r.Miscs.Any((rf) => rf.Ingredient.Id == misc.Id)).AnyAsync();
    }

    /// <summary>
    /// Checks whether a misc exists.
    /// </summary>
    /// <param name="misc">The misc to check for.</param>
    /// <exception cref="NotFoundException{Misc}">Exception thrown when the misc does not exists.</exception>
    private async Task MiscExists(Misc misc)
    {
        if (!await this.context.Miscs.AnyAsync((f) => f.Id == misc.Id))
        {
            this.logger.LogWarning("Misc could not be found");
            throw new NotFoundException<Misc>();
        }
    }
}