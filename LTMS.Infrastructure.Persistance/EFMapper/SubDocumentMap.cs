using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schm.Domain.Model;

namespace Schm.Infrastructure.Persistance.EFMapper
{
    public class SubDocumentMap : IEntityTypeConfiguration<SubDocument>
    {
        public void Configure(EntityTypeBuilder<SubDocument> builder)
        {
            builder.ToTable(typeof(SubDocument).Name);
            builder.HasKey(key => key.Id);
            builder.HasOne(e => e.Document).WithMany().HasForeignKey(key => key.DocumentId);
            builder.HasOne(e => e.Item).WithMany().HasForeignKey(key => key.ItemId);
        }
    }
}
