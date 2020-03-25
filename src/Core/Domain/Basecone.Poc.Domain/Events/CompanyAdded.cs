using Basecone.Poc.Domain.OfficeAggregate;
using Basecone.Poc.Seedwork;

namespace Basecone.Poc.Domain.Events
{
    public class CompanyAdded : IDomainEvent
    {
        public Office Office { get; }
        public Company Company { get; }

        public CompanyAdded(Office office, Company company)
        {
            Office = office;
            Company = company;
        }

    }
}
