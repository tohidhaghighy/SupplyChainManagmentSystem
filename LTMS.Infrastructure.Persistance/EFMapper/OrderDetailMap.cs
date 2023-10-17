using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schm.Domain.Model;

namespace Schm.Infrastructure.Persistance.EFMapper
{
    public class OrderDetailMap : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasKey(key => key.Id);
            builder.HasOne(e => e.Item).WithMany().HasForeignKey(key => key.ItemId);
            builder.HasOne(e => e.Order).WithMany().HasForeignKey(key => key.OrderId);
        }
    }
}
