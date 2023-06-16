using BasicGraphQL.DataAccess.Contexts;
using BasicGraphQL.GraphQL.Speakers;
using BasicGraphQL.Models.Entities;

namespace BasicGraphQL.GraphQL.Mutations;

public class Mutation
{
    public async Task<AddSpeakerPayload> AddSpeakerAsync(AddSpeakerInput input, [Service] AppDataContext appDataContext)
    {
        var speaker = new Speaker
        {
            Name = input.Name,
            Bio = input.Bio,
            WebSize = input.WebSite
        };

        appDataContext.Add(speaker);
        await appDataContext.SaveChangesAsync();

        return new AddSpeakerPayload(speaker);
    }
}