using MultitenanApp.Common.Entities;

namespace MultitenanApp.Infrastructure.DbContext;

using Microsoft.EntityFrameworkCore;

public class MultitencyDbContext: DbContext
{

    private readonly int _tenantId;
    public MultitencyDbContext(DbContextOptions<MultitencyDbContext> options): base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // foreach (var entity in modelBuilder.Model.GetEntityTypes())
        // {
        //     var type = entity.ClrType;
        //     
        //     
        // }
        
       // modelBuilder.Entity<Product>().HasQueryFilter(p => )
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Organization> Organizations { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Tenancy> Tenancies { get; set; }
}