using Basecone.Poc.Seedwork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Basecone.Poc.Domain.OfficeAggregate
{
    public interface IOfficeRepository : IRepository<Office>
    {
        List<Office> GetAll();
        Office Get(Guid uniqueId);
        Company GetOfficeCompanyById(Guid officeUniqueId, Guid companyUniqueId);
        List<Company> GetAllOfficeCompanies(Guid officeUniqueId);
        void Add(Office office);
    }
}
