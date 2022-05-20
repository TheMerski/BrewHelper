namespace BrewHelper.Business.Fermentables;

using System;
using System.Linq;
using System.Threading.Tasks;
using BrewHelper.Business.Exceptions;
using BrewHelper.Business.Recipes;
using BrewHelper.Data.Context;
using BrewHelper.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

public class FermentableService : IFermentableService
{
    private readonly ILogger<FermentableService> logger;
    private readonly BrewhelperContext context;

    public FermentableService(ILogger<FermentableService> logger, BrewhelperContext context)
    {
        this.logger = logger;
        this.context = context;
    }

    public IQueryable<Fermentable> GetFermentables()
    {
        try
        {
            return this.context.Fermentables.AsSplitQuery().AsNoTracking().AsQueryable();
        }
        catch (Exception e)
        {
            this.logger.LogError(e, "Something went wrong getting fermentables");
            throw new Exception("Something went wrong when getting fermentables");
        }
    }

    public async Task<Fermentable> GetFermentable(long id)
    {
        var fermentable = await this.context.Fermentables.FirstOrDefaultAsync(f => f.Id == id);
        if (fermentable == null)
        {
            this.logger.LogWarning("Fermentable could not be found");
            throw new NotFoundException<Fermentable>();
        }

        return fermentable;
    }

    public async Task<Fermentable> CreateFermentable(Fermentable fermentable)
    {
        if (await this.context.Fermentables.AnyAsync((f) => f.Name == fermentable.Name))
        {
            throw new NameAlreadyExistsException<Fermentable>();
        }

        try
        {
            this.context.Fermentables.Add(fermentable);
            await this.context.SaveChangesAsync();
            return fermentable;
        }
        catch (Exception e)
        {
            this.logger.LogError("Something went wrong when creating fermentable", new { e, fermentable });
            throw new Exception("Something went wrong during creation");
        }
    }

    public async Task<Fermentable> CreateFermentableVersion(Fermentable fermentable)
    {
        await this.FermentableExists(fermentable);

        try
        {
            // Get the latest version for this fermentable.
            int latestVersion = await this.context.Fermentables.AsNoTracking().Where((f) => f.Name == fermentable.Name).MaxAsync(f => f.Version);

            Fermentable newFermentable = fermentable.Clone();
            newFermentable.Id = default;                      // Set id to 0, this will be set by EF
            newFermentable.Version = latestVersion + 1; // New version is latest version + 1

            this.context.Fermentables.Add(newFermentable);
            await this.context.SaveChangesAsync();
            return fermentable;
        }
        catch (Exception e)
        {
            this.logger.LogError(e, "Something went wrong when creating fermentable version");
            throw new Exception("Something went wrong during version creation");
        }
    }

    public async Task<Fermentable> UpdateFermentable(Fermentable fermentable)
    {
        try
        {
            await this.FermentableExists(fermentable);

            if (await this.FermentableInUse(fermentable))
            {
                // If it is in use verify only update the Notes & StockAmount.
                Fermentable dbFermentable = await this.context.Fermentables.Where((f) => f.Id == fermentable.Id).FirstAsync();
                dbFermentable.Notes = fermentable.Notes;
                dbFermentable.StockAmount = fermentable.StockAmount;
                await this.context.SaveChangesAsync();

                return dbFermentable;
            }
            else
            {
                // If it is not in use update the entry.
                this.context.Fermentables.Update(fermentable);
                await this.context.SaveChangesAsync();

                return fermentable;
            }
        }
        catch (Exception e)
        {
            this.logger.LogError("Something went wrong when updating fermentable", new { e, fermentable });
            throw new Exception("Something went wrong during updating");
        }
    }

    public async Task DeleteFermentable(long fermentableId)
    {
        var fermentable = await this.GetFermentable(fermentableId);

        try
        {
            this.context.Fermentables.Remove(fermentable);
            await this.context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            this.logger.LogError(e, "Something went wrong when deleting fermentable");
            throw new Exception("Something went wrong during deletion");
        }
    }

    /// <summary>
    /// Check wether the fermentable is in use.
    /// </summary>
    /// <returns>True if the fermentable is used in a recipe.</returns>
    public async Task<bool> FermentableInUse(Fermentable fermentable)
    {
        return await this.context.Recipes.AsNoTracking().Where((r) => r.Fermentables.Any((rf) => rf.Ingredient.Id == fermentable.Id)).AnyAsync();
    }

    /// <summary>
    /// Checks wether a fermentable exists.
    /// </summary>
    /// <param name="fermentable">The fermentable to check for.</param>
    /// <exception cref="NotFoundException{Fermentable}">Exception thrown when the fermentable does not exists.</exception>
    private async Task FermentableExists(Fermentable fermentable)
    {
        if (!await this.context.Fermentables.AnyAsync((f) => f.Id == fermentable.Id))
        {
            this.logger.LogWarning("Fermentable could not be found");
            throw new NotFoundException<Fermentable>();
        }
    }
}