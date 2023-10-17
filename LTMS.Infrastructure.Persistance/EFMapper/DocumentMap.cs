using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schm.Domain.Model;

namespace Schm.Infrastructure.Persistance.EFMapper
{
    public class DocumentMap : IEntityTypeConfiguration<Document>
    {
        public void Configure(EntityTypeBuilder<Document> builder)
        {
            builder.ToTable(typeof(Document).Name);
            builder.HasKey(key => key.Id);
            builder.HasOne(e => e.Supplier).WithMany().HasForeignKey(key => key.SupplierId);
        }
    }
}
