namespace BasicGraphQL.Models.Entities;

public class Speaker : EntityBase
{
    public string Name { get; set; } = string.Empty;
    public string Bio { get; set; } = string.Empty;
    public string WebSize { get; set; } = string.Empty;
}