using Basecone.Poc.Domain.OfficeAggregate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basecone.Poc.Infrastructure
{
    public class OfficeRepository : IOfficeRepository
    {
        private readonly BaseconePocContext _context;

        public OfficeRepository(BaseconePocContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Office office)
        {
           await _context.Set<Office>()
                .AddAsync(office)
                .ConfigureAwait(false);
        }

        public async Task<Office> GetAsync(Guid uniqueId)
        {
            return await _context.Set<Office>()
                .Include(o => o.Companies)
                .Where(o => o.UniqueId == uniqueId)
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);
        }

        public async Task<List<Office>> GetAllAsync()
        {
            return await _context.Set<Office>()
                .Include(o => o.Companies)
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task<Company> GetOfficeCompanyByIdAsync(Guid officeUniqueId, Guid companyUniqueId)
        {
            var office = await _context.Set<Office>()
                .Include(o => o.Companies)
                .Where(o => o.UniqueId == officeUniqueId)
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);

            return office.Companies.Where(c => c.UniqueId == companyUniqueId).FirstOrDefault();
        }

        public async Task<List<Company>> GetAllOfficeCompaniesAsync(Guid officeUniqueId)
        {
            var office = await _context.Set<Office>()
                .Include(o => o.Companies)
                .Where(o => o.UniqueId == officeUniqueId)
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);

            return office?.Companies.ToList();
        }
    }
}
