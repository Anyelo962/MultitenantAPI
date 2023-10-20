using Microsoft.EntityFrameworkCore;
using MultitenanApp.Common.interfaces;
using MultitenanApp.Infrastructure.ContextDb;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddScoped<ITenancyProvider, TenantServiceConfig>();

builder.Services.AddScoped<ITenantService, ITenantService>();
builder.Services.AddDbContextFactory<TestDbContext>(options => {}, ServiceLifetime.Scoped);

builder.Services.AddDbContext<TestDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("OrganizationUserDB"));
});




// builder.Services.AddDbContext<OrganizationDbContext>((serviceProvider, dbContextOptionsBuilder) =>
// {
//     var tenantProvider = serviceProvider.GetRequiredService<ITenancyProvider>();
//     var tenant = tenantProvider.GetCurrentTenancy();
//     
//     if (tenant != null)
//     {
//         dbContextOptionsBuilder.UseSqlServer(tenant.name);
//     }
//     else
//     {
//         dbContextOptionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
//     }
//     
// });

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