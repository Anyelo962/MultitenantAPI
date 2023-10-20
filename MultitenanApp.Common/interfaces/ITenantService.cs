namespace MultitenanApp.Common.interfaces;

public interface ITenantService
{
    string Tenant { get; }

    void SetTenant(string tenant);

    string[] GetTenants();

    event TenantChangedEventHandler OnTenantChanged;
}
