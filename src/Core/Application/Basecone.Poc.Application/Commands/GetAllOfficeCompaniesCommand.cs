using Basecone.Poc.Application.Models;
using Basecone.Poc.Domain.OfficeAggregate;
using MediatR;
using System;
using System.Collections.Generic;

namespace Basecone.Poc.Application.Commands
{
    public class GetAllOfficeCompaniesCommand :IRequest<List<CompanyDto>>
    {
        public GetAllOfficeCompaniesCommand(Guid officeId)
        {
            OfficeId = officeId;
        }

        public Guid OfficeId { get; set; }
    }
}