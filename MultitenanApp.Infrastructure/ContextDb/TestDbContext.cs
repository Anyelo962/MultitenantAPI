using Microsoft.Extensions.Configuration;
using MultitenanApp.Common.Entities;
using MultitenanApp.Common.interfaces;

namespace MultitenanApp.Infrastructure.ContextDb;

using Microsoft.EntityFrameworkCore;

public class TestDbContext: DbContext
{
    private readonly ITenantService _tenantService;
    private readonly IConfiguration _configuration;
    
    public TestDbContext(DbContextOptions<TestDbContext> options, IConfiguration configuration, ITenantService tenantService): base(options)
    {
        this._configuration = configuration;
        this._tenantService = tenantService;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        //foreach (var entity in modelBuilder.Model.GetEntityTypes())
        //{
        //   // var type = entity.ClrType;
            
        //}
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var tenant = _tenantService.Tenant;
        var connectionString = _configuration.GetConnectionString(tenant);
        optionsBuilder.UseSqlServer(connectionString);
    }

    public DbSet<Organization> Organizations { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Tenancy> Tenancies { get; set; }
    public DbSet<Product> Products { get; set; }
}