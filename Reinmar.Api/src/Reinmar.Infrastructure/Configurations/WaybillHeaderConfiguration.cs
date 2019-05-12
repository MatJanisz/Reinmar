using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reinmar.Common.Entities;

namespace Reinmar.Infrastructure.Configurations
{
    public class WaybillHeaderConfiguration : IEntityTypeConfiguration<WaybillHeader>
    {
        public void Configure(EntityTypeBuilder<WaybillHeader> builder)
        {
            builder.ToTable("WaybillHeaders");
        }
    }
}