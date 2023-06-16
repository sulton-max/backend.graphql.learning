using Microsoft.EntityFrameworkCore;
using RecipesApp.Data;
using RecipesApp.DataAccess.DataContexts;
using RecipesApp.DataAccess.Queries;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultDatabaseConnection")));
builder.Services.AddGraphQLServer().AddQueryType<Query>().AddProjections().AddFiltering().AddSorting();

var app = builder.Build();

await app.Services.CreateScope().ServiceProvider.InitializeData();
app.MapGraphQL("/graphql/");

app.Run();