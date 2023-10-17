using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schm.Domain.Model;

namespace Schm.Infrastructure.Persistance.EFMapper
{
    public class LogesticTypeMap : IEntityTypeConfiguration<LogesticType>
    {
        public void Configure(EntityTypeBuilder<LogesticType> builder)
        {
            builder.ToTable(typeof(LogesticType).Name);
            builder.HasKey(key => key.Id);
        }
    }
}
