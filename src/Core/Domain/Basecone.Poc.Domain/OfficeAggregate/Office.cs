using Basecone.Poc.Domain.Events;
using Basecone.Poc.Domain.Exceptions;
using Basecone.Poc.Seedwork;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Basecone.Poc.Domain.OfficeAggregate
{
    public class Office : Entity, IAggregateRoot
    {
        public Guid UniqueId { get; protected set; }

        public string OfficeCode
        {
            get { return _officeCode; }
            protected internal set
            {

                if (value.Any(x => !char.IsLetterOrDigit(x)) && value.Length >= 100)
                {
                    throw new Exception("Office code can only contain letters or digits");
                }

                _officeCode = value;
            }
        }

        private string _officeCode;


        public IReadOnlyList<Company> Companies => _companies.AsReadOnly();

        private List<Company> _companies = new List<Company>();

        public Office()
        {
        }

        public Office(string officeCode)
        {
            UniqueId = Guid.NewGuid();
            OfficeCode = officeCode;

            AddDomainEvent(new OfficeCreated(this));

        }


        public void AddCompany(Company company)
        {
            if (_companies.Any(c => c.CompanyCode == company.CompanyCode))
            {
                throw new DomainException("Office already has company with same code");
            }

            _companies.Add(company);
            AddDomainEvent(new CompanyAdded(this, company));
        }

    }
}
