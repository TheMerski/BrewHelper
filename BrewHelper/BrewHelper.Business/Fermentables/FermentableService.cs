namespace BrewHelper.Business.Fermentables;

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
        return this.context.Fermentables.AsSplitQuery().AsNoTracking().AsQueryable();
    }

    public async Task<Fermentable> CreateFermentable(Fermentable fermentable)
    {
        if (await this.context.Fermentables.AnyAsync((f) => f.Name == fermentable.Name && f.Version == fermentable.Version))
        {
            throw new NameAlreadyExistsException<Fermentable>();
        }

        this.context.Fermentables.Add(fermentable);
        await this.context.SaveChangesAsync();
        return fermentable;
    }
}