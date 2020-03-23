using Basecone.Poc.Seedwork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Basecone.Poc.Domain.OfficeAggregate
{
    public interface IOfficeRepository : IRepository<Office>
    {
        Task<List<Office>> GetAllAsync();
        Task<Office> GetAsync(Guid uniqueId);
        Task<Company> GetOfficeCompanyByIdAsync(Guid officeUniqueId, Guid companyUniqueId);
        Task<List<Company>> GetAllOfficeCompaniesAsync(Guid officeUniqueId);
        Task AddAsync(Office office);
    }
}
