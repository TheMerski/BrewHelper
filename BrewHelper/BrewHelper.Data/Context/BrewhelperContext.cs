﻿namespace BrewHelper.Data.Context
{
    using BrewHelper.Data.Entities;
    using Microsoft.EntityFrameworkCore;

    public class BrewhelperContext : DbContext
    {
        public BrewhelperContext(DbContextOptions<BrewhelperContext> options)
            : base(options)
        {
        }

        public DbSet<Recipe> Recipes { get; set; } = null!;

        public DbSet<Fermentable> Fermentables { get; set; } = null!;

        public DbSet<Hop> Hops { get; set; } = null!;

        public DbSet<Yeast> Yeasts { get; set; } = null!;

        public DbSet<Water> Waters { get; set; } = null!;

        public DbSet<Misc> Miscs { get; set; } = null!;

        public DbSet<Style> Styles { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Recipe>()
                .OwnsMany((e) => e.Fermentables);

            modelBuilder.Entity<Recipe>()
                .OwnsMany((e) => e.Hops);

            modelBuilder.Entity<Recipe>()
                .OwnsMany((e) => e.Miscs);

            modelBuilder.Entity<Recipe>()
                .OwnsMany((e) => e.Waters);

            modelBuilder.Entity<Recipe>()
                .OwnsMany((e) => e.Yeasts);

            modelBuilder.Entity<Recipe>()
                .OwnsOne((e) => e.Style);

            modelBuilder.Entity<Recipe>()
                .OwnsOne((e) => e.Mash)
                .OwnsMany((m) => m.MashSteps);
        }
    }
}
