using AutoMapper;
using Basecone.Poc.Application.Models;
using Basecone.Poc.Domain.OfficeAggregate;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Basecone.Poc.Application.Commands
{
    public class GetOfficeByUniqueIdQueryHandler : IRequestHandler<GetOfficeByUniqueIdQuery, OfficeDto>
    {
        private readonly IOfficeRepository _officeRepository;
        private readonly IMapper _mapper;

        public GetOfficeByUniqueIdQueryHandler(IOfficeRepository officeRepository,IMapper mapper)
        {
            _officeRepository = officeRepository;
            _mapper = mapper;
        }

        public async Task<OfficeDto> Handle(GetOfficeByUniqueIdQuery request, CancellationToken cancellationToken)
        {
            var office = await _officeRepository.GetAsync(request.OfficeUniqueId);

            var dto = _mapper.Map<OfficeDto>(office);

            return dto;
        }
    }
}
