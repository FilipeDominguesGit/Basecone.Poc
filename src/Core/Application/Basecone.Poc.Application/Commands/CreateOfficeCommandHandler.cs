using Basecone.Poc.Application.Models;
using Basecone.Poc.Domain.OfficeAggregate;
using Basecone.Poc.Seedwork;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Basecone.Poc.Application.Commands
{
    public class CreateOfficeCommandHandler : IRequestHandler<CreateOfficeCommand, OfficeDto>
    {
        private readonly IOfficeRepository _officeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateOfficeCommandHandler(IOfficeRepository officeRepository,IUnitOfWork unitOfWork)
        {
            _officeRepository = officeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<OfficeDto> Handle(CreateOfficeCommand request, CancellationToken cancellationToken)
        {
            var office = new Office(request.OfficeCode);

            _officeRepository.Add(office);
            await _unitOfWork.Commit();
            var dto = new OfficeDto
            {
                OfficeCode = office.OfficeCode,
                UniqueId = office.UniqueId,
                Companies = office.Companies.Select(c => new CompanyDto
                {
                    CompanyCode = c.CompanyCode,
                    UniqueId = c.UniqueId
                }).ToList()
            };

            return dto;
        }
    }
}
