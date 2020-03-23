using AutoMapper;
using Basecone.Poc.Application.Models;
using Basecone.Poc.Domain.OfficeAggregate;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Basecone.Poc.Application.Commands
{
    public class GetOfficeCompanyCommandHandler : IRequestHandler<GetOfficeCompanyCommand, CompanyDto>
    {
        private readonly IOfficeRepository _officeRepository;
        private readonly IMapper _mapper;

        public GetOfficeCompanyCommandHandler(IOfficeRepository officeRepository, IMapper mapper)
        {
            _officeRepository = officeRepository;
            _mapper = mapper;
        }

        public async Task<CompanyDto> Handle(GetOfficeCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = await _officeRepository.GetOfficeCompanyByIdAsync(request.OfficeId, request.CompayId);

            var dto = _mapper.Map<CompanyDto>(company);

            return dto;
        }
    }
}
