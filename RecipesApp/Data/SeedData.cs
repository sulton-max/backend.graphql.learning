using Bogus;
using Microsoft.EntityFrameworkCore;
using RecipesApp.DataAccess.DataContexts;
using RecipesApp.Models.Entities;
using Tynamix.ObjectFiller;

namespace RecipesApp.Data;

public static class SeedData
{
    public static async Task InitializeData(this IServiceProvider serviceProvider)
    {
        var appDataContext = serviceProvider.GetRequiredService<AppDataContext>();
        var random = new Random();

        if (!appDataContext.Recipes.Any())
        {
            var recipeFaker = new Faker<Recipe>().RuleFor(x => x.Id, Guid.NewGuid)
                .RuleFor(x => x.Name, () => new MnemonicString(1, 8, 20).GetValue())
                .RuleFor(x => x.Description, () => new MnemonicString(10, 8, 20).GetValue());

            var recipes = recipeFaker.Generate(1000);
            await appDataContext.AddRangeAsync(recipes);
            await appDataContext.SaveChangesAsync();
        }

        if (!appDataContext.Ingredients.Any())
        {
            var recipes = await appDataContext.Recipes.ToListAsync();
            var ingredientFaker = new Faker<Ingredient>().RuleFor(x => x.Id, Guid.NewGuid)
                .RuleFor(x => x.Name, () => new MnemonicString(3, 8, 20).GetValue())
                .RuleFor(x => x.WholeQuantity, random.Next(1, 20))
                .RuleFor(x => x.Measurement, () => new MnemonicString(3, 8, 20).GetValue());

            var ingredients = ingredientFaker.Generate(1000);
            await appDataContext.AddRangeAsync(ingredients);
            await appDataContext.SaveChangesAsync();

            recipes.ForEach(x => x.Ingredients = ingredients.Skip(random.Next(0, 900)).Take(random.Next(2, 20)).ToList());
            await appDataContext.SaveChangesAsync();
        }

        if (!appDataContext.Steps.Any())
        {
            var recipes = await appDataContext.Recipes.ToListAsync();
            var ingredients = await appDataContext.Ingredients.ToListAsync();

            var stepFaker = new Faker<Step>().RuleFor(x => x.Id, Guid.NewGuid)
                .RuleFor(x => x.Order, random.Next(1, 20))
                .RuleFor(x => x.Duration, () => TimeSpan.FromMinutes(random.Next(1, 20)))
                .RuleFor(x => x.Instructions, () => new MnemonicString(3, 8, 20).GetValue());

            var steps = stepFaker.Generate(1000);
            await appDataContext.AddRangeAsync(steps);
            await appDataContext.SaveChangesAsync();

            recipes.ForEach(x => x.Steps = steps.Skip(random.Next(0, 900)).Take(random.Next(2, 20)).ToList());
            await appDataContext.SaveChangesAsync();
        }
    }
}