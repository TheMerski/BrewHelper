namespace BrewHelper.Business.Yeasts;

using System;
using System.Linq;
using System.Threading.Tasks;
using BrewHelper.Business.Exceptions;
using BrewHelper.Business.Fermentables;
using BrewHelper.Business.Yeasts;
using BrewHelper.Data.Context;
using BrewHelper.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

public class YeastService : IYeastService
{
    private readonly ILogger<YeastService> logger;
    private readonly BrewhelperContext context;

    public YeastService(ILogger<YeastService> logger, BrewhelperContext context)
    {
        this.logger = logger;
        this.context = context;
    }

    public IQueryable<Yeast> GetYeasts()
    {
        try
        {
            return this.context.Yeasts.AsSplitQuery().AsNoTracking().AsQueryable();
        }
        catch (Exception e)
        {
            this.logger.LogError(e, "Something went wrong getting yeasts");
            throw new Exception("Something went wrong when getting yeasts");
        }
    }

    public async Task<Yeast> GetYeast(long id)
    {
        var yeast = await this.context.Yeasts.FirstOrDefaultAsync(f => f.Id == id);
        if (yeast == null)
        {
            this.logger.LogWarning("Yeast could not be found");
            throw new NotFoundException<Yeast>();
        }

        return yeast;
    }

    public async Task<Yeast> CreateYeast(Yeast yeast)
    {
        if (await this.context.Yeasts.AnyAsync((f) => f.Name == yeast.Name))
        {
            throw new NameAlreadyExistsException<Yeast>();
        }

        try
        {
            this.context.Yeasts.Add(yeast);
            await this.context.SaveChangesAsync();
            return yeast;
        }
        catch (Exception e)
        {
            this.logger.LogError(e, "Something went wrong when creating yeast");
            throw new Exception("Something went wrong during creation");
        }
    }

    public async Task<Yeast> CreateYeastVersion(Yeast yeast)
    {
        await this.YeastExists(yeast);

        try
        {
            // Get the latest version for this.
            int latestVersion = await this.context.Yeasts.AsNoTracking().Where((f) => f.Name == yeast.Name).MaxAsync(f => f.Version);

            Yeast newYeast = yeast.Clone();
            newYeast.Id = default;                      // Set id to 0, this will be set by EF
            newYeast.Version = latestVersion + 1; // New version is latest version + 1

            this.context.Yeasts.Add(newYeast);
            await this.context.SaveChangesAsync();
            return newYeast;
        }
        catch (Exception e)
        {
            this.logger.LogError(e, "Something went wrong when creating Yeast version");
            throw new Exception("Something went wrong during version creation");
        }
    }

    public async Task<Yeast> UpdateYeast(Yeast yeast)
    {
        try
        {
            await this.YeastExists(yeast);

            if (await this.YeastInUse(yeast))
            {
                // If it is in use verify only update the Notes & StockAmount.
                Yeast dbYeast = await this.context.Yeasts.Where((f) => f.Id == yeast.Id).FirstAsync();
                dbYeast.Notes = yeast.Notes;
                dbYeast.StockAmount = yeast.StockAmount;
                await this.context.SaveChangesAsync();

                return dbYeast;
            }
            else
            {
                // If it is not in use update the entry.
                this.context.Yeasts.Update(yeast);
                await this.context.SaveChangesAsync();

                return yeast;
            }
        }
        catch (Exception e)
        {
            this.logger.LogError(e, "Something went wrong when updating yeast");
            throw new Exception("Something went wrong during updating");
        }
    }

    public async Task DeleteYeast(long id)
    {
        var yeast = await this.GetYeast(id);

        try
        {
            this.context.Yeasts.Remove(yeast);
            await this.context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            this.logger.LogError(e, "Something went wrong when deleting Yeast");
            throw new Exception("Something went wrong during deletion");
        }
    }

    /// <summary>
    /// Check wether the yeast is in use.
    /// </summary>
    /// <returns>True if the yeast is used in a recipe.</returns>
    public async Task<bool> YeastInUse(Yeast yeast)
    {
        return await this.context.Recipes.AsNoTracking().Where((r) => r.Yeasts.Any((rf) => rf.Ingredient.Id == yeast.Id)).AnyAsync();
    }

    /// <summary>
    /// Checks whether a yeast exists.
    /// </summary>
    /// <param name="yeast">The yeast to check for.</param>
    /// <exception cref="NotFoundException{Yeast}">Exception thrown when the yeast does not exists.</exception>
    private async Task YeastExists(Yeast yeast)
    {
        if (!await this.context.Yeasts.AnyAsync((f) => f.Id == yeast.Id))
        {
            this.logger.LogWarning("Yeast could not be found");
            throw new NotFoundException<Yeast>();
        }
    }
}