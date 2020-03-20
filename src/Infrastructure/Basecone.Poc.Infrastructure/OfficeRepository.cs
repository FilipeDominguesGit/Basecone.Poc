using Basecone.Poc.Domain.OfficeAggregate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Basecone.Poc.Infrastructure
{
    public class OfficeRepository : IOfficeRepository
    {
        private readonly BaseconePocContext _context;

        public OfficeRepository(BaseconePocContext context)
        {
            _context = context;
        }

        public void Add(Office office)
        {
            _context.Set<Office>().Add(office);
        }

        public Office Get(Guid uniqueId)
        {
            return _context.Set<Office>().Include(o => o.Companies).Where(o => o.UniqueId == uniqueId).FirstOrDefault();
        }

        public List<Office> GetAll()
        {
            return _context.Set<Office>().Include(o => o.Companies).ToList();
        }

        public Company GetOfficeCompanyById(Guid officeUniqueId, Guid companyUniqueId)
        {
            return _context.Set<Office>()
                .Include(o => o.Companies)
                .Where(o => o.UniqueId == officeUniqueId)
                .FirstOrDefault()?
                .Companies.Where(c=>c.UniqueId==companyUniqueId).FirstOrDefault();
        }

        public List<Company> GetAllOfficeCompanies(Guid officeUniqueId)
        {
            return _context.Set<Office>()
                .Include(o => o.Companies)
                .Where(o => o.UniqueId == officeUniqueId)
                .FirstOrDefault()?
                .Companies.ToList();
        }
    }
}
