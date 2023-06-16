using RecipesApp.DataAccess.DataContexts;
using RecipesApp.Models.Entities;

namespace RecipesApp.DataAccess.Queries;

public class Query
{
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Recipe> Recipes([Service] AppDataContext appDataContext) => appDataContext.Recipes;
}