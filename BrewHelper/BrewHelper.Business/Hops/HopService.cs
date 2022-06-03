namespace BrewHelper.Business.Hops;

using System;
using System.Linq;
using System.Threading.Tasks;
using BrewHelper.Business.Exceptions;
using BrewHelper.Business.Fermentables;
using BrewHelper.Data.Context;
using BrewHelper.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

public class HopService : IHopService
{
    private readonly ILogger<HopService> logger;
    private readonly BrewhelperContext context;

    public HopService(ILogger<HopService> logger, BrewhelperContext context)
    {
        this.logger = logger;
        this.context = context;
    }

    public IQueryable<Hop> GetHops()
    {
        try
        {
            return this.context.Hops.AsSplitQuery().AsNoTracking().AsQueryable();
        }
        catch (Exception e)
        {
            this.logger.LogError(e, "Something went wrong getting hops");
            throw new Exception("Something went wrong when getting hops");
        }
    }

    public async Task<Hop> GetHop(long id)
    {
        var hop = await this.context.Hops.FirstOrDefaultAsync(f => f.Id == id);
        if (hop == null)
        {
            this.logger.LogWarning("Hop could not be found");
            throw new NotFoundException<Hop>();
        }

        return hop;
    }

    public async Task<Hop> CreateHop(Hop hop)
    {
        if (await this.context.Hops.AnyAsync((f) => f.Name == hop.Name))
        {
            throw new NameAlreadyExistsException<Hop>();
        }

        try
        {
            this.context.Hops.Add(hop);
            await this.context.SaveChangesAsync();
            return hop;
        }
        catch (Exception e)
        {
            this.logger.LogError(e, "Something went wrong when creating hop");
            throw new Exception("Something went wrong during creation");
        }
    }

    public async Task<Hop> CreateHopVersion(Hop hop)
    {
        await this.HopExists(hop);

        try
        {
            // Get the latest version for this.
            int latestVersion = await this.context.Hops.AsNoTracking().Where((f) => f.Name == hop.Name).MaxAsync(f => f.Version);

            Hop newHop = hop.Clone();
            newHop.Id = default;                      // Set id to 0, this will be set by EF
            newHop.Version = latestVersion + 1; // New version is latest version + 1

            this.context.Hops.Add(newHop);
            await this.context.SaveChangesAsync();
            return newHop;
        }
        catch (Exception e)
        {
            this.logger.LogError(e, "Something went wrong when creating Hop version");
            throw new Exception("Something went wrong during version creation");
        }
    }

    public async Task<Hop> UpdateHop(Hop hop)
    {
        try
        {
            await this.HopExists(hop);

            if (await this.HopInUse(hop))
            {
                // If it is in use verify only update the Notes & StockAmount.
                Hop dbHop = await this.context.Hops.Where((f) => f.Id == hop.Id).FirstAsync();
                dbHop.Notes = hop.Notes;
                dbHop.StockAmount = hop.StockAmount;
                await this.context.SaveChangesAsync();

                return dbHop;
            }
            else
            {
                // If it is not in use update the entry.
                this.context.Hops.Update(hop);
                await this.context.SaveChangesAsync();

                return hop;
            }
        }
        catch (Exception e)
        {
            this.logger.LogError(e, "Something went wrong when updating hop");
            throw new Exception("Something went wrong during updating");
        }
    }

    public async Task DeleteHop(long id)
    {
        var hop = await this.GetHop(id);

        try
        {
            this.context.Hops.Remove(hop);
            await this.context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            this.logger.LogError(e, "Something went wrong when deleting Hop");
            throw new Exception("Something went wrong during deletion");
        }
    }

    /// <summary>
    /// Check wether the hop is in use.
    /// </summary>
    /// <returns>True if the hop is used in a recipe.</returns>
    public async Task<bool> HopInUse(Hop hop)
    {
        return await this.context.Recipes.AsNoTracking().Where((r) => r.Hops.Any((rf) => rf.Ingredient.Id == hop.Id)).AnyAsync();
    }

    /// <summary>
    /// Checks whether a hop exists.
    /// </summary>
    /// <param name="hop">The hop to check for.</param>
    /// <exception cref="NotFoundException{Hop}">Exception thrown when the hop does not exists.</exception>
    private async Task HopExists(Hop hop)
    {
        if (!await this.context.Hops.AnyAsync((f) => f.Id == hop.Id))
        {
            this.logger.LogWarning("Hop could not be found");
            throw new NotFoundException<Hop>();
        }
    }
}