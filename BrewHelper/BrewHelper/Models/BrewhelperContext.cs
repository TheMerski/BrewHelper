using BrewHelper.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace BrewHelper.Models
{
    public class BrewhelperContext : DbContext
    {
        public BrewhelperContext(DbContextOptions<BrewhelperContext> options) : base(options)
        {
        }

        public DbSet<Ingredient> Ingredients { get; set; }

        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<RecipeStep> RecipeSteps { get; set; }

        public DbSet<BrewLog> BrewLogs { get; set; }

        public DbSet<StepLog> StepLogs { get; set; }

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
