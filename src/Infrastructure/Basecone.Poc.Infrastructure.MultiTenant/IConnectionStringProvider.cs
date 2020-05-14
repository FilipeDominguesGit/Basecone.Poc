using System.Threading.Tasks;

namespace Basecone.Poc.Infrastructure.MultiTenant
{
    public interface IConnectionStringProvider
    {
        Task<string> GetConnectionString();
        Task<string> GetConnectionString(string tenantId);
    }
}
