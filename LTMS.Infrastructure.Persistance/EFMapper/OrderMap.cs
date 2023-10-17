using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schm.Domain.Model;

namespace Schm.Infrastructure.Persistance.EFMapper
{
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(key => key.Id);
            builder.HasOne(e => e.Supplier).WithMany().HasForeignKey(key => key.SupplierId);
            builder.HasOne(e => e.PaymentType).WithMany().HasForeignKey(key => key.PaymentTypeId);
            builder.HasOne(e => e.LogesticType).WithMany().HasForeignKey(key => key.LogenticTypeId);
        }
    }
}
