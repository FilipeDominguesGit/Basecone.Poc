using System;
using System.Collections.Generic;
using System.Text;

namespace Basecone.Poc.Infrastructure.MultiTenant
{
    public class Tenant
    {
        public int TenantId { get; set; }
        public string DatabaseServerId { get; set; }
        public Guid? SubscriptionId { get; set; }
        public Guid TenantUniqueId { get; set; }
        public DateTime DateCreated { get; set; }
        public int OfficeId { get; set; }

    }
}

