namespace RecipesApp.Models.Entities;

public class Recipe : IEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    
    [UseSorting]
    public ICollection<Step> Steps { get; set; }
    
    [UseSorting]
    public ICollection<Ingredient> Ingredients { get; set; }
}