namespace RecipesApp.Models.Entities;

public class Step : IEntity
{
    public Guid Id { get; set; }
    public int Order { get; set; }
    public TimeSpan Duration { get; set; }
    public string Instructions { get; set; } = string.Empty;
}