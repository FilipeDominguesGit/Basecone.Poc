using System.Threading.Tasks;

namespace Basecone.Poc.Infrastructure.MultiTenant
{
    public interface ITenantStore
    {
        Task<Tenant> GetTenantAsync(string tenantId);
    }
}
