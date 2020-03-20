using System;
using System.Collections.Generic;
using System.Text;

namespace Basecone.Poc.Application.Models
{
    public class OfficeDto
    {
        public string OfficeCode { get; set; }
        public Guid UniqueId { get; set; }
        public List<CompanyDto> Companies { get; set; }
      
    }
}
