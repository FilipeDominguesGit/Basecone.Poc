using AutoMapper;
using Basecone.Poc.Application.Models;
using Basecone.Poc.Domain.OfficeAggregate;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Basecone.Poc.Application.Queries
{
    public class GetAllOfficesQueryHandler : IRequestHandler<GetAllOfficesQuery, List<OfficeDto>>
    {
        private readonly IOfficeRepository _officeRepository;
        private readonly IMapper _mapper;

        public GetAllOfficesQueryHandler(IOfficeRepository officeRepository, IMapper mapper)
        {
            _officeRepository = officeRepository;
            _mapper = mapper;
        }

        public async Task<List<OfficeDto>> Handle(GetAllOfficesQuery request, CancellationToken cancellationToken)
        {
            var offices = await _officeRepository.GetAllAsync();

            var officeDtos = _mapper.Map<List<OfficeDto>>(offices);

            return officeDtos;
        }
    }
}
