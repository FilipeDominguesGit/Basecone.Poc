using Basecone.Poc.Domain.OfficeAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Basecone.Poc.Infrastructure.Mapper
{
    public class OfficeMapper : IEntityTypeConfiguration<Office>
    {
        public void Configure(EntityTypeBuilder<Office> builder)
        {
            builder.ToTable("Offices");
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).ValueGeneratedOnAdd();
            builder.HasMany(o=>o.Companies).WithOne(c=>c.Office);
        }
    }
}
