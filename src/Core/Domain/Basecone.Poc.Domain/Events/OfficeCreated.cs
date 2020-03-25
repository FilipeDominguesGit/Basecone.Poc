using Basecone.Poc.Domain.OfficeAggregate;
using Basecone.Poc.Seedwork;

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
