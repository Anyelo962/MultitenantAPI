using MultitenanApp.Common.Entities;
using MultitenanApp.Common.interfaces;

namespace MultitenanApp.Infrastructure.DbContext;

using Microsoft.EntityFrameworkCore;

public class MultitencyDbContext: DbContext
{

    private readonly string _tenantId;
    public MultitencyDbContext(DbContextOptions<MultitencyDbContext> options): base(options)
    {
        //_tenantId = tenantGetter.tenant;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        //foreach (var entity in modelBuilder.Model.GetEntityTypes())
        //{
        //   // var type = entity.ClrType;
            
        //}
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Organization> Organizations { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Tenancy> Tenancies { get; set; }
}