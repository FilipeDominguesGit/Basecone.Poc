using Basecone.Poc.Application.Models;
using Basecone.Poc.Domain.OfficeAggregate;
using MediatR;
using System;
using System.Collections.Generic;

namespace Basecone.Poc.Application.Queries
{
    public class GetAllOfficeCompaniesQuery : IRequest<List<CompanyDto>>
    {
        public GetAllOfficeCompaniesQuery(Guid officeId)
        {
            OfficeId = officeId;
        }

        public Guid OfficeId { get; set; }
    }
}