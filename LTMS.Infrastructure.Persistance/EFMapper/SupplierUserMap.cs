using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schm.Domain.Model;

namespace Schm.Infrastructure.Persistance.EFMapper
{
    public class SupplierUserMap : IEntityTypeConfiguration<SupplierUser>
    {
        public void Configure(EntityTypeBuilder<SupplierUser> builder)
        {
            builder.ToTable(typeof(SupplierUser).Name);
            builder.HasKey(key => key.Id);
            builder.HasOne(e => e.Supplier).WithMany().HasForeignKey(key => key.SupplierId);
        }
    }
}
