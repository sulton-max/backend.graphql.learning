using BasicGraphQL.DataAccess.Contexts;
using BasicGraphQL.Models.Entities;
using Bogus;
using Tynamix.ObjectFiller;

namespace BasicGraphQL.Data;

public static class SeedData
{
    public static async Task InitializeData(this IServiceProvider serviceProvider)
    {
        var appDataContext = serviceProvider.GetRequiredService<AppDataContext>();

        if (!appDataContext.Speakers.Any())
        {
            var speakerFaker = new Faker<Speaker>().RuleFor(x => x.Id, Guid.NewGuid)
                .RuleFor(x => x.Name, y => y.Person.UserName)
                .RuleFor(x => x.Bio, () => new MnemonicString(1, 8, 20).GetValue())
                .RuleFor(x => x.WebSize, y => y.Image.PlaceImgUrl());

            var speakers = speakerFaker.Generate(1000);
            await appDataContext.AddRangeAsync(speakers);
            await appDataContext.SaveChangesAsync();
        }
    }
}