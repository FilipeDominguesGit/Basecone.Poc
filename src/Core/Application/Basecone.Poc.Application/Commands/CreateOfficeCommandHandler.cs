using AutoMapper;
using Basecone.Poc.Application.Models;
using Basecone.Poc.Domain.OfficeAggregate;
using Basecone.Poc.Seedwork;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Basecone.Poc.Application.Commands
{
    public class CreateOfficeCommandHandler : IRequestHandler<CreateOfficeCommand, OfficeDto>
    {
        private readonly IOfficeRepository _officeRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateOfficeCommandHandler(IOfficeRepository officeRepository,IUnitOfWork unitOfWork, IMapper mapper)
        {
            _officeRepository = officeRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<OfficeDto> Handle(CreateOfficeCommand request, CancellationToken cancellationToken)
        {
            var office = new Office(request.OfficeCode);

            await _officeRepository.AddAsync(office);
            await _unitOfWork.Commit();
         
            var dto = _mapper.Map<OfficeDto>(office);

            return dto;
        }
    }
}
