using BasicGraphQL.Models.Entities;

namespace BasicGraphQL.GraphQL.Speakers;

public class AddSpeakerPayload
{
    public Speaker Speaker { get; }

    public AddSpeakerPayload(Speaker speaker)
    {
        Speaker = speaker;
    }
}