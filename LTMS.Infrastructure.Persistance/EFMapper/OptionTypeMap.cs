using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Schm.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Schm.Infrastructure.Persistance.EFMapper
{
    public class OptionTypeMap : IEntityTypeConfiguration<OptionType>
    {
        public void Configure(EntityTypeBuilder<OptionType> builder)
        {

            builder.ToTable(typeof(OptionType).Name);
            builder.HasKey(key => key.Id);
 
        }
    }
}
