using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Basecone.Poc.Infrastructure.MultiTenant
{
    public class BaseconePocContextFactory
    {

        private readonly DbContextOptionsBuilder<BaseconePocContext> _optionsBuilder;
        private readonly IConnectionStringProvider _connectionStringProvider;

        public BaseconePocContextFactory(DbContextOptionsBuilder<BaseconePocContext> optionsBuilder, IConnectionStringProvider connectionStringProvider)
        {
            _optionsBuilder = optionsBuilder;
            _connectionStringProvider = connectionStringProvider;
        }

        public async Task<BaseconePocContext> CreateDbContext()
        {
            var connString = await _connectionStringProvider.GetConnectionString().ConfigureAwait(false);
            _optionsBuilder.UseMySql(connString);

            return new BaseconePocContext(_optionsBuilder.Options);
        }

        public async Task<BaseconePocContext> CreateSessionByTenantId(string tenantId)
        {
            var connString = await _connectionStringProvider.GetConnectionString(tenantId).ConfigureAwait(false);
            _optionsBuilder.UseMySql(connString);

            return new BaseconePocContext(_optionsBuilder.Options);
        }
    }
}
