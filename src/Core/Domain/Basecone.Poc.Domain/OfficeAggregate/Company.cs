using Basecone.Poc.Domain.Events;
using Basecone.Poc.Seedwork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Basecone.Poc.Domain.OfficeAggregate
{
    public class Company: Entity
    {
        public Guid UniqueId { get; protected set; }
        public string CompanyCode { get; set; }

        public Office Office { get; protected set; }

        public Company(string companyCode)
        {
            CompanyCode = companyCode;
            UniqueId = Guid.NewGuid();
            AddDomainEvent(new CompanyCreated(this));
        }

    }
}
