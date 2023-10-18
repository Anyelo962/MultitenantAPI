using MultitenanApp.Common.Entities;

namespace MultitenanApp.Common.interfaces;

public interface ITenancyProvider
{
    Tenancy GetCurrentTenancy();
}