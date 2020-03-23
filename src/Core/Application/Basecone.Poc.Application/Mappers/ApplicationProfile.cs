using AutoMapper;
using Basecone.Poc.Application.Models;
using Basecone.Poc.Domain.OfficeAggregate;

namespace Basecone.Poc.Application.Mappers
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<Office, OfficeDto>();

            CreateMap<Company, CompanyDto>();

        }
    }
}
