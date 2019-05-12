using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reinmar.Common.Entities;

namespace Reinmar.Infrastructure.Configurations
{
    public class WaybillConfiguration : IEntityTypeConfiguration<Waybill>
    {
        public void Configure(EntityTypeBuilder<Waybill> builder)
        {
            builder.ToTable("Waybills");
        }
    }
}