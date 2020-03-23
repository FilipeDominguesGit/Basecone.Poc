using Basecone.Poc.Application.Models;
using MediatR;
using System;

namespace Basecone.Poc.Application.Commands
{
    public class GetOfficeByUniqueIdQuery : IRequest<OfficeDto>
    {
        public GetOfficeByUniqueIdQuery(Guid officeUniqueId)
        {
            OfficeUniqueId = officeUniqueId;
        }

        public Guid OfficeUniqueId { get; internal set; }
    }
}
