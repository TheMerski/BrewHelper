using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrewHelper.Models
{
    public class BrewhelperContext : DbContext
    {
        public BrewhelperContext(DbContextOptions<BrewhelperContext> options): base(options)
        {
        }
        
        public DbSet<Ingredient> Ingredients { get; set; }

        public DbSet<Recipe> Recipes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Recipe>()
                .HasMany(r => r.MashSteps)
                .WithOne();

            modelBuilder.Entity<RecipeIngredient>()
                .Navigation(r => r.Ingredient)
                .UsePropertyAccessMode(PropertyAccessMode.Property);
        }

    }
}
