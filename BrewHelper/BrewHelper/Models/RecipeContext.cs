using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrewHelper.Models
{
    public class RecipeContext : DbContext
    {
        public RecipeContext(DbContextOptions<RecipeContext> options): base(options)
        {
        }
        
        public DbSet<Ingredient> Ingredients { get; set; }

        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<RecipeStep> RecipeSteps { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Recipe>(b =>
            {
                b.Property(r => r.Name).IsRequired();

                b.Property(r => r.MashIngredients)
                    .HasConversion(
                        d => JsonConvert.SerializeObject(d, Formatting.None),
                        s => JsonConvert.DeserializeObject<Dictionary<Ingredient, int>>(s)
                    )
                    .HasMaxLength(4000);
            });

            modelBuilder.Entity<RecipeStep>(b =>
            {
                b.Property(r => r.Name).IsRequired();

                b.Property(r => r.Ingredients)
                    .HasConversion(
                        d => JsonConvert.SerializeObject(d, Formatting.None),
                        s => JsonConvert.DeserializeObject<Dictionary<Ingredient, int>>(s)
                    )
                    .HasMaxLength(4000);
            });
        }
    }
}
