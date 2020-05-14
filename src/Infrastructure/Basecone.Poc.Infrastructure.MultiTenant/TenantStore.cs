using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Basecone.Poc.Infrastructure.MultiTenant
{
    public class TenantStore : ITenantStore
    {
        private readonly TenantDbContext _tenantDbContext;

        public TenantStore(TenantDbContext tenantDbContext)
        {
            _tenantDbContext = tenantDbContext;
        }

        public async Task<Tenant> GetTenantAsync(string identifier)
        {

            if (!Guid.TryParse(identifier, out Guid tenantUniqueId))
            {
                throw new Exception("Invalid TenantUniqueId");
            };

            var tenant = await _tenantDbContext.Set<Tenant>().FirstOrDefaultAsync(t => t.TenantUniqueId == tenantUniqueId);

            if(tenant==null)
            {
                throw new Exception("Tenant not found");
            };

            return tenant;
        }
    }
}
