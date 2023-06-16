using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RecipesApp.Models.Entities;

namespace RecipesApp.DataAccess.DataConfigurations;

public class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
{
    public void Configure(EntityTypeBuilder<Recipe> builder)
    {
        builder.HasMany<Ingredient>().WithOne();
        builder.HasMany<Step>().WithOne();
    }
}