using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Basecone.Poc.Infrastructure.MultiTenant
{
    public interface ITenantResolutionStrategy
    {
        Task<string> GetTenantIdentifierAsync();
    }
}
