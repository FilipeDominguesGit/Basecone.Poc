using Basecone.Poc.Application.Models;
using MediatR;
using System;

namespace Basecone.Poc.Application.Commands
{
    public class AddNewCompanyToOfficeCommand : IRequest<CompanyDto>
    {
        public AddNewCompanyToOfficeCommand(Guid officeUniqueId, string companyCode)
        {
            OfficeUniqueId = officeUniqueId;
            CompanyCode = companyCode;
        }

        public Guid OfficeUniqueId { get; set; }
        public string CompanyCode { get; set; }
    }
}
