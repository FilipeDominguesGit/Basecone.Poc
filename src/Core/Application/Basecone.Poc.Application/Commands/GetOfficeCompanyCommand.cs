using Basecone.Poc.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Basecone.Poc.Application.Commands
{
    public class GetOfficeCompanyCommand : IRequest<CompanyDto>
    {
        public GetOfficeCompanyCommand(Guid officeId, Guid compayId)
        {
            OfficeId = officeId;
            CompayId = compayId;
        }

        public Guid OfficeId { get; set; }
        public Guid CompayId { get; set; }
    }
}
