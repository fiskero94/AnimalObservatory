using AnimalObservatory.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace AnimalObservatory.Infrastructure.DatabaseContexts;

internal class InMemoryContext : DbContext
{
    public DbSet<AnimalEntity> Animals { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options) =>
        options.UseInMemoryDatabase("AnimalObservatory");
}
