using Basecone.Poc.Application.Models;
using MediatR;
using System;

namespace Basecone.Poc.Application.Commands
{
    public class GetOfficeByUniqueIdCommand : IRequest<OfficeDto>
    {
        public GetOfficeByUniqueIdCommand(Guid officeUniqueId)
        {
            OfficeUniqueId = officeUniqueId;
        }

        public Guid OfficeUniqueId { get; internal set; }
    }
}
