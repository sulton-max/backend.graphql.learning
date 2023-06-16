using BasicGraphQL.DataAccess.Configurations;
using BasicGraphQL.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BasicGraphQL.DataAccess.Contexts;

public class AppDataContext : DbContext
{
    public DbSet<Speaker> Speakers { get; set; }

    public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SpeakerConfiguration).Assembly);
    }
}