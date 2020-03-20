using Basecone.Poc.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

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
