using Basecone.Poc.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Basecone.Poc.Application.Commands
{
    public class GetAllOfficesCommand : IRequest<List<OfficeDto>>
    {
    }
}
