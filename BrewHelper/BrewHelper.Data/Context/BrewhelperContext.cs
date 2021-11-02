using BrewHelper.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BrewHelper.Data.Context
{
    public class BrewhelperContext : DbContext
    {
        public BrewhelperContext(DbContextOptions<BrewhelperContext> options) : base(options)
        {
        }

        public DbSet<Ingredient> Ingredients { get; set; } = null!;

        public DbSet<Recipe> Recipes { get; set; } = null!;

        public DbSet<RecipeStep> RecipeSteps { get; set; } = null!;

        public DbSet<BrewLog> BrewLogs { get; set; } = null!;

        public DbSet<StepLog> StepLogs { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.ConfigureWarnings(w => w.Throw(RelationalEventId.MultipleCollectionIncludeWarning));
            base.OnConfiguring(optionsBuilder);
        }
    }
}
