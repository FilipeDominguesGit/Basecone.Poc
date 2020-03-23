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
    public class AddNewCompanyToOfficeCommandHandler : IRequestHandler<AddNewCompanyToOfficeCommand, CompanyDto>
    {
        private readonly IOfficeRepository _officeRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddNewCompanyToOfficeCommandHandler(IOfficeRepository officeRepository, IUnitOfWork unitOfWork,IMapper mapper)
        {
            _officeRepository = officeRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<CompanyDto> Handle(AddNewCompanyToOfficeCommand request, CancellationToken cancellationToken)
        {
            var office = await _officeRepository.GetAsync(request.OfficeUniqueId);

            var company = new Company(request.CompanyCode);

            office.AddCompany(company);

            await _unitOfWork.Commit();
           
            var dto = _mapper.Map<CompanyDto>(office.Companies.FirstOrDefault());

            return dto;
        }
    }
}
