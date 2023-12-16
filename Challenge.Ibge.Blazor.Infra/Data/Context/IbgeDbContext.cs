using Microsoft.EntityFrameworkCore;
using Challenge.Ibge.Blazor.Infra.Data.Entities;

namespace Challenge.Ibge.Blazor.Infra.Data.Context;

public class IbgeDbContext : DbContext 
{
    public IbgeDbContext(DbContextOptions<IbgeDbContext> options)
     : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }

    public virtual DbSet<IbgeEntity> Ibge { get; set; }
}
