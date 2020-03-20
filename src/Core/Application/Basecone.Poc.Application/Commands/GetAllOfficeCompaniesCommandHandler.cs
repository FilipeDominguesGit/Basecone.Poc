using Basecone.Poc.Application.Models;
using Basecone.Poc.Domain.OfficeAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Basecone.Poc.Application.Commands
{
    public class GetAllOfficeCompaniesCommandHandler : IRequestHandler<GetAllOfficeCompaniesCommand, List<CompanyDto>>
    {
        private readonly IOfficeRepository _officeRepository;

        public GetAllOfficeCompaniesCommandHandler(IOfficeRepository officeRepository)
        {
            _officeRepository = officeRepository;
        }

        public async Task<List<CompanyDto>> Handle(GetAllOfficeCompaniesCommand request, CancellationToken cancellationToken)
        {
            var companies =_officeRepository.GetAllOfficeCompanies(request.OfficeId);
            var dto = companies.Select(c => new CompanyDto
            {
                CompanyCode = c.CompanyCode,
                UniqueId = c.UniqueId
            }).ToList();

            return await Task.FromResult(dto);
        }
    }
}
