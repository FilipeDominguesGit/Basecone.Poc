using Basecone.Poc.Application.Models;
using MediatR;
using System.Collections.Generic;

namespace Basecone.Poc.Application.Queries
{
    public class GetAllOfficesQuery : IRequest<List<OfficeDto>>
    {
    }
}
