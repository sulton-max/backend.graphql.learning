using BasicGraphQL.DataAccess.Contexts;
using BasicGraphQL.GraphQL.Mutations;
using BasicGraphQL.GraphQL.Queries;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultDatabaseConnection")));

builder.Services.AddGraphQLServer().AddQueryType<Query>().AddMutationType<Mutation>();

var app = builder.Build();

app.MapGraphQL("/graphql/");

app.Run();