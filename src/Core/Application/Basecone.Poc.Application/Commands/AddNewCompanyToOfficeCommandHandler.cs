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
    public class AddNewCompanyToOfficeCommandHandler : IRequestHandler<AddNewCompanyToOfficeCommand, CompanyDto>
    {
        private readonly IOfficeRepository _officeRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddNewCompanyToOfficeCommandHandler(IOfficeRepository officeRepository, IUnitOfWork unitOfWork)
        {
            _officeRepository = officeRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<CompanyDto> Handle(AddNewCompanyToOfficeCommand request, CancellationToken cancellationToken)
        {
            var office = _officeRepository.Get(request.OfficeUniqueId);

            var company = new Company(request.CompanyCode);

            office.AddCompany(company);

            await _unitOfWork.Commit();

            var dto = office.Companies.Select(c => new CompanyDto
            {
                CompanyCode = c.CompanyCode,
                UniqueId = c.UniqueId
            }).FirstOrDefault();

            return dto;
        }
    }
}
