using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schm.Domain.Model;

namespace Schm.Infrastructure.Persistance.EFMapper
{
    public class DeliverySupplierPlanMap : IEntityTypeConfiguration<DeliverySupplierPlan>
    {
        public void Configure(EntityTypeBuilder<DeliverySupplierPlan> builder)
        {
            builder.ToTable(typeof(DeliverySupplierPlan).Name);
            builder.HasKey(key => key.Id);
            builder.HasOne(e => e.Supplier).WithMany().HasForeignKey(key => key.SupplierId);
        }
    }
}
