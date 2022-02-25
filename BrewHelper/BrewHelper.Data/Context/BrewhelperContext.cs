namespace BrewHelper.Data.Context
{
    using BeerXMLSharp.OM.Records;
    using BrewHelper.Data.Entities;
    using Microsoft.EntityFrameworkCore;

    public class BrewhelperContext : DbContext
    {
        public BrewhelperContext(DbContextOptions<BrewhelperContext> options)
            : base(options)
        {
        }

        public DbSet<Equipment> Equipments { get; set; } = null!;

        public DbSet<Fermentable> Fermentables { get; set; } = null!;

        public DbSet<Hop> Hops { get; set; } = null!;

        public DbSet<Misc> Miscs { get; set; } = null!;

        public DbSet<BrewHelperRecipe> Recipes { get; set; } = null!;

        public DbSet<Style> Styles { get; set; } = null!;

        public DbSet<Water> Water { get; set; } = null!;

        public DbSet<Yeast> Yeasts { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Equipment>()
                .HasKey((e) => new { e.Name, e.Version });

            modelBuilder.Entity<Fermentable>()
                .HasKey((e) => new { e.Name, e.Version });

            modelBuilder.Entity<Hop>()
                .HasKey((e) => new { e.Name, e.Version });

            modelBuilder.Entity<Misc>()
                .HasKey((e) => new { e.Name, e.Version });

            modelBuilder.Entity<Style>()
                .HasKey((e) => new { e.Name, e.Version });

            modelBuilder.Entity<Water>()
                .HasKey((e) => new { e.Name, e.Version });

            modelBuilder.Entity<Yeast>()
                .HasKey((e) => new { e.Name, e.Version });
        }
    }
}
