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
    public class GetAllOfficesCommandHandler : IRequestHandler<GetAllOfficesCommand, List<OfficeDto>>
    {
        private readonly IOfficeRepository _officeRepository;
        private readonly IMapper _mapper;

        public GetAllOfficesCommandHandler(IOfficeRepository officeRepository, IMapper mapper)
        {
            _officeRepository = officeRepository;
            _mapper = mapper;
        }

        public async Task<List<OfficeDto>> Handle(GetAllOfficesCommand request, CancellationToken cancellationToken)
        {
            var offices = await _officeRepository.GetAllAsync();
     
            var officeDtos = _mapper.Map<List<OfficeDto>>(offices);

            return officeDtos;
        }
    }
}
