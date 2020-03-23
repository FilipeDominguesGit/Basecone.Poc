using AutoMapper;
using Basecone.Poc.Application.Models;
using Basecone.Poc.Domain.OfficeAggregate;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Basecone.Poc.Application.Queries
{
    public class GetAllOfficeCompaniesQueryHandler : IRequestHandler<GetAllOfficeCompaniesQuery, List<CompanyDto>>
    {
        private readonly IOfficeRepository _officeRepository;
        private readonly IMapper _mapper;

        public GetAllOfficeCompaniesQueryHandler(IOfficeRepository officeRepository, IMapper mapper)
        {
            _officeRepository = officeRepository;
            _mapper = mapper;
        }

        public async Task<List<CompanyDto>> Handle(GetAllOfficeCompaniesQuery request, CancellationToken cancellationToken)
        {
            var companies = await _officeRepository.GetAllOfficeCompaniesAsync(request.OfficeId);

            var dto = _mapper.Map<List<CompanyDto>>(companies);

            return await Task.FromResult(dto);
        }
    }
}
