using AutoMapper;
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
        private readonly IMapper _mapper;

        public GetOfficeByUniqueIdCommandHandler(IOfficeRepository officeRepository,IMapper mapper)
        {
            _officeRepository = officeRepository;
            _mapper = mapper;
        }

        public async Task<OfficeDto> Handle(GetOfficeByUniqueIdCommand request, CancellationToken cancellationToken)
        {
            var office = await _officeRepository.GetAsync(request.OfficeUniqueId);

            var dto = _mapper.Map<OfficeDto>(office);

            return dto;
        }
    }
}
