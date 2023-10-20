using MultitenanApp.Common.Entities;
using MultitenanApp.Common.interfaces;

namespace MultitenanApp.Common;


public delegate void TenantChangedEventHandler(object source, TenantChangedEventArgs args);
public class TenantServiceConfig : ITenantService
{
    public TenantServiceConfig() => _tenant = GetTenants()[0];

    public TenantServiceConfig(string tenant) => _tenant = tenant;

    private string _tenant;

    public event TenantChangedEventHandler OnTenantChanged = null!;

    public string Tenant => _tenant;

    public void SetTenant(string tenant)
    {
        if (tenant != _tenant)
        {
            var old = _tenant;
            _tenant = tenant;
            OnTenantChanged?.Invoke(this, new TenantChangedEventArgs(old, _tenant));
        }
    }
        
    public string[] GetTenants() => new[]
    {
        "OrganizationUserDB",
        "ProductDB",
    };
}