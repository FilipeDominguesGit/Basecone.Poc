using System;
using System.Collections.Generic;
using System.Text;

namespace Basecone.Poc.Api.Contracts.Responses
{
    public class Office
    {
        public string OfficeCode { get; set; }
        public Guid UniqueId { get; set; }
        public List<Company> Companies { get; set; }
    }
}
