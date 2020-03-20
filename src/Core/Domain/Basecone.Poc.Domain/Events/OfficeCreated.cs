using Basecone.Poc.Domain.OfficeAggregate;
using Basecone.Poc.Seedwork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Basecone.Poc.Domain.Events
{
    public class OfficeCreated : IDomainEvent
    {
        public Office Office { get; }
        public OfficeCreated(Office office)
        {
            Office = office;
        }

    }
}
