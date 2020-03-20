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

        public GetOfficeCompanyCommandHandler(IOfficeRepository officeRepository)
        {
            _officeRepository = officeRepository;
        }

        public async Task<CompanyDto> Handle(GetOfficeCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = _officeRepository.GetOfficeCompanyById(request.OfficeId, request.CompayId);

            var dto = new CompanyDto
            {
                CompanyCode = company.CompanyCode,
                UniqueId = company.UniqueId
            };

            return await Task.FromResult(dto);
        }
    }
}
