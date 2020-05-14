using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace Basecone.Poc.Infrastructure.MultiTenant
{
    public class ConnectionStringProvider : IConnectionStringProvider
    {
        private readonly ITenantStore _tenantStore;
        private readonly ITenantResolutionStrategy _tenantResolutionStrategy;
        private readonly IConfiguration _configuration;

        public ConnectionStringProvider(ITenantStore tenantStore, ITenantResolutionStrategy tenantResolution, IConfiguration configuration)
        {
            _tenantStore = tenantStore;
            _tenantResolutionStrategy = tenantResolution;
            _configuration = configuration;
        }

        public async Task<string> GetConnectionString()
        {
            var tenantUniqueId = await _tenantResolutionStrategy.GetTenantIdentifierAsync();
            var tenant = await _tenantStore.GetTenantAsync(tenantUniqueId);

            return _configuration.GetConnectionString($"MySql{tenant.DatabaseServerId}");
        }

        public async Task<string> GetConnectionString(string tenantUniqueId)
        {
            var tenant = await _tenantStore.GetTenantAsync(tenantUniqueId);
            return _configuration.GetConnectionString($"MySql{tenant.TenantId}");
        }
    }
}
