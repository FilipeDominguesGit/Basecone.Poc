using Basecone.Poc.Application.Models;
using MediatR;
using System;

namespace Basecone.Poc.Application.Queries
{
    public class GetOfficeCompanyQuery : IRequest<CompanyDto>
    {
        public GetOfficeCompanyQuery(Guid officeId, Guid compayId)
        {
            OfficeId = officeId;
            CompayId = compayId;
        }

        public Guid OfficeId { get; set; }
        public Guid CompayId { get; set; }
    }
}
