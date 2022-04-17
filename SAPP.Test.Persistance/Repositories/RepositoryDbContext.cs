using Microsoft.EntityFrameworkCore;
using SAPP.Test.Domain.Entities.Test;


namespace SAPP.Test.Persistance.Repositories;

public sealed class RepositoryDbContext :DbContext 
{
    public RepositoryDbContext(DbContextOptions options) : base(options)
    { }
    public DbSet<TestParent> TestParents { get; set; }

    public DbSet<TestChild> TestChildren { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(RepositoryDbContext).Assembly);
}

