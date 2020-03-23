using AutoMapper;
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
        private readonly IMapper _mapper;

        public GetAllOfficeCompaniesCommandHandler(IOfficeRepository officeRepository, IMapper mapper)
        {
            _officeRepository = officeRepository;
            _mapper = mapper;
        }

        public async Task<List<CompanyDto>> Handle(GetAllOfficeCompaniesCommand request, CancellationToken cancellationToken)
        {
            var companies =await _officeRepository.GetAllOfficeCompaniesAsync(request.OfficeId);

            var dto = _mapper.Map<List<CompanyDto>>(companies);

            return await Task.FromResult(dto);
        }
    }
}
