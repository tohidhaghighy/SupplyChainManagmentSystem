using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schm.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Schm.Infrastructure.Persistance.EFMapper
{
    public class OptionTypeGroupMap : IEntityTypeConfiguration<OptionGroupType>
    {
        public void Configure(EntityTypeBuilder<OptionGroupType> builder)
        {
            builder.ToTable(typeof(OptionGroupType).Name);
            builder.HasKey(key => key.Id);
        }
    }
}
