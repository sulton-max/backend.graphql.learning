using BasicGraphQL.DataAccess.Contexts;
using BasicGraphQL.Models.Entities;

namespace BasicGraphQL.GraphQL.Queries;

public class Query
{
    public IQueryable<Speaker> Speakers([Service] AppDataContext appDataContext) => appDataContext.Speakers;
}