namespace RecipesApp.Models.Entities;

public class Ingredient : IEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;
    public int WholeQuantity { get; set; }
    public string Measurement { get; set; } = string.Empty;
}