using Basecone.Poc.Domain.OfficeAggregate;
using Basecone.Poc.Seedwork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Basecone.Poc.Domain.Events
{
    public class CompanyCreated : IDomainEvent
    {
        public Company Company { get; }

        public CompanyCreated(Company company)
        {
            Company = company;
        }
    }
}
