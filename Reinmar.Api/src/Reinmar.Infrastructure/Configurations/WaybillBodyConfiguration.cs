using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Reinmar.Common.Entities;

namespace Reinmar.Infrastructure.Configurations
{
    public class WaybillBodyConfiguration : IEntityTypeConfiguration<WaybillBody>
    {
        public void Configure(EntityTypeBuilder<WaybillBody> builder)
        {
            builder.ToTable("WaybillBodies");
        }
    }
}