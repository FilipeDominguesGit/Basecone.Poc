using AutoMapper;
using Basecone.Poc.Api.Contracts.Responses;
using Basecone.Poc.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basecone.Poc.Api.Mappers
{
    public class ApiProfile : Profile
    {
        public ApiProfile()
        {
            CreateMap<OfficeDto, Office>();
            CreateMap<CompanyDto, Company>();
        }
    }
}
