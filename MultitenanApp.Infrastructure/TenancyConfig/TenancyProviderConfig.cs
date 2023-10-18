using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using MultitenanApp.Common.Entities;
using MultitenanApp.Common.interfaces;
using MultitenanApp.Infrastructure.DbContext;

namespace MultitenanApp.Infrastructure.TenancyConfig;

public class TenancyProviderConfig : ITenancyProvider
{
    private readonly IHttpContextAccessor _httpContextAccesor;
    private readonly MultitencyDbContext _context;
    private readonly HostApplicationBuilder _configurationManager;

    public TenancyProviderConfig(IHttpContextAccessor httpContextAccesor, MultitencyDbContext context, HostApplicationBuilder configurationManager)
    {
        this._httpContextAccesor = httpContextAccesor;
        this._context = context;
        this._configurationManager = configurationManager;
    }
    
    public Tenancy GetCurrentTenancy()
    {
        var tenantName = _httpContextAccesor.HttpContext.Request.Host.Host.ToLower();

        var tenancyConfig = GetTenancyConfig(tenancyName:tenantName);
        if (tenancyConfig != null)
        {
            return new Tenancy
            {
                Id = tenancyConfig.Id,
                name = tenancyConfig.name
            };

        }

        return null;
    }



    private Common.Entities.TenancyConfig GetTenancyConfig(string tenancyName)
    {
        var tenancyConfig = _configurationManager.Configuration.GetSection("TenantConnection")
            .Get<List<Common.Entities.TenancyConfig>>();

        return tenancyConfig?.FirstOrDefault(t => t.name.ToLower() == tenancyName)!;

    }
}