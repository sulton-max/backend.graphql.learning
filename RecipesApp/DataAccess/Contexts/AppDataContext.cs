using Microsoft.EntityFrameworkCore;
using RecipesApp.DataAccess.DataConfigurations;
using RecipesApp.Models.Entities;

namespace RecipesApp.DataAccess.DataContexts;

public class AppDataContext : DbContext
{
    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<Step> Steps { get; set; }

    public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(RecipeConfiguration).Assembly);
    }
}