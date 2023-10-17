using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schm.Domain.Model;

namespace Schm.Infrastructure.Persistance.EFMapper
{
    public class PaymentTypeMap : IEntityTypeConfiguration<PaymentType>
    {
        public void Configure(EntityTypeBuilder<PaymentType> builder)
        {
            builder.ToTable(typeof(PaymentType).Name);
            builder.HasKey(key => key.Id);
        }
    }
}
