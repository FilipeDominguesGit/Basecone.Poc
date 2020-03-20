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

        public Company(string companyCode)
        {
            CompanyCode = companyCode;
        }

    }
}
