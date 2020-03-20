using Basecone.Poc.Application.Models;
using Basecone.Poc.Domain.OfficeAggregate;
using Basecone.Poc.Seedwork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Basecone.Poc.Application.Commands
{
    public class GetOfficeByUniqueIdCommandHandler : IRequestHandler<GetOfficeByUniqueIdCommand, OfficeDto>
    {
        private readonly IOfficeRepository _officeRepository;

        public GetOfficeByUniqueIdCommandHandler(IOfficeRepository officeRepository)
        {
            _officeRepository = officeRepository;
        }

        public async Task<OfficeDto> Handle(GetOfficeByUniqueIdCommand request, CancellationToken cancellationToken)
        {
            var office = _officeRepository.Get(request.OfficeUniqueId);
            var dto = new OfficeDto
            {
                OfficeCode = office.OfficeCode,
                UniqueId = office.UniqueId,
                Companies = office.Companies.Select(c=>new CompanyDto {
                    CompanyCode = c.CompanyCode,
                    UniqueId =c.UniqueId}).ToList()
            };

            return await Task.FromResult(dto);
        }
    }
}
