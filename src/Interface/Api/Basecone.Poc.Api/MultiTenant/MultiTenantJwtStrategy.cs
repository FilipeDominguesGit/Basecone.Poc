using Basecone.Poc.Infrastructure.MultiTenant;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basecone.Poc.Api.MultiTenant
{
    public class MultiTenantJwtStrategy : ITenantResolutionStrategy
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MultiTenantJwtStrategy(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<string> GetTenantIdentifierAsync()
        {
            var claim = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "TenantId");
            return await Task.FromResult(claim.Value);
        }
    }
}
