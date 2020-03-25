using Basecone.Poc.Domain.OfficeAggregate;
using Basecone.Poc.Seedwork;

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
