using Basecone.Poc.Application.Models;
using MediatR;

namespace Basecone.Poc.Application.Commands
{
    public class CreateOfficeCommand : IRequest<OfficeDto>
    {
        public string OfficeCode { get; }
        public CreateOfficeCommand(string officeCode)
        {
            OfficeCode = officeCode;
        }

    }
}
