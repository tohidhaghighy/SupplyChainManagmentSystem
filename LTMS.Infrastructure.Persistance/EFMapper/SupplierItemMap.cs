using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schm.Domain.Model;

namespace Schm.Infrastructure.Persistance.EFMapper
{
    internal class SupplierItemMap : IEntityTypeConfiguration<SupplierItem>
    {
        public void Configure(EntityTypeBuilder<SupplierItem> builder)
        {
            builder.ToTable(typeof(SupplierItem).Name);
            builder.HasKey(key => key.Id);
            builder.HasOne(e => e.Supplier).WithMany().HasForeignKey(key => key.SupplierId);
            builder.HasOne(e => e.Item).WithMany().HasForeignKey(key => key.ItemId);
        }
    }
}
