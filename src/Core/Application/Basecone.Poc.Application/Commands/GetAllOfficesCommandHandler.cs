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
    public class GetAllOfficesCommandHandler : IRequestHandler<GetAllOfficesCommand, List<OfficeDto>>
    {
        private readonly IOfficeRepository _officeRepository;

        public GetAllOfficesCommandHandler(IOfficeRepository officeRepository)
        {
            _officeRepository = officeRepository;
        }

        public async Task<List<OfficeDto>> Handle(GetAllOfficesCommand request, CancellationToken cancellationToken)
        {
            var offices = _officeRepository.GetAll();

            var officeDtos = offices
                .Select(office => new OfficeDto
                    {
                        OfficeCode = office.OfficeCode,
                        UniqueId = office.UniqueId,
                        Companies = office.Companies.Select(c => new CompanyDto
                        {
                            CompanyCode = c.CompanyCode,
                            UniqueId = c.UniqueId
                        }).ToList()
                    })
                .ToList();

            return await Task.FromResult(officeDtos);
        }
    }
}
