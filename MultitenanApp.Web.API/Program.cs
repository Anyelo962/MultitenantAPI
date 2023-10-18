using Microsoft.EntityFrameworkCore;
using MultitenanApp.Common.interfaces;
using MultitenanApp.Infrastructure.DbContext;
using MultitenanApp.Infrastructure.TenancyConfig;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ITenancyProvider, TenancyProviderConfig>();

builder.Services.AddDbContext<MultitencyDbContext>((serviceProvider, dbContextOptionsBuilder) =>
{
    var tenantProvider = serviceProvider.GetRequiredService<ITenancyProvider>();
    var tenant = tenantProvider.GetCurrentTenancy();
    
    if (tenant != null)
    {
        dbContextOptionsBuilder.UseSqlServer(tenant.name);
    }
    else
    {
        dbContextOptionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    }
    
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();